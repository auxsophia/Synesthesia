namespace synesthesia
{
    partial class color
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
            this.originalColorDisplay = new System.Windows.Forms.PictureBox();
            this.exactColorDisplay = new System.Windows.Forms.PictureBox();
            this.similarColorDisplay = new System.Windows.Forms.PictureBox();
            this.originalColorLabel = new System.Windows.Forms.Label();
            this.exactColorLabel = new System.Windows.Forms.Label();
            this.similarColorLabel = new System.Windows.Forms.Label();
            this.regionLabel = new System.Windows.Forms.Label();
            this.regions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.originalColorDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exactColorDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.similarColorDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // originalColorDisplay
            // 
            this.originalColorDisplay.Location = new System.Drawing.Point(10, 80);
            this.originalColorDisplay.Name = "originalColorDisplay";
            this.originalColorDisplay.Size = new System.Drawing.Size(100, 100);
            this.originalColorDisplay.TabIndex = 0;
            this.originalColorDisplay.TabStop = false;
            // 
            // exactColorDisplay
            // 
            this.exactColorDisplay.Location = new System.Drawing.Point(120, 80);
            this.exactColorDisplay.Name = "exactColorDisplay";
            this.exactColorDisplay.Size = new System.Drawing.Size(100, 100);
            this.exactColorDisplay.TabIndex = 1;
            this.exactColorDisplay.TabStop = false;
            // 
            // similarColorDisplay
            // 
            this.similarColorDisplay.Location = new System.Drawing.Point(230, 80);
            this.similarColorDisplay.Name = "similarColorDisplay";
            this.similarColorDisplay.Size = new System.Drawing.Size(100, 100);
            this.similarColorDisplay.TabIndex = 2;
            this.similarColorDisplay.TabStop = false;
            // 
            // originalColorLabel
            // 
            this.originalColorLabel.AutoSize = true;
            this.originalColorLabel.Location = new System.Drawing.Point(7, 41);
            this.originalColorLabel.Name = "originalColorLabel";
            this.originalColorLabel.Size = new System.Drawing.Size(64, 13);
            this.originalColorLabel.TabIndex = 3;
            this.originalColorLabel.Text = "originalColor";
            // 
            // exactColorLabel
            // 
            this.exactColorLabel.AutoSize = true;
            this.exactColorLabel.Location = new System.Drawing.Point(117, 41);
            this.exactColorLabel.Name = "exactColorLabel";
            this.exactColorLabel.Size = new System.Drawing.Size(57, 13);
            this.exactColorLabel.TabIndex = 4;
            this.exactColorLabel.Text = "exactColor";
            // 
            // similarColorLabel
            // 
            this.similarColorLabel.AutoSize = true;
            this.similarColorLabel.Location = new System.Drawing.Point(227, 41);
            this.similarColorLabel.Name = "similarColorLabel";
            this.similarColorLabel.Size = new System.Drawing.Size(59, 13);
            this.similarColorLabel.TabIndex = 5;
            this.similarColorLabel.Text = "similarColor";
            // 
            // regionLabel
            // 
            this.regionLabel.AutoSize = true;
            this.regionLabel.Location = new System.Drawing.Point(138, 21);
            this.regionLabel.Name = "regionLabel";
            this.regionLabel.Size = new System.Drawing.Size(36, 13);
            this.regionLabel.TabIndex = 6;
            this.regionLabel.Text = "region";
            // 
            // regions
            // 
            this.regions.AutoSize = true;
            this.regions.Location = new System.Drawing.Point(19, 8);
            this.regions.Name = "regions";
            this.regions.Size = new System.Drawing.Size(322, 13);
            this.regions.TabIndex = 7;
            this.regions.Text = "Color Regions: Black White Red Magenta Yellow Green Blue Cyan";
            // 
            // color
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 181);
            this.Controls.Add(this.regions);
            this.Controls.Add(this.regionLabel);
            this.Controls.Add(this.similarColorLabel);
            this.Controls.Add(this.exactColorLabel);
            this.Controls.Add(this.originalColorLabel);
            this.Controls.Add(this.similarColorDisplay);
            this.Controls.Add(this.exactColorDisplay);
            this.Controls.Add(this.originalColorDisplay);
            this.Name = "color";
            this.Text = "color";
            ((System.ComponentModel.ISupportInitialize)(this.originalColorDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exactColorDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.similarColorDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label regions;
        public System.Windows.Forms.PictureBox originalColorDisplay;
        public System.Windows.Forms.PictureBox exactColorDisplay;
        public System.Windows.Forms.PictureBox similarColorDisplay;
        public System.Windows.Forms.Label originalColorLabel;
        public System.Windows.Forms.Label exactColorLabel;
        public System.Windows.Forms.Label similarColorLabel;
        public System.Windows.Forms.Label regionLabel;
    }
}