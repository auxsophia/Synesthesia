using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public struct DRGBName
        {
            double distance;
            int red;
            int green;
            int blue;
            string colorName;

            public DRGBName(double d, int r, int g, int b, string name)
            {
                distance = d;
                red = r;
                green = g;
                blue = b;
                colorName = name;
            }
        }

        static DRGBName[] colorTable = new DRGBName[3]
        {
            new DRGBName(1.0, 2, 2, 2, "Dark Grey"),
            new DRGBName(2.9, 3, 18, 40, "Something"),
            new DRGBName(5.9, 9, 255, 14, "Derp")
        };

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void text_Click(object sender, EventArgs e)
        {
            
        }
    }
}
