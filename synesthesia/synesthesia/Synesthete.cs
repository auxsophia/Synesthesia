/*
Author: Elliott Ploutz
Email: ploutze@unlv.nevada.edu

This program accepts an image and transforms it into a sound file.

All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Media;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace synesthesia
{
    public partial class Synesthete : Form
    {
        private Bitmap originalImage;
        private bool imageLoaded;
        private bool wavLoaded;
        private string fileName;            // Stores input from the user to give the wave file a title.
        private string wavPath;             // Stores the .wav file path.
        private WaveGenerator wave;         // Sound object.

        public Synesthete()
        {
            InitializeComponent();
            imageLoaded = false;
            wavLoaded = false;
            fileName = "";
        }

        private void loadImage_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files(*.jpg;*.jpeg; *.gif; *.bmp; *.png;)|*.jpg;*.jpeg; *.gif; *.bmp; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    originalImage = new Bitmap(openFileDialog.FileName);
                    imageLoaded = true;

                    // Convert pixel format
                    originalImage = originalImage.Clone(new Rectangle(0, 0, originalImage.Width, originalImage.Height), PixelFormat.Format32bppArgb);

                    pictureDisplay.Image = originalImage;
                    pictureDisplay.Size = originalImage.Size;

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
                catch
                {
                    MessageBox.Show("Can't open file.");
                }
            }
        }

        private void wavFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files(*.wav)|*.wav";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                wavPath = openFileDialog.FileName;
                wavLoaded = true;
            }
            else
            {
                MessageBox.Show("Please load a .wav file.");
            }
        }

        private void waveGenerator_Click(object sender, EventArgs e)
        {
            if (imageLoaded)
            {
                string filePath = @"C:\Users\onlyo\Music\Synesthesia\test.wav";

                SoundPlayer player = new SoundPlayer(filePath);
                MessageBox.Show("Play sound:");
                player.Play();
            }
            else
            {
                int test = 11025;
                test = test << 3;
                MessageBox.Show("" + test);
                MessageBox.Show("Please load an image.");
            }
        }

        private void pictureDisplay_Click(object sender, EventArgs e)
        {
            if (imageLoaded)
            {
                // Get mouse coordinates relative to the pictureBox.
                MouseEventArgs me = (MouseEventArgs)e;
                int x = me.Location.X; 
                int y = me.Location.Y;

                Color pixel = originalImage.GetPixel(x, y);
                DRGBNcolors color = new DRGBNcolors();
                color.findColor(pixel.R, pixel.G, pixel.B, this.Location.X + this.pictureDisplay.Location.X + x,
                    this.Location.Y + this.pictureDisplay.Location.Y + y);
            }
        }

        private void pictureDisplay_MouseMove(object sender, EventArgs e)
        {
            if (imageLoaded)
            {
                // Get mouse coordinates relative to the pictureBox.
                MouseEventArgs me = (MouseEventArgs)e;
                int x = me.Location.X;
                int y = me.Location.Y;

                Color pixel = originalImage.GetPixel(x, y);
                DRGBNcolors color = new DRGBNcolors();

                Bitmap pixelImage = new Bitmap(20, 20);

                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        pixelImage.SetPixel(i, j, pixel);
                    }
                }

                pixelBox.Image = pixelImage;

                Point m = new Point(this.pictureDisplay.Location.X + x + 1, this.pictureDisplay.Location.Y + y + 1);
                pixelBox.Location = m;

                pixelBox.Visible = true;
            }
        }

        private void pictureDisplay_MouseLeave(object sender, EventArgs e)
        {
            pixelBox.Visible = false;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playLoadedWav_Click(object sender, EventArgs e)
        {
            if (null != wavPath)
            {
                SoundPlayer player = new SoundPlayer(@wavPath);
                //MessageBox.Show("Play sound:");
                player.Play();
            }
            else
            {
                MessageBox.Show("Please load a .wav file.");
            }
        }

        private void encodeImage_Click(object sender, EventArgs e)
        {
            if (imageLoaded && wavLoaded)
            {
                System.IO.Stream waveFile = new System.IO.FileStream(@wavPath, System.IO.FileMode.Open);
                BinaryReader reader = new BinaryReader(waveFile);

                int chunkID = reader.ReadInt32();
                int fileSize = reader.ReadInt32();
                int riffType = reader.ReadInt32();
                int fmtID = reader.ReadInt32();
                int fmtSize = reader.ReadInt32();
                int fmtCode = reader.ReadInt16();
                int channels = reader.ReadInt16();
                int sampleRate = reader.ReadInt32();        // Will be written to the image (4 bytes)
                int fmtAvgBPS = reader.ReadInt32();         // Will be written to the image (4 bytes)
                int fmtBlockAlign = reader.ReadInt16();     // Will be written to the image (2 bytes)
                int bitDepth = reader.ReadInt16();          // Will be written to the image (2 bytes)

                if (channels != 1)
                {
                    MessageBox.Show("Only mono (single channel) sound is supported at this time.");
                    return;
                }

                if (fmtSize == 18)
                {
                    // Read any extra values
                    int fmtExtraSize = reader.ReadInt16();
                    reader.ReadBytes(fmtExtraSize);
                }

                int dataID = reader.ReadInt32();
                int dataSize = reader.ReadInt32();              // Will be written to the image (4 bytes)

                byte[] wav = reader.ReadBytes(dataSize);

                int numOfBits = (wav.Length - 1) * 8 + 128;     // 128 = 16 bytes of header information.
                int leastSigBits = (originalImage.Width - 1) * (originalImage.Height - 1) * 3;

                if (numOfBits > leastSigBits)
                {
                    MessageBox.Show("This file is " + numOfBits + " bits long in data, and " + leastSigBits + 
                        " can be stored in the image.\n" + "Your .wav file will be truncated.");
                    numOfBits = leastSigBits;
                    dataSize = leastSigBits;
                }

                // Begin encryption.

                // Comparison bytes.
                // 0000 0000, 0000 0001
                byte nil = 0;
                byte zero = 1;

                // Get each bit value for storage.
                byte[] wavBits = new byte[numOfBits];

                // Encode the header information.
                uint bitIsolate = 2147483648; // 1000 0000 0000 0000 0000 0000 0000 0000
                int wavBitsIndex = 0;
                while (bitIsolate != 0)
                {
                    wavBits[wavBitsIndex] = ((dataSize & bitIsolate) == nil) ? nil : zero;
                    wavBitsIndex++;
                    bitIsolate /= 2;    // Gets to the next most significant bit.
                }

                // Store the sampleRate.
                bitIsolate = 2147483648;
                while (bitIsolate != 0)
                {
                    wavBits[wavBitsIndex] = ((sampleRate & bitIsolate) == nil) ? nil : zero;
                    wavBitsIndex++;
                    bitIsolate /= 2;    // Gets to the next most significant bit.
                }

                // Store the fmtAvgBPS.
                bitIsolate = 2147483648;
                while (bitIsolate != 0)
                {
                    wavBits[wavBitsIndex] = ((fmtAvgBPS & bitIsolate) == nil) ? nil : zero;
                    wavBitsIndex++;
                    bitIsolate /= 2;    // Gets to the next most significant bit.
                }

                // Store the fmtBlockAlign (2 bytes).
                bitIsolate = 32768;
                while (bitIsolate != 0)
                {
                    wavBits[wavBitsIndex] = ((fmtBlockAlign & bitIsolate) == nil) ? nil : zero;
                    wavBitsIndex++;
                    bitIsolate /= 2;    // Gets to the next most significant bit.
                }

                // Store the bitDepth (2 bytes).
                bitIsolate = 32768;
                while (bitIsolate != 0)
                {
                    wavBits[wavBitsIndex] = ((bitDepth & bitIsolate) == nil) ? nil : zero;
                    wavBitsIndex++;
                    bitIsolate /= 2;    // Gets to the next most significant bit.
                }

                // Encode the wave data.
                bitIsolate = 128;
                for (int i = 0; wavBitsIndex < wavBits.Length; wavBitsIndex++)
                {
                    // Store each value (0 or 1) for each byte starting from the most significant bit.
                    wavBits[wavBitsIndex] = ((wav[i] & bitIsolate) == nil) ? nil : zero;
                    bitIsolate /= 2;
                    if (0 == bitIsolate)
                    {
                        bitIsolate = 128;
                        i++;
                    }
                }

                // Now encode each bit into the encrypted image.
                Bitmap encrypted = new Bitmap(originalImage);

                // New encrypted RGB:
                int red;
                int green;
                int blue;
                int k = 0;
                for (int i = 0; i < originalImage.Width; i++)
                {
                    for (int j = 0; j < originalImage.Height; j++)
                    {
                        // It's before the end of the wav data and before the last 3 pixels of the image.
                        if (k + 3 < wavBits.Length)
                        {

                            Color color = originalImage.GetPixel(i, j);

                            // Red
                            if ((color.R ^ wavBits[k]) % 2 == 0)
                            {  // No change needed.
                                red = color.R;
                            }
                            else
                            {
                                if (wavBits[k] == zero)
                                    red = color.R + 1;
                                else
                                    red = color.R - 1;
                            }

                            k++;
                            // Green
                            if ((color.G ^ wavBits[k]) % 2 == 0)
                            {  // No change needed.
                                green = color.G;
                            }
                            else
                            {
                                if (wavBits[k] == zero)
                                    green = color.G + 1;
                                else
                                    green = color.G - 1;
                            }

                            k++;
                            // Blue
                            if ((color.B ^ wavBits[k]) % 2 == 0)
                            {  // No change needed.
                                blue = color.B;
                            }
                            else
                            {
                                if (wavBits[k] == zero)
                                    blue = color.B + 1;
                                else
                                    blue = color.B - 1;
                            }
                            k++;

                            Color encrypColor = Color.FromArgb(red, green, blue);
                            encrypted.SetPixel(i, j, encrypColor);
                        }
                        else
                        {   // Copy original pixel unchanged.
                            encrypted.SetPixel(i, j, originalImage.GetPixel(i, j));
                        }
                    }
                }

                // Open the image in a new form.
                Form encryptForm = new Encrypted(encrypted);
                encryptForm.Show();
            }
            else
            {
                MessageBox.Show("Please load an image and .wav file");
            }
        }
    }
}
