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

        public Form1()
        {
            InitializeComponent();
            imageLoaded = false;
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
            string filePath = @"C:\Users\onlyo\Music\Synesthesia\test.wave";
            WaveGenerator wave = new WaveGenerator(WaveExampleType.ExampleSineWave);
            wave.saveWave(filePath);

            SoundPlayer player = new SoundPlayer(filePath);
            MessageBox.Show("Play sound:");
            player.Play();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
