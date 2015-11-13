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

namespace synesthesia
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private bool imageLoaded;
        private string fileName;

        public Form1()
        {
            InitializeComponent();
            imageLoaded = false;
            fileName = "";
        }

        private void loadImage_Click(object sender, EventArgs e)
        {
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
                        waveData[(originalImage.Height * i) + j] = (short)((pixel.B - 128) * 256);
                        waveData[(originalImage.Height * i) + j + 1] = (short)((pixel.G - 128) * 256);
                        waveData[(originalImage.Height * i) + j + 2] = (short)((pixel.B - 128) * 256);
                    }
                }

                string filePath = @"C:\Users\onlyo\Music\Synesthesia\test.wav";
                WaveGenerator wave = new WaveGenerator(WaveExampleType.NaiveApproach, waveData);
                wave.saveWave(filePath);

                SoundPlayer player = new SoundPlayer(filePath);
                MessageBox.Show("Play sound:");
                player.Play();
                //MessageBox.Show("Done!");
            }
            else
            {
                MessageBox.Show("Please load an image.");
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
