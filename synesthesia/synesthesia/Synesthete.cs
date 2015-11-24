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

namespace synesthesia
{
    public partial class Synesthete : Form
    {
        private Bitmap originalImage;
        private bool imageLoaded;
        private string fileName;            // Stores input from the user to give the wave file a title.
        private Graphics graphic;           // Used for wave display.
        private Bitmap graph;               // Used for wave display.
        private uint waveWindow;            // Adjusts the viewing screen of the wave display.
        private WaveGenerator wave;         // Sound object.

        public Synesthete()
        {
            InitializeComponent();
            imageLoaded = false;
            fileName = "";
            waveWindow = 0;
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
                        waveData[(originalImage.Height * i) + j]     = (short)((pixel.R - 128) * 256);
                        waveData[(originalImage.Height * i) + j + 1] = (short)((pixel.G - 128) * 256);
                        waveData[(originalImage.Height * i) + j + 2] = (short)((pixel.B - 128) * 256);
                    }
                }

                string filePath = @"C:\Users\onlyo\Music\Synesthesia\test.wav";
                wave = new WaveGenerator(WaveExampleType.NaiveApproach, waveData);
                wave.saveWave(filePath);

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

    }
}
