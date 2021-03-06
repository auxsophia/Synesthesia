﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace synesthesia
{
    public partial class color : Form
    {
        public color(bool exact, Color original, Color similar, string region, string colorName)
        {
            InitializeComponent();

            regionLabel.Text = "Your color is in the " + region;

            if (exact)
            { // Exact color matching.
                originalColorLabel.Text = "";
                similarColorLabel.Text = "";
                exactColorLabel.Text = "Your color is precisely \n" + colorName + "\nRGB = {" + original.R + "," + original.G + "," + original.B + "}.";
                Bitmap exactImage = new Bitmap(120, 120);
                for (int i = 0; i < 120; i++)
                {
                    for (int j = 0; j < 120; j++)
                    {
                        exactImage.SetPixel(i, j, original);
                    }
                }
                exactColorDisplay.BorderStyle = BorderStyle.FixedSingle;
                exactColorDisplay.Image = exactImage;
            }
            else
            {
                exactColorLabel.Text = "";
                originalColorLabel.Text = "Your original \ncolor has \nRGB = {" + original.R + "," + original.G + "," + original.B + "}.";
                Bitmap originalImage = new Bitmap(120, 120);
                for (int i = 0; i < 120; i++)
                {
                    for (int j = 0; j < 120; j++)
                    {
                        originalImage.SetPixel(i, j, original);
                    }
                }
                originalColorDisplay.Image = originalImage;

                similarColorLabel.Text = "Your color is most \nsimilar to \n" + colorName + " \nRGB = {" + similar.R + "," + similar.G + "," + similar.B + "}.";
                Bitmap similarImage = new Bitmap(120, 120);
                for (int i = 0; i < 120; i++)
                {
                    for (int j = 0; j < 120; j++)
                    {
                        similarImage.SetPixel(i, j, similar);
                    }
                }
                similarColorDisplay.Image = similarImage;
            }
        }
    }
}
