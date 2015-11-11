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

    // Added for WAVEFORMATEXTENSIBLE
    /*public enum WavChannelMask
    {
        SPEAKER_FRONT_LEFT = 0x1,
        SPEAKER_FRONT_RIGHT = 0x2,
        SPEAKER_FRONT_CENTER = 0x4
    }*/

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
        /*public ushort cbSize;   // Added for WAVEFORMATEXTENSIBLE
        public ushort Samples;  // Added for WAVEFORMATEXTENSIBLE
        public ushort extraParamSize; // Added for WAVEFORMATEXTENSIBLE
        public Guid subTypePCM;
        public uint dwChannelMask;*/
        /*
            Note on dwChannelMask, it looks at the least significant bit and onward.
            Left is 1, Right is 2, Center is 4. So using all 3 would be having all 
            these bits turned on, thus dwChannelMask = 7.
        */

        public WaveFormatChunk()
        {
            sChunkID = "fmt ";
            dwChunkSize = 16;            // 16 for PCM, 40 for WAVEFORMATEXTENSIBLE
            wFormatTag = 1;         // 1; 40 for regular PCM/non-WAVEFORMATEXTENSIBLE
            wChannels = 1;
            dwSamplesPerSec = 44100;
            wBitsPerSample = 16;
            wBlockAlign = (ushort)(wChannels * (wBitsPerSample / 8));
            dwAvgBytesPerSec = dwSamplesPerSec * wBlockAlign;   // Should this be also * wBitsPerSample / 8?
            /*cbSize = 22;
            Samples = 16;               // The precision of bits that have data (all of them).
            extraParamSize = 22;
            dwChannelMask = 0x7;
            subTypePCM = new Guid("00000001-0000-0010-8000-00aa00389b71");*/
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