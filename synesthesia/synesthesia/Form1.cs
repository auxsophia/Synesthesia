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
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private bool imageLoaded;
        private string fileName;            // Stores input from the user to give the wave file a title.
        private Graphics graphic;           // Used for wave display.
        private Bitmap graph;               // Used for wave display.
        private uint waveWindow;            // Adjusts the viewing screen of the wave display.
        private WaveGenerator wave;         // Sound object.


        public Form1()
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
                    this.timer.Enabled = false;

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

                // Initiate wave graph.
                this.timer.Enabled = true;
                this.timer.Interval = 10;
                this.timer.Tick += new EventHandler(timer_Tick);
                this.ResumeLayout(false);
                this.waveGraph.Paint += new PaintEventHandler(waveGraph_Paint);

            }
            else
            {
                MessageBox.Show("Please load an image.");
            }
        }

        private void waveGraph_Paint(object sender, PaintEventArgs e)
        {
            if (graph == null)
            {
                graph = new Bitmap(this.waveGraph.Width, this.waveGraph.Height);
                graphic = Graphics.FromImage(graph);
                graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.GammaCorrected;
                graphic.Clear(Color.White);
            }
            Render();
            e.Graphics.DrawImage(graph, 0, 0);
        }

        private void Render()
        {
            graphic.Clear(Color.White);
            float rY0 = 0;
            int rX0 = 0;
            float gY0 = 0;
            int gX0 = 0;
            float bY0 = 0;
            int bX0 = 0;
            for (int i = 0; i < this.waveGraph.Width && (i + waveWindow) < (wave.data.shortArray.Length - 2); i += 3)
            {
                float rY = 100.0f + 100.0f * (wave.data.shortArray[i + waveWindow] / 32000.0f);
                int rX = i;
                float gY = 100.0f + 100.0f * (wave.data.shortArray[i + waveWindow + 1] / 32000.0f);
                int gX = i;
                float bY = 100.0f + 100.0f * (wave.data.shortArray[i + waveWindow + 2] / 32000.0f);
                int bX = i;
                if (i != 0)
                {
                    // draw a line
                    graphic.DrawLine(Pens.Red, rX0, rY0, rX, rY);
                    graphic.DrawLine(Pens.Green, gX0, gY0, gX, gY);
                    graphic.DrawLine(Pens.Blue, bX0, bY0, bX, bY);
                }
                rY0 = rY;
                rX0 = rX;
                gY0 = gY;
                gX0 = gX;
                bY0 = bY;
                bX0 = bX;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            waveWindow++;
            // Stop the timer and updating when reaching the end of the array.
            if (waveWindow > (wave.data.shortArray.Length - this.waveGraph.Width - 1))
                this.timer.Enabled = false;
            this.waveGraph.Invalidate();
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

        private Bitmap interpolate(Bitmap original)
        {
            try
            {
                // Takes an image, original, and interpolates (supersampling) it to four times the size.
                Bitmap interImage = new Bitmap(original, new Size(original.Width * 2, original.Height * 2));

                // Note: This algorithm uses a normalized form of sinc to speed up computation.
                // f(k+1/2) = 1/100 [ -10f(k-3)+14f(k-2)-23f(k-1)+69f(k)+69f(k+1)-23f(k+2)+14f(k+3)-10f(k+4)+50 ]

                int R, G, B;
                int k, l; // i, j values to access original image.
                for (int i = 0; i < interImage.Width; i++)
                {
                    for (int j = 0; j < interImage.Height; j++)
                    {
                        if (i % 2 == 0)
                        { // Original case.
                            if (j % 2 == 0)
                            { // get original values
                                Color originalColor = original.GetPixel(i / 2, j / 2);
                                interImage.SetPixel(i, j, originalColor);
                            }
                            else
                            { // Interpolate with sinc function
                                l = ((j - 6) / 2 > 0) ? (j - 6) / 2 : (j + 6) / 2;
                                Color km3 = original.GetPixel(i / 2, l);
                                l = ((j - 4) / 2 > 0) ? (j - 4) / 2 : (j + 4) / 2;
                                Color km2 = original.GetPixel(i / 2, l);
                                l = ((j - 2) / 2 > 0) ? (j - 2) / 2 : (j + 2) / 2;
                                Color km1 = original.GetPixel(i / 2, l);
                                l = j / 2;
                                Color k0 = original.GetPixel(i / 2, l);
                                l = ((j + 2) / 2 < original.Height) ? (j + 2) / 2 : (j - 2) / 2;
                                Color k1 = original.GetPixel(i / 2, l);
                                l = ((j + 4) / 2 < original.Height) ? (j + 4) / 2 : (j - 4) / 2;
                                Color k2 = original.GetPixel(i / 2, l);
                                l = ((j + 6) / 2 < original.Height) ? (j + 6) / 2 : (j - 6) / 2;
                                Color k3 = original.GetPixel(i / 2, l);
                                l = ((j + 8) / 2 < original.Height) ? (j + 8) / 2 : (j - 8) / 2;
                                Color k4 = original.GetPixel(i / 2, l);
                                // f(k+1/2) = 1/100 [ -10f(k-3)+14f(k-2)-23f(k-1)+69f(k)+69f(k+1)-23f(k+2)+14f(k+3)-10f(k+4)+50 ]
                                R = (-10 * km3.R + 14 * km2.R - 23 * km1.R + 69 * k0.R + 69 * k1.R - 23 * k2.R + 14 * k3.R - 10 * k4.R + 50) / 100;
                                G = (-10 * km3.G + 14 * km2.G - 23 * km1.G + 69 * k0.G + 69 * k1.G - 23 * k2.G + 14 * k3.G - 10 * k4.G + 50) / 100;
                                B = (-10 * km3.B + 14 * km2.B - 23 * km1.B + 69 * k0.B + 69 * k1.B - 23 * k2.B + 14 * k3.B - 10 * k4.B + 50) / 100;

                                if (R < 0) R = 0;
                                if (B < 0) B = 0;
                                if (G < 0) G = 0;
                                if (R > 255) R = 255;
                                if (B > 255) B = 255;
                                if (G > 255) G = 255;

                                Color newColor = Color.FromArgb(R, G, B);
                                interImage.SetPixel(i, j, newColor);
                            }
                        }
                        else
                        { // Column of interpolated values.
                            if (j % 2 == 0)
                            {
                                k = ((i - 6) / 2 > 0) ? (i - 6) / 2 : (i + 6) / 2;
                                Color km3 = original.GetPixel(k, j / 2);
                                k = ((i - 4) / 2 > 0) ? (i - 4) / 2 : (i + 4) / 2;
                                Color km2 = original.GetPixel(k, j / 2);
                                k = ((i - 2) / 2 > 0) ? (i - 2) / 2 : (i + 2) / 2;
                                Color km1 = original.GetPixel(k, j / 2);
                                k = i / 2;
                                Color k0 = original.GetPixel(k, j / 2);
                                k = ((i + 2) / 2 < original.Width) ? (i + 2) / 2 : (i - 2) / 2;
                                Color k1 = original.GetPixel(k, j / 2);
                                k = ((i + 4) / 2 < original.Width) ? (i + 4) / 2 : (i - 4) / 2;
                                Color k2 = original.GetPixel(k, j / 2);
                                k = ((i + 6) / 2 < original.Width) ? (i + 6) / 2 : (i - 6) / 2;
                                Color k3 = original.GetPixel(k, j / 2);
                                k = ((i + 8) / 2 < original.Width) ? (i + 8) / 2 : (i - 8) / 2;
                                Color k4 = original.GetPixel(k, j / 2);
                                // f(k+1/2) = 1/100 [ -10f(k-3)+14f(k-2)-23f(k-1)+69f(k)+69f(k+1)-23f(k+2)+14f(k+3)-10f(k+4)+50 ]
                                R = (-10 * km3.R + 14 * km2.R - 23 * km1.R + 69 * k0.R + 69 * k1.R - 23 * k2.R + 14 * k3.R - 10 * k4.R + 50) / 100;
                                G = (-10 * km3.G + 14 * km2.G - 23 * km1.G + 69 * k0.G + 69 * k1.G - 23 * k2.G + 14 * k3.G - 10 * k4.G + 50) / 100;
                                B = (-10 * km3.B + 14 * km2.B - 23 * km1.B + 69 * k0.B + 69 * k1.B - 23 * k2.B + 14 * k3.B - 10 * k4.B + 50) / 100;

                                if (R < 0) R = 0;
                                if (B < 0) B = 0;
                                if (G < 0) G = 0;
                                if (R > 255) R = 255;
                                if (B > 255) B = 255;
                                if (G > 255) G = 255;

                                Color newColor = Color.FromArgb(R, G, B);
                                interImage.SetPixel(i, j, newColor);
                            }
                            else
                            {
                                // Computed on second pass using the newly interpolated points.
                            }
                        }
                    }
                }

                // Second pass to get the missing pixels that can now be calculated.
                // Note what the step is for i and j.
                for (int i = 1; i < interImage.Width; i += 2)
                {
                    for (int j = 1; j < interImage.Height; j += 2)
                    {
                        l = (j - 3 > 0) ? j - 3 : j + 3;
                        Color km3 = interImage.GetPixel(i, l);
                        l = (j - 2 > 0) ? j - 2 : j + 2;
                        Color km2 = interImage.GetPixel(i, l);
                        l = ((j - 1) > 0) ? (j - 2) : (j + 2);
                        Color km1 = interImage.GetPixel(i, l);
                        l = j;
                        Color k0 = interImage.GetPixel(i, l);
                        l = ((j + 1) < interImage.Height) ? (j + 1) : (j - 1);
                        Color k1 = interImage.GetPixel(i, l);
                        l = ((j + 2) < interImage.Height) ? (j + 2) : (j - 2);
                        Color k2 = interImage.GetPixel(i, l);
                        l = ((j + 3) < interImage.Height) ? (j + 3) : (j - 3);
                        Color k3 = interImage.GetPixel(i, l);
                        l = ((j + 4) < interImage.Height) ? (j + 4) : (j - 4);
                        Color k4 = interImage.GetPixel(i, l);
                        // f(k+1/2) = 1/100 [ -10f(k-3)+14f(k-2)-23f(k-1)+69f(k)+69f(k+1)-23f(k+2)+14f(k+3)-10f(k+4)+50 ]
                        R = (-10 * km3.R + 14 * km2.R - 23 * km1.R + 69 * k0.R + 69 * k1.R - 23 * k2.R + 14 * k3.R - 10 * k4.R + 50) / 100;
                        G = (-10 * km3.G + 14 * km2.G - 23 * km1.G + 69 * k0.G + 69 * k1.G - 23 * k2.G + 14 * k3.G - 10 * k4.G + 50) / 100;
                        B = (-10 * km3.B + 14 * km2.B - 23 * km1.B + 69 * k0.B + 69 * k1.B - 23 * k2.B + 14 * k3.B - 10 * k4.B + 50) / 100;

                        if (R < 0) R = 0;
                        if (B < 0) B = 0;
                        if (G < 0) G = 0;
                        if (R > 255) R = 255;
                        if (B > 255) B = 255;
                        if (G > 255) G = 255;

                        Color newColor = Color.FromArgb(R, G, B);
                        interImage.SetPixel(i, j, newColor);
                    }
                }

                return interImage;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
