using System;

namespace synesthesia
{
    public class WaveHeader
    {
        public string sGroupId;     // RIFF (Resource Interchange File Format)
        public uint dwFileLength;   // Total file length minus 8 for Riff.
        public string sRiffType;    // Note: Always WAVE for wave files.

        public WaveHeader()
        {
            sGroupId = "RIFF";
            dwFileLength = 0;
            sRiffType = "WAVE";
        }
    }

    public class WaveFormatChunk
    {
        public string sChunkID;         // Four bytes: "fmt ".
        public uint dwChunkSize;        // Length of the header in bytes.
        public ushort wFormatTag;       // 1 (MS PCM)
        public ushort wChannels;        // Number of channels (3 in our case for RGB).
        public uint dwSamplesPerSec;    // Frequency of the audio in Hz, our standard will be 44.1k.
        public uint dwAvgBytesPerSec;   // For estimating RAM allocation
        public ushort wBlockAlign;      // Sample frame size in bytes.
        public ushort wBitsPerSample;   // Bits per sample.

        public WaveFormatChunk()
        {
            sChunkID = "fmt ";
            dwChunkSize = 16;
            wFormatTag = 1;
            wChannels = 1;
            dwSamplesPerSec = 44100;                    // 44.1k is the standard for CD's. We'll use 20k.
            wBitsPerSample = 16;
            wBlockAlign = (ushort)(wChannels * (wBitsPerSample / 8));
            dwAvgBytesPerSec = dwSamplesPerSec * wBlockAlign;   // Should this be also * wBitsPerSample / 8?
        }
    }

    public class WaveDataChunk
    {
        public string sChunkID;     // "data"
        public uint dwChunkSize;    // Length of the header in bytes.
        public short[] shortArray;  // Short, because we are using shorts. If we wanted 8-bit, byte.
                                    // 32 bit would be int.
        public WaveDataChunk()
        {
            sChunkID = "data";
            dwChunkSize = 0;
            shortArray = new short[0];
        }
    }
}