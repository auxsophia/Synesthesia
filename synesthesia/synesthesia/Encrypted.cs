using System;
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
    public partial class Encrypted : Form
    {
        public Encrypted(Bitmap encryptedImage)
        {
            InitializeComponent();
            encryptedImageBox.Image = encryptedImage;

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

        }
    }
}
