using System.Drawing;

namespace synesthesia
{
    partial class Synesthete
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
            this.loadImage = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureDisplay = new System.Windows.Forms.PictureBox();
            this.pixelBox = new System.Windows.Forms.PictureBox();
            this.wavFile = new System.Windows.Forms.Button();
            this.playLoadedWav = new System.Windows.Forms.Button();
            this.encodeImage = new System.Windows.Forms.Button();
            this.loadEncrypImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loadImage
            // 
            this.loadImage.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.loadImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loadImage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loadImage.Location = new System.Drawing.Point(16, 47);
            this.loadImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.loadImage.Name = "loadImage";
            this.loadImage.Size = new System.Drawing.Size(132, 29);
            this.loadImage.TabIndex = 0;
            this.loadImage.Text = "Load Image";
            this.loadImage.UseVisualStyleBackColor = false;
            this.loadImage.Click += new System.EventHandler(this.loadImage_Click);
            // 
            // exit
            // 
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.exit.Location = new System.Drawing.Point(16, 334);
            this.exit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(132, 29);
            this.exit.TabIndex = 1;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // pictureDisplay
            // 
            this.pictureDisplay.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureDisplay.Location = new System.Drawing.Point(231, 47);
            this.pictureDisplay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureDisplay.Name = "pictureDisplay";
            this.pictureDisplay.Size = new System.Drawing.Size(643, 459);
            this.pictureDisplay.TabIndex = 2;
            this.pictureDisplay.TabStop = false;
            this.pictureDisplay.Click += new System.EventHandler(this.pictureDisplay_Click);
            this.pictureDisplay.MouseLeave += new System.EventHandler(this.pictureDisplay_MouseLeave);
            this.pictureDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureDisplay_MouseMove);
            // 
            // pixelBox
            // 
            this.pixelBox.Location = new System.Drawing.Point(181, 197);
            this.pixelBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pixelBox.Name = "pixelBox";
            this.pixelBox.Size = new System.Drawing.Size(20, 20);
            this.pixelBox.TabIndex = 5;
            this.pixelBox.TabStop = false;
            this.pixelBox.Visible = false;
            // 
            // wavFile
            // 
            this.wavFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.wavFile.Location = new System.Drawing.Point(17, 82);
            this.wavFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.wavFile.Name = "wavFile";
            this.wavFile.Size = new System.Drawing.Size(132, 29);
            this.wavFile.TabIndex = 6;
            this.wavFile.Text = "Load .wav file";
            this.wavFile.UseVisualStyleBackColor = true;
            this.wavFile.Click += new System.EventHandler(this.wavFile_Click);
            // 
            // playLoadedWav
            // 
            this.playLoadedWav.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.playLoadedWav.Location = new System.Drawing.Point(16, 118);
            this.playLoadedWav.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.playLoadedWav.Name = "playLoadedWav";
            this.playLoadedWav.Size = new System.Drawing.Size(132, 29);
            this.playLoadedWav.TabIndex = 7;
            this.playLoadedWav.Text = "Play .wav file";
            this.playLoadedWav.UseVisualStyleBackColor = true;
            this.playLoadedWav.Click += new System.EventHandler(this.playLoadedWav_Click);
            // 
            // encodeImage
            // 
            this.encodeImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.encodeImage.Location = new System.Drawing.Point(19, 154);
            this.encodeImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.encodeImage.Name = "encodeImage";
            this.encodeImage.Size = new System.Drawing.Size(131, 29);
            this.encodeImage.TabIndex = 8;
            this.encodeImage.Text = "Encode Image";
            this.encodeImage.UseVisualStyleBackColor = true;
            this.encodeImage.Click += new System.EventHandler(this.encodeImage_Click);
            // 
            // loadEncrypImage
            // 
            this.loadEncrypImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loadEncrypImage.Location = new System.Drawing.Point(17, 230);
            this.loadEncrypImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.loadEncrypImage.Name = "loadEncrypImage";
            this.loadEncrypImage.Size = new System.Drawing.Size(131, 47);
            this.loadEncrypImage.TabIndex = 9;
            this.loadEncrypImage.Text = "Load An Encrypted Image";
            this.loadEncrypImage.UseVisualStyleBackColor = true;
            this.loadEncrypImage.Click += new System.EventHandler(this.loadEncrypImage_Click);
            // 
            // Synesthete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1171, 605);
            this.Controls.Add(this.loadEncrypImage);
            this.Controls.Add(this.encodeImage);
            this.Controls.Add(this.playLoadedWav);
            this.Controls.Add(this.wavFile);
            this.Controls.Add(this.pixelBox);
            this.Controls.Add(this.pictureDisplay);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.loadImage);
            this.Font = new System.Drawing.Font("Lucida Fax", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Synesthete";
            this.Text = "Visual-Audio Synesthesia";
            ((System.ComponentModel.ISupportInitialize)(this.pictureDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadImage;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureDisplay;
        private System.Windows.Forms.PictureBox pixelBox;
        private System.Windows.Forms.Button wavFile;
        private System.Windows.Forms.Button playLoadedWav;
        private System.Windows.Forms.Button encodeImage;
        private System.Windows.Forms.Button loadEncrypImage;
    }
}

