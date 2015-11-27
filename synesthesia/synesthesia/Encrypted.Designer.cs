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
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.pngLabel = new System.Windows.Forms.Label();
            this.decodePlay = new System.Windows.Forms.Button();
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
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(226, 12);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(179, 20);
            this.fileNameTextBox.TabIndex = 2;
            this.fileNameTextBox.TextChanged += new System.EventHandler(this.fileNameTextBox_TextChanged);
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(162, 15);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(58, 13);
            this.fileNameLabel.TabIndex = 3;
            this.fileNameLabel.Text = "File name: ";
            // 
            // pngLabel
            // 
            this.pngLabel.AutoSize = true;
            this.pngLabel.Location = new System.Drawing.Point(411, 15);
            this.pngLabel.Name = "pngLabel";
            this.pngLabel.Size = new System.Drawing.Size(28, 13);
            this.pngLabel.TabIndex = 4;
            this.pngLabel.Text = ".png";
            // 
            // decodePlay
            // 
            this.decodePlay.Location = new System.Drawing.Point(12, 129);
            this.decodePlay.Name = "decodePlay";
            this.decodePlay.Size = new System.Drawing.Size(93, 46);
            this.decodePlay.TabIndex = 5;
            this.decodePlay.Text = "Decode and Play";
            this.decodePlay.UseVisualStyleBackColor = true;
            this.decodePlay.Click += new System.EventHandler(this.decodePlay_Click);
            // 
            // Encrypted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 546);
            this.Controls.Add(this.decodePlay);
            this.Controls.Add(this.pngLabel);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.encryptedImageBox);
            this.Controls.Add(this.saveImage);
            this.Name = "Encrypted";
            this.Text = "Encrypted";
            ((System.ComponentModel.ISupportInitialize)(this.encryptedImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveImage;
        private System.Windows.Forms.PictureBox encryptedImageBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label pngLabel;
        private System.Windows.Forms.Button decodePlay;
    }
}