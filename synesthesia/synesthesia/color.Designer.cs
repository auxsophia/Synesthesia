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
            ((System.ComponentModel.ISupportInitialize)(this.originalColorDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exactColorDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.similarColorDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // originalColorDisplay
            // 
            this.originalColorDisplay.Location = new System.Drawing.Point(12, 116);
            this.originalColorDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.originalColorDisplay.Name = "originalColorDisplay";
            this.originalColorDisplay.Size = new System.Drawing.Size(120, 120);
            this.originalColorDisplay.TabIndex = 0;
            this.originalColorDisplay.TabStop = false;
            // 
            // exactColorDisplay
            // 
            this.exactColorDisplay.Location = new System.Drawing.Point(159, 116);
            this.exactColorDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.exactColorDisplay.Name = "exactColorDisplay";
            this.exactColorDisplay.Size = new System.Drawing.Size(120, 120);
            this.exactColorDisplay.TabIndex = 1;
            this.exactColorDisplay.TabStop = false;
            // 
            // similarColorDisplay
            // 
            this.similarColorDisplay.Location = new System.Drawing.Point(306, 116);
            this.similarColorDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.similarColorDisplay.Name = "similarColorDisplay";
            this.similarColorDisplay.Size = new System.Drawing.Size(120, 120);
            this.similarColorDisplay.TabIndex = 2;
            this.similarColorDisplay.TabStop = false;
            // 
            // originalColorLabel
            // 
            this.originalColorLabel.AutoSize = true;
            this.originalColorLabel.Location = new System.Drawing.Point(9, 50);
            this.originalColorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.originalColorLabel.Name = "originalColorLabel";
            this.originalColorLabel.Size = new System.Drawing.Size(93, 16);
            this.originalColorLabel.TabIndex = 3;
            this.originalColorLabel.Text = "originalColor";
            // 
            // exactColorLabel
            // 
            this.exactColorLabel.AutoSize = true;
            this.exactColorLabel.Location = new System.Drawing.Point(156, 50);
            this.exactColorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.exactColorLabel.Name = "exactColorLabel";
            this.exactColorLabel.Size = new System.Drawing.Size(76, 16);
            this.exactColorLabel.TabIndex = 4;
            this.exactColorLabel.Text = "exactColor";
            // 
            // similarColorLabel
            // 
            this.similarColorLabel.AutoSize = true;
            this.similarColorLabel.Location = new System.Drawing.Point(303, 50);
            this.similarColorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.similarColorLabel.Name = "similarColorLabel";
            this.similarColorLabel.Size = new System.Drawing.Size(88, 16);
            this.similarColorLabel.TabIndex = 5;
            this.similarColorLabel.Text = "similarColor";
            // 
            // regionLabel
            // 
            this.regionLabel.AutoSize = true;
            this.regionLabel.Location = new System.Drawing.Point(109, 18);
            this.regionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.regionLabel.Name = "regionLabel";
            this.regionLabel.Size = new System.Drawing.Size(50, 16);
            this.regionLabel.TabIndex = 6;
            this.regionLabel.Text = "region";
            // 
            // color
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(461, 263);
            this.Controls.Add(this.regionLabel);
            this.Controls.Add(this.similarColorLabel);
            this.Controls.Add(this.exactColorLabel);
            this.Controls.Add(this.originalColorLabel);
            this.Controls.Add(this.similarColorDisplay);
            this.Controls.Add(this.exactColorDisplay);
            this.Controls.Add(this.originalColorDisplay);
            this.Font = new System.Drawing.Font("Lucida Fax", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "color";
            this.Text = "color";
            ((System.ComponentModel.ISupportInitialize)(this.originalColorDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exactColorDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.similarColorDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox originalColorDisplay;
        public System.Windows.Forms.PictureBox exactColorDisplay;
        public System.Windows.Forms.PictureBox similarColorDisplay;
        public System.Windows.Forms.Label originalColorLabel;
        public System.Windows.Forms.Label exactColorLabel;
        public System.Windows.Forms.Label similarColorLabel;
        public System.Windows.Forms.Label regionLabel;
    }
}