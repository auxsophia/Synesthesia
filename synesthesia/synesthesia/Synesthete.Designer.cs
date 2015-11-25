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
            this.waveGenerator = new System.Windows.Forms.Button();
            this.pixelBox = new System.Windows.Forms.PictureBox();
            this.wavFile = new System.Windows.Forms.Button();
            this.playLoadedWav = new System.Windows.Forms.Button();
            this.encodeImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loadImage
            // 
            this.loadImage.Location = new System.Drawing.Point(12, 38);
            this.loadImage.Name = "loadImage";
            this.loadImage.Size = new System.Drawing.Size(99, 23);
            this.loadImage.TabIndex = 0;
            this.loadImage.Text = "Load Image";
            this.loadImage.UseVisualStyleBackColor = true;
            this.loadImage.Click += new System.EventHandler(this.loadImage_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(12, 271);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(99, 23);
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
            this.pictureDisplay.Location = new System.Drawing.Point(208, 38);
            this.pictureDisplay.Name = "pictureDisplay";
            this.pictureDisplay.Size = new System.Drawing.Size(482, 373);
            this.pictureDisplay.TabIndex = 2;
            this.pictureDisplay.TabStop = false;
            this.pictureDisplay.Click += new System.EventHandler(this.pictureDisplay_Click);
            this.pictureDisplay.MouseLeave += new System.EventHandler(this.pictureDisplay_MouseLeave);
            this.pictureDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureDisplay_MouseMove);
            // 
            // waveGenerator
            // 
            this.waveGenerator.Location = new System.Drawing.Point(12, 189);
            this.waveGenerator.Name = "waveGenerator";
            this.waveGenerator.Size = new System.Drawing.Size(99, 37);
            this.waveGenerator.TabIndex = 3;
            this.waveGenerator.Text = "Wave Generator";
            this.waveGenerator.UseVisualStyleBackColor = true;
            this.waveGenerator.Click += new System.EventHandler(this.waveGenerator_Click);
            // 
            // pixelBox
            // 
            this.pixelBox.Location = new System.Drawing.Point(147, 163);
            this.pixelBox.Name = "pixelBox";
            this.pixelBox.Size = new System.Drawing.Size(20, 20);
            this.pixelBox.TabIndex = 5;
            this.pixelBox.TabStop = false;
            this.pixelBox.Visible = false;
            // 
            // wavFile
            // 
            this.wavFile.Location = new System.Drawing.Point(12, 79);
            this.wavFile.Name = "wavFile";
            this.wavFile.Size = new System.Drawing.Size(99, 23);
            this.wavFile.TabIndex = 6;
            this.wavFile.Text = "Load .wav file";
            this.wavFile.UseVisualStyleBackColor = true;
            this.wavFile.Click += new System.EventHandler(this.wavFile_Click);
            // 
            // playLoadedWav
            // 
            this.playLoadedWav.Location = new System.Drawing.Point(12, 109);
            this.playLoadedWav.Name = "playLoadedWav";
            this.playLoadedWav.Size = new System.Drawing.Size(99, 23);
            this.playLoadedWav.TabIndex = 7;
            this.playLoadedWav.Text = "Play .wav file";
            this.playLoadedWav.UseVisualStyleBackColor = true;
            this.playLoadedWav.Click += new System.EventHandler(this.playLoadedWav_Click);
            // 
            // encodeImage
            // 
            this.encodeImage.Location = new System.Drawing.Point(13, 139);
            this.encodeImage.Name = "encodeImage";
            this.encodeImage.Size = new System.Drawing.Size(98, 23);
            this.encodeImage.TabIndex = 8;
            this.encodeImage.Text = "Encode Image";
            this.encodeImage.UseVisualStyleBackColor = true;
            this.encodeImage.Click += new System.EventHandler(this.encodeImage_Click);
            // 
            // Synesthete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 438);
            this.Controls.Add(this.encodeImage);
            this.Controls.Add(this.playLoadedWav);
            this.Controls.Add(this.wavFile);
            this.Controls.Add(this.pixelBox);
            this.Controls.Add(this.waveGenerator);
            this.Controls.Add(this.pictureDisplay);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.loadImage);
            this.Name = "Synesthete";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pixelBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadImage;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureDisplay;
        private System.Windows.Forms.Button waveGenerator;
        private System.Windows.Forms.PictureBox pixelBox;
        private System.Windows.Forms.Button wavFile;
        private System.Windows.Forms.Button playLoadedWav;
        private System.Windows.Forms.Button encodeImage;
    }
}

