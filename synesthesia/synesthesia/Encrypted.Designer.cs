namespace synesthesia
{
    partial class Encrypted
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveImage = new System.Windows.Forms.Button();
            this.encryptedImageBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.encryptedImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // saveImage
            // 
            this.saveImage.Location = new System.Drawing.Point(12, 51);
            this.saveImage.Name = "saveImage";
            this.saveImage.Size = new System.Drawing.Size(93, 41);
            this.saveImage.TabIndex = 0;
            this.saveImage.Text = "Save Encrypted Image";
            this.saveImage.UseVisualStyleBackColor = true;
            this.saveImage.Click += new System.EventHandler(this.saveImage_Click);
            // 
            // encryptedImageBox
            // 
            this.encryptedImageBox.Location = new System.Drawing.Point(165, 51);
            this.encryptedImageBox.Name = "encryptedImageBox";
            this.encryptedImageBox.Size = new System.Drawing.Size(414, 391);
            this.encryptedImageBox.TabIndex = 1;
            this.encryptedImageBox.TabStop = false;
            // 
            // Encrypted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 546);
            this.Controls.Add(this.encryptedImageBox);
            this.Controls.Add(this.saveImage);
            this.Name = "Encrypted";
            this.Text = "Encrypted";
            ((System.ComponentModel.ISupportInitialize)(this.encryptedImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveImage;
        private System.Windows.Forms.PictureBox encryptedImageBox;
    }
}