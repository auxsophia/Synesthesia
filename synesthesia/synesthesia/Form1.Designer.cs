namespace synesthesia
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.loadImage = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureDisplay = new System.Windows.Forms.PictureBox();
            this.waveGenerator = new System.Windows.Forms.Button();
            this.waveGraph = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveGraph)).BeginInit();
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
            this.exit.Location = new System.Drawing.Point(12, 163);
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
            this.pictureDisplay.Location = new System.Drawing.Point(275, 40);
            this.pictureDisplay.Name = "pictureDisplay";
            this.pictureDisplay.Size = new System.Drawing.Size(482, 373);
            this.pictureDisplay.TabIndex = 2;
            this.pictureDisplay.TabStop = false;
            this.pictureDisplay.Click += new System.EventHandler(this.pictureDisplay_Click);
            // 
            // waveGenerator
            // 
            this.waveGenerator.Location = new System.Drawing.Point(12, 84);
            this.waveGenerator.Name = "waveGenerator";
            this.waveGenerator.Size = new System.Drawing.Size(99, 37);
            this.waveGenerator.TabIndex = 3;
            this.waveGenerator.Text = "Wave Generator";
            this.waveGenerator.UseVisualStyleBackColor = true;
            this.waveGenerator.Click += new System.EventHandler(this.waveGenerator_Click);
            // 
            // waveGraph
            // 
            this.waveGraph.Location = new System.Drawing.Point(12, 226);
            this.waveGraph.Name = "waveGraph";
            this.waveGraph.Size = new System.Drawing.Size(250, 200);
            this.waveGraph.TabIndex = 4;
            this.waveGraph.TabStop = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 438);
            this.Controls.Add(this.waveGraph);
            this.Controls.Add(this.waveGenerator);
            this.Controls.Add(this.pictureDisplay);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.loadImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadImage;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureDisplay;
        private System.Windows.Forms.Button waveGenerator;
        private System.Windows.Forms.PictureBox waveGraph;
        private System.Windows.Forms.Timer timer;
    }
}

