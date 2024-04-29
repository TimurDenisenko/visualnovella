namespace visualnovella
{
    partial class TestPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestPage));
            this.customLabel1 = new visualnovella.CustomLabel();
            this.SuspendLayout();
            // 
            // customLabel1
            // 
            this.customLabel1.AutoSize = true;
            this.customLabel1.BorderColor = System.Drawing.Color.Black;
            this.customLabel1.BorderThickness = 1;
            this.customLabel1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.customLabel1.Location = new System.Drawing.Point(40, 247);
            this.customLabel1.MinimumSize = new System.Drawing.Size(700, 200);
            this.customLabel1.Name = "customLabel1";
            this.customLabel1.Opacity = 0;
            this.customLabel1.Radius = 10;
            this.customLabel1.Size = new System.Drawing.Size(700, 200);
            this.customLabel1.TabIndex = 0;
            this.customLabel1.Text = "выапвывы";
            this.customLabel1.TransparentBackColor = System.Drawing.Color.Empty;
            // 
            // TestPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(752, 473);
            this.Controls.Add(this.customLabel1);
            this.Name = "TestPage";
            this.Text = "TestPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomLabel customLabel1;
    }
}