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
                // Store the RGB values into a one dimensional array.
                // f(x) = (x - 128) * 256
                // f(x) gives us a range of (-32,768, 32,512) where x is a pixel RGB value.
                // The range of a short is (–32,768, 32,767).
                short[] waveData = new short[originalImage.Width * originalImage.Height * 3];
                for (int i = 0; i < originalImage.Width; i++)
                {
                    for (int j = 0; j < originalImage.Height; j++)
                    {
                        Color pixel = originalImage.GetPixel(i, j);
                        waveData[(originalImage.Height * i) + j]     = (short)((pixel.R - 128) * 256);
                        waveData[(originalImage.Height * i) + j + 1] = (short)((pixel.G - 128) * 256);
                        waveData[(originalImage.Height * i) + j + 2] = (short)((pixel.B - 128) * 256);
                    }
                }

                string filePath = @"C:\Users\onlyo\Music\Synesthesia\test.wav";
                wave = new WaveGenerator(WaveExampleType.NaiveApproach, waveData);
                wave.saveWave(filePath);

                filePath = @"C:\Users\onlyo\Music\Sounds\hal.wav";
                SoundPlayer player = new SoundPlayer(filePath);
                MessageBox.Show("Play sound:");
                player.Play();
            }
            else
            {
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
            SoundPlayer player = new SoundPlayer(@wavPath);
            //MessageBox.Show("Play sound:");
            player.Play();
        }

        private void encodeImage_Click(object sender, EventArgs e)
        {
            if (imageLoaded && wavLoaded)
            {
                // Get the entire wav file in bytes.
                byte[] wav = File.ReadAllBytes(wavPath);

                // Determine if mono channel, break otherwise.
                int channels = wav[22];

                if (1 != channels)
                {
                    MessageBox.Show("Wave files can only have mono (1 channel) sound.");
                    return;
                }

                // Get past all the other sub chunks to get to the data subchunk:
                int pos = 12;   // First Subchunk ID from 12 to 16

                // Keep iterating until we find the data chunk (i.e. 64 61 74 61)
                while (!(wav[pos] == 100 && wav[pos + 1] == 97 && wav[pos + 2] == 116 && wav[pos + 3] == 97))
                {
                    pos += 4;
                    int chunkSize = wav[pos] + wav[pos + 1] * 256 + wav[pos + 2] * 65536 + wav[pos + 3] * 16777216;
                    pos += 4 + chunkSize;
                }
                pos += 8;

                // Pos is now positioned to start of actual sound data.
                int samples = (wav.Length - pos) / 2;     // 2 bytes per sample (16 bit sound mono)
                int leastSigBits = (originalImage.Width - 1) * (originalImage.Height - 1) * 3;

                MessageBox.Show("This file is " + samples * 16 + " bits long in data, and " + leastSigBits + " can be stored in the image.");

                // Begin encryption.

                // Get each bit value for storage.
                byte[] wavBits = new byte[(wav.Length - pos) * 8];

                // 0000 0000, 0000 0001, 0000 0010, 0000 0100, 0000 1000.
                byte nil = 0;
                byte zero = 1;
                byte one = 2;
                byte two = 4;
                byte three = 8;
                byte four = 16;
                byte five = 32;
                byte six = 64;
                byte seven = 128;

                for (int i = 0, j = pos; j < wav.Length; i++, j++)
                {
                    // Store each value (0 or 1) for each byte starting from the most significant bit.
                    wavBits[i * 8 + 7] = ((wav[j] & zero) == nil) ? nil : zero;
                    wavBits[i * 8 + 6] = ((wav[j] & one) == nil) ? nil : zero;
                    wavBits[i * 8 + 5] = ((wav[j] & two) == nil) ? nil : zero;
                    wavBits[i * 8 + 4] = ((wav[j] & three) == nil) ? nil : zero;
                    wavBits[i * 8 + 3] = ((wav[j] & four) == nil) ? nil : zero;
                    wavBits[i * 8 + 2] = ((wav[j] & five) == nil) ? nil : zero;
                    wavBits[i * 8 + 1] = ((wav[j] & six) == nil) ? nil : zero;
                    wavBits[i * 8    ] = ((wav[j] & seven) == nil) ? nil : zero;
                }

                // Now encode each bit into the encrypted image.
                Bitmap encrypted = new Bitmap(originalImage);

                // New encrypted RGB:
                int red;
                int green;
                int blue;
                bool done = false;
                for (int i = 0; (i < originalImage.Width) && !done; i++)
                {
                    for (int j = 0; j < originalImage.Height; j++)
                    {
                        if ((i * originalImage.Height + j) < wavBits.Length)
                        {

                            Color color = originalImage.GetPixel(i, j);

                            // Red
                            if ((color.R ^ wavBits[i * originalImage.Height + j]) % 2 == 0)
                            {  // No change needed.
                                red = color.R;
                            }
                            else
                            {
                                if (wavBits[i * originalImage.Height + j] == zero)
                                    red = color.R + 1;
                                else
                                    red = color.R - 1;
                            }

                            // Green
                            if ((color.G ^ wavBits[i * originalImage.Height + j]) % 2 == 0)
                            {  // No change needed.
                                green = color.G;
                            }
                            else
                            {
                                if (wavBits[i * originalImage.Height + j] == zero)
                                    green = color.G + 1;
                                else
                                    green = color.G - 1;
                            }

                            // Blue
                            if ((color.B ^ wavBits[i * originalImage.Height + j]) % 2 == 0)
                            {  // No change needed.
                                blue = color.B;
                            }
                            else
                            {
                                if (wavBits[i * originalImage.Height + j] == zero)
                                    blue = color.B + 1;
                                else
                                    blue = color.B - 1;
                            }

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
