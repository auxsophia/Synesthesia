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
    Decrypt = 0,
}

namespace synesthesia
{
    public class WaveGenerator
    {
        public WaveHeader header;
        public WaveFormatChunk format;
        public WaveDataChunk data;

        // Function overloaded
        public WaveGenerator(WaveExampleType type, List<short> waveData, uint samplesPerSec)
        {
            // Initialize chunks:
            short shor = 1;
            header = new WaveHeader();
            format = new WaveFormatChunk(shor);
            data = new WaveDataChunk(shor);

            // Number of samples = sample rate * channels
            format.dwSamplesPerSec = samplesPerSec;
            uint nNumSamples = format.dwSamplesPerSec * format.wChannels;

            // Initialize the 16-bit array
            // Ensures dataSize is divisible by nNumSamples.
            int dataSize = waveData.Count + (int)nNumSamples - (waveData.Count % (int)nNumSamples);
            data.shortArray = new short[dataSize];

            // Copy the data
            for (int i = 0; i < data.shortArray.Length; i++)
            {
                if (i < waveData.Count)
                    data.shortArray[i] = waveData[i];
                else
                    data.shortArray[i] = 0;
            }

            // Calculate data chunk size in bytes.
            // The data chunk needs the bitrate which is stored in the format chunk,
            // so this needs to be set manually.
            data.dwChunkSize = (uint)(data.shortArray.Length * (format.wBitsPerSample / 8));
        }

        // Function overloaded
        public WaveGenerator(WaveExampleType type, List<byte> waveData, uint samplesPerSec)
        {
            // Initialize chunks:
            byte bite = 1;
            header = new WaveHeader();
            format = new WaveFormatChunk(bite);
            data = new WaveDataChunk(bite);

            // Number of samples = sample rate * channels
            format.dwSamplesPerSec = samplesPerSec;
            uint nNumSamples = format.dwSamplesPerSec * format.wChannels;

            // Initialize the 16-bit array
            // Ensures dataSize is divisible by nNumSamples.
            int dataSize = waveData.Count + (int)nNumSamples - (waveData.Count % (int)nNumSamples);
            data.byteArray = new byte [dataSize];

            // Copy the data
            for (int i = 0; i < data.byteArray.Length; i++)
            {
                if (i < waveData.Count)
                    data.byteArray[i] = waveData[i];
                else
                    data.byteArray[i] = 0;
            }

            // Calculate data chunk size in bytes.
            // The data chunk needs the bitrate which is stored in the format chunk,
            // so this needs to be set manually.
            data.dwChunkSize = (uint)(data.byteArray.Length * (format.wBitsPerSample / 8));
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

            if (16 == format.wBitsPerSample)
            {
                foreach (short dataPoint in data.shortArray)
                {
                    writer.Write(dataPoint);
                }
            }

            if (8 == format.wBitsPerSample)
            {
                foreach (byte dataPoint in data.byteArray)
                {
                    writer.Write(dataPoint);
                }
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
