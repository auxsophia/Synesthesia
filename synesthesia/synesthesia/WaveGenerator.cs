/*
    Author: Elliott Ploutz
    All rights reserved.

    This class initializes all the classes in Chunks.cs and creates the wave.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum WaveExampleType
{
    ExampleSineWave = 0,
    NaiveApproach = 1
}

namespace synesthesia
{
    public class WaveGenerator
    {
        public WaveHeader header;
        public WaveFormatChunk format;
        public WaveDataChunk data;

        public WaveGenerator(WaveExampleType type, short [] waveData)
        {
            // Initialize chunks:
            header = new WaveHeader();
            format = new WaveFormatChunk();
            data = new WaveDataChunk();

            // Fill the data array with sample data
            switch (type)
            {
                case WaveExampleType.ExampleSineWave:
                    // Number of samples = sample rate * channels
                    uint numSamples = format.dwSamplesPerSec * format.wChannels;
                                 
                    // Initialize the 16-bit array
                    data.shortArray = new short[numSamples];

                    int amplitude = 32760;  // Max amplitude for 16-bit audio
                    double freq = 554.37f;   // Concert A: 440Hz, Middle C# 277.18Hz, Middle-Right(?) C# 554.37Hz.

                    // The "angle" used in the function, adjusted for the number of channels and sample rate.
                    // This value is like the period of the wave.
                    double t = (Math.PI * 2 * freq) / (format.dwSamplesPerSec * format.wChannels);

                    for (uint i = 0; i < numSamples - 1; i++)
                    {
                        for (int channel = 0; channel < format.wChannels; channel++)
                        {
                            data.shortArray[i + channel] = Convert.ToInt16(amplitude * Math.Sin(t * i));
                        }
                    } 
                    // Calculate data chunk size in bytes.
                    // The data chunk needs the bitrate which is stored in the format chunk,
                    // so this needs to be set manually.
                    data.dwChunkSize = (uint)(data.shortArray.Length * (format.wBitsPerSample / 8));
                    break;
                case WaveExampleType.NaiveApproach:
                    // Number of samples = sample rate * channels
                    uint nNumSamples = format.dwSamplesPerSec * format.wChannels;

                    // Initialize the 16-bit array
                    // Ensures dataSize is divisible by nNumSamples.
                    int dataSize = waveData.Length + (int)nNumSamples - (waveData.Length % (int)nNumSamples);
                    data.shortArray = new short[dataSize];

                    int nAmplitude = 32760;  // Max amplitude for 16-bit audio
                    double nFreq = 277.18f;   // Concert A: 440Hz, Middle C# 277.18Hz, Middle-Right(?) C# 554.37Hz.

                    // The "angle" used in the function, adjusted for the number of channels and sample rate.
                    // This value is like the period of the wave.
                    double ti = (Math.PI * 2 * nFreq) / (format.dwSamplesPerSec * format.wChannels);

                    for (uint i = 0; i < waveData.Length - 3; i += 3)
                    {
                        data.shortArray[i] = Convert.ToInt16(nAmplitude * Math.Sin(waveData[i]));
                        data.shortArray[i + 1] = Convert.ToInt16(nAmplitude * Math.Sin(waveData[i + 1]));
                        data.shortArray[i + 2] = Convert.ToInt16(nAmplitude * Math.Sin(waveData[i + 2]));
                    }
                    // Calculate data chunk size in bytes.
                    // The data chunk needs the bitrate which is stored in the format chunk,
                    // so this needs to be set manually.
                    data.dwChunkSize = (uint)(data.shortArray.Length * (format.wBitsPerSample / 8));
                    break;
            }
        }

        public void saveWave(string filePath)
        {
            // Create a file (it always overwrites)
            FileStream fileStream = new FileStream(filePath, FileMode.Create);

            // Use BinaryWriter to write the bytes to the file.
            // Note: Wave files are saved in uncompressed binary values.
            BinaryWriter writer = new BinaryWriter(fileStream);

            // The order in which the values are written is extremely important.

            // Write the header:
            // .ToCharArray() converts the strings and eliminates the end-of-string characters which
            // would otherwise corrupt the headers.
            writer.Write(header.sGroupId.ToCharArray());        // "RIFF"
            writer.Write(header.dwFileLength);
            writer.Write(header.sRiffType.ToCharArray());       // "WAVE"

            // Write the format chunk:
            writer.Write(format.sChunkID.ToCharArray());        // "fmt "
            writer.Write(format.dwChunkSize);
            writer.Write(format.wFormatTag);
            writer.Write(format.wChannels);
            writer.Write(format.dwSamplesPerSec);
            writer.Write(format.dwAvgBytesPerSec);
            writer.Write(format.wBlockAlign);
            writer.Write(format.wBitsPerSample);

            // Write the data chunk:
            writer.Write(data.sChunkID.ToCharArray());
            writer.Write(data.dwChunkSize);
            foreach(short dataPoint in data.shortArray)
            {
                writer.Write(dataPoint);
            }

            // Now that we know the length of the file, we go back and specify it as the 
            // second value in the file. The first 4 bytes of the file are taken up by
            // "RIFF". It is -8 because we don't count RIFF or WAVE.
            writer.Seek(4, SeekOrigin.Begin);
            uint fileSize = (uint)writer.BaseStream.Length;
            writer.Write(fileSize - 8);

            // Close out:
            writer.Close();
            fileStream.Close();
        }
    }
}
