namespace visualnovella
{
    partial class SettingForm
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
            this.customButton1 = new visualnovella.CustomButton();
            this.customButton2 = new visualnovella.CustomButton();
            this.customTextBox1 = new visualnovella.CustomTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.Transparent;
            this.customButton1.BorderColor = System.Drawing.Color.Black;
            this.customButton1.BorderThickness = 15;
            this.customButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.customButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(104)))));
            this.customButton1.Location = new System.Drawing.Point(218, 54);
            this.customButton1.Name = "customButton1";
            this.customButton1.Opacity = 255;
            this.customButton1.Radius = 10;
            this.customButton1.Size = new System.Drawing.Size(292, 103);
            this.customButton1.TabIndex = 0;
            this.customButton1.Text = "Male";
            this.customButton1.TransparentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.customButton1.UseVisualStyleBackColor = false;
            this.customButton1.Click += new System.EventHandler(this.gender_Click);
            // 
            // customButton2
            // 
            this.customButton2.BackColor = System.Drawing.Color.Transparent;
            this.customButton2.BorderColor = System.Drawing.Color.Black;
            this.customButton2.BorderThickness = 15;
            this.customButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.customButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(104)))));
            this.customButton2.Location = new System.Drawing.Point(218, 226);
            this.customButton2.Name = "customButton2";
            this.customButton2.Opacity = 255;
            this.customButton2.Radius = 10;
            this.customButton2.Size = new System.Drawing.Size(292, 103);
            this.customButton2.TabIndex = 1;
            this.customButton2.Text = "Female";
            this.customButton2.TransparentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.customButton2.UseVisualStyleBackColor = false;
            this.customButton2.Click += new System.EventHandler(this.gender_Click);
            // 
            // customTextBox1
            // 
            this.customTextBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customTextBox1.BorderColor = System.Drawing.Color.Black;
            this.customTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customTextBox1.BorderThickness = 15;
            this.customTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.customTextBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.customTextBox1.Location = new System.Drawing.Point(11, 30);
            this.customTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.customTextBox1.MaxLength = 15;
            this.customTextBox1.MinimumSize = new System.Drawing.Size(4, 0);
            this.customTextBox1.Name = "customTextBox1";
            this.customTextBox1.Radius = 10;
            this.customTextBox1.Size = new System.Drawing.Size(301, 37);
            this.customTextBox1.TabIndex = 2;
            this.customTextBox1.Text = "Your name...";
            this.customTextBox1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.customTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(207, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(736, 434);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.customButton1);
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButton customButton1;
        private CustomButton customButton2;
        private CustomTextBox customTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}