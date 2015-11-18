namespace test
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
            this.waveGraph = new System.Windows.Forms.PictureBox();
            this.text = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.waveGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // waveGraph
            // 
            this.waveGraph.Location = new System.Drawing.Point(181, 65);
            this.waveGraph.Name = "waveGraph";
            this.waveGraph.Size = new System.Drawing.Size(402, 223);
            this.waveGraph.TabIndex = 0;
            this.waveGraph.TabStop = false;
            // 
            // text
            // 
            this.text.Location = new System.Drawing.Point(12, 26);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(85, 23);
            this.text.TabIndex = 1;
            this.text.Text = "text";
            this.text.UseVisualStyleBackColor = true;
            this.text.Click += new System.EventHandler(this.text_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 427);
            this.Controls.Add(this.text);
            this.Controls.Add(this.waveGraph);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.waveGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox waveGraph;
        private System.Windows.Forms.Button text;
    }
}

