using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace synesthesia
{
    public partial class Encrypted : Form
    {
        private string fileName;        // User defined.

        public Encrypted(Bitmap encryptedImage)
        {
            InitializeComponent();
            fileName = "";

            // Convert pixel format
            encryptedImage = encryptedImage.Clone(new Rectangle(0, 0, encryptedImage.Width, encryptedImage.Height), PixelFormat.Format32bppArgb);

            encryptedImageBox.Image = encryptedImage;
            encryptedImageBox.Size = encryptedImage.Size;

            // Resize window
            int newWidth = Math.Max(this.PreferredSize.Width, 305);
            int newHeight = this.PreferredSize.Height;
            newWidth = Math.Min(newWidth, Screen.PrimaryScreen.Bounds.Width * 2 / 3);
            newHeight = Math.Min(newHeight, Screen.PrimaryScreen.Bounds.Height * 2 / 3);
            this.Size = new Size(newWidth, newHeight);

            // Enable buttons
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                    c.Enabled = true;
            }
        }

        private void saveImage_Click(object sender, EventArgs e)
        {
            try
            {
                (encryptedImageBox.Image).Save("C:\\Users\\onlyo\\OneDrive\\Pictures\\SeniorDesign\\" + fileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
                MessageBox.Show("Image saved to C:\\Users\\onlyo\\OneDrive\\Pictures\\SeniorDesign\\");
            }
            catch
            {
                MessageBox.Show("Cannot save with the current file name or the directory is invalid.");
            }
        }

        private void fileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            fileName = fileNameTextBox.Text;
        }

        private void decodePlay_Click(object sender, EventArgs e)
        {
            // Decode the data.

            // Get the dataSize which is in the first 11 pixels (32 / 3 = 10.67).
            int dataSize = 0;
            byte zero = 1;
            int bitShift = 31;
            for (int i = 0, j = 0; j < 11; j++)
            {
                Color color = ((Bitmap)(encryptedImageBox.Image)).GetPixel(i, j);
                dataSize += ((color.R & zero) << bitShift);
                bitShift--;

                dataSize += ((color.G & zero) << bitShift);
                bitShift--;

                if (11 != j)
                {
                    dataSize += ((color.B & zero) << bitShift);
                    bitShift--;
                }
            }

            if (dataSize > (encryptedImageBox.Width * encryptedImageBox.Height) || dataSize < 128)
            {
                MessageBox.Show("WARNING: It is likely the image is not encrypted or has been corrupted.");
            }

            // Get the sample rate.
            int sampleRate = 0;
            bitShift = 31;
            for (int i = 0, j = 10; j < 22; j++)
            {
                Color color = ((Bitmap)(encryptedImageBox.Image)).GetPixel(i, j);
                if (10 == j)
                {
                    sampleRate = ((color.B & zero) << bitShift);
                    bitShift--;
                }
                else if (21 == j)
                {
                    sampleRate += ((color.R & zero) << bitShift);
                    bitShift--;
                }
                else
                {
                    sampleRate += ((color.R & zero) << bitShift);
                    bitShift--;
                    sampleRate += ((color.G & zero) << bitShift);
                    bitShift--;
                    sampleRate += ((color.B & zero) << bitShift);
                    bitShift--;
                }
            }

            // Get the average bytes per second.
            int fmtAvgBPS = 0;
            bitShift = 31;
            for (int i = 0, j = 21; j < 32; j++)
            {
                Color color = ((Bitmap)(encryptedImageBox.Image)).GetPixel(i, j);
                if (21 == j)
                {
                    fmtAvgBPS = ((color.G & zero) << bitShift);
                    bitShift--;
                    fmtAvgBPS = ((color.B & zero) << bitShift);
                    bitShift--;
                }
                else
                {
                    fmtAvgBPS += ((color.R & zero) << bitShift);
                    bitShift--;
                    fmtAvgBPS += ((color.G & zero) << bitShift);
                    bitShift--;
                    fmtAvgBPS += ((color.B & zero) << bitShift);
                    bitShift--;
                }
            }

            // Get the block align.
            int blockAlign = 0;
            bitShift = 15;
            for (int i = 0, j = 32; j < 38; j++)
            {
                Color color = ((Bitmap)(encryptedImageBox.Image)).GetPixel(i, j);
                blockAlign += ((color.R & zero) << bitShift);
                bitShift--;

                if (37 != j)
                {
                    blockAlign += ((color.G & zero) << bitShift);
                    bitShift--;

                    blockAlign += ((color.B & zero) << bitShift);
                    bitShift--;
                }
            }

            // Get the bit depth.
            int bitDepth = 0;
            bitShift = 15;
            for (int i = 0, j = 37; j < 43; j++)
            {
                Color color = ((Bitmap)(encryptedImageBox.Image)).GetPixel(i, j);

                if (37 == j)
                {
                    bitDepth += ((color.G & zero) << bitShift);
                    bitShift--;

                    bitDepth += ((color.B & zero) << bitShift);
                    bitShift--;
                }
                else if (42 == j)
                {
                    bitDepth += ((color.R & zero) << bitShift);
                    bitShift--;

                    bitDepth += ((color.G & zero) << bitShift);
                    bitShift--;
                }
                else
                {
                    bitDepth += ((color.R & zero) << bitShift);
                    bitShift--;

                    bitDepth += ((color.G & zero) << bitShift);
                    bitShift--;

                    bitDepth += ((color.B & zero) << bitShift);
                    bitShift--;
                }
            }

            // Grab the first value, which is the most significant bit.
            // Bit shift it to the leftmost byte position, and store it into the data array.
            // Subtract one from the bit shift counter (meaning divide it by 2).
            // If the counter is zero, reset to leftmost bit = 1.

            if (16 == bitDepth)
            {
                List<short> waveData = new List<short>();
                waveData.Add(0);
                int shift = 15;
                int wavIndex = 0;
                dataSize /= 2;      // Divide by two for shorts.
                for (int i = 0; i < encryptedImageBox.Image.Width; i++)
                {
                    for (int j = 0; j < encryptedImageBox.Image.Height && wavIndex != dataSize; j++)
                    {
                        Color pixel = ((Bitmap)(encryptedImageBox.Image)).GetPixel(i, j);

                        if (0 == i && 0 == j)
                        {   // Get the first bit of data, not the header information.
                            j = 42;
                            waveData[wavIndex] += (short)((pixel.B & zero) << shift);
                            shift--;
                        }
                        else
                        {
                            waveData[wavIndex] += (short)((pixel.R & zero) << shift);
                            shift--;
                            if (-1 == shift)
                            {
                                waveData.Add(0);
                                wavIndex++;
                                shift = 15;
                            }

                            waveData[wavIndex] += (short)((pixel.G & zero) << shift);
                            shift--;
                            if (-1 == shift)
                            {
                                waveData.Add(0);
                                wavIndex++;
                                shift = 15;
                            }

                            waveData[wavIndex] += (short)((pixel.B & zero) << shift);
                            shift--;
                            if (-1 == shift)
                            {
                                waveData.Add(0);
                                wavIndex++;
                                shift = 15;
                            }
                        }
                    }
                }

                // Create the .wav file.
                string filePath16 = @"C:\Users\onlyo\OneDrive\Pictures\SeniorDesign\tempWavs\temp.wav";
                WaveGenerator wave = new WaveGenerator(WaveExampleType.Decrypt, waveData);
                wave.format.dwSamplesPerSec = (uint)sampleRate;
                wave.format.dwAvgBytesPerSec = (uint)fmtAvgBPS;
                wave.format.wBlockAlign = (ushort)blockAlign;
                wave.format.wBitsPerSample = (ushort)bitDepth;
                wave.saveWave(filePath16);
            }
            else if (8 == bitDepth)
            {
                List<byte> waveData = new List<byte>();
                waveData.Add(0);
                int shift = 7;
                int wavIndex = 0;
                for (int i = 0; i < encryptedImageBox.Image.Width; i++)
                {
                    for (int j = 0; j < encryptedImageBox.Image.Height && wavIndex != dataSize; j++)
                    {
                        Color pixel = ((Bitmap)(encryptedImageBox.Image)).GetPixel(i, j);

                        if (0 == i && 0 == j)
                        {   // Get the first bit of data, not the header information.
                            j = 42;
                            waveData[wavIndex] += (byte)((pixel.B & zero) << shift);
                            shift--;
                        }
                        else
                        {
                            waveData[wavIndex] += (byte)((pixel.R & zero) << shift);
                            shift--;
                            if (-1 == shift)
                            {
                                waveData.Add(0);
                                wavIndex++;
                                shift = 7;
                            }

                            waveData[wavIndex] += (byte)((pixel.G & zero) << shift);
                            shift--;
                            if (-1 == shift)
                            {
                                waveData.Add(0);
                                wavIndex++;
                                shift = 7;
                            }

                            waveData[wavIndex] += (byte)((pixel.B & zero) << shift);
                            shift--;
                            if (-1 == shift)
                            {
                                waveData.Add(0);
                                wavIndex++;
                                shift = 7;
                            }
                        }
                    }
                }

                // Create the .wav file.
                string filePath8 = @"C:\Users\onlyo\OneDrive\Pictures\SeniorDesign\tempWavs\temp.wav";
                WaveGenerator wave = new WaveGenerator(WaveExampleType.Decrypt, waveData);
                wave.format.dwSamplesPerSec = (uint)sampleRate;
                wave.format.dwAvgBytesPerSec = (uint)fmtAvgBPS;
                wave.format.wBlockAlign = (ushort)blockAlign;
                wave.format.wBitsPerSample = (ushort)bitDepth;
                wave.saveWave(filePath8);
            }
            else
            {
                MessageBox.Show("Terminating: Unencrypted or corrupted image. Bits per sample: " + bitDepth);
                return;
            }

            string filePath = @"C:\Users\onlyo\OneDrive\Pictures\SeniorDesign\tempWavs\temp.wav";

            // Play the sound.
            SoundPlayer player = new SoundPlayer(filePath);
            player.Play();
        }
    }
}
