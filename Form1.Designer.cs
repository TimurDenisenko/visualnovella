namespace visualnovella
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.exit = new visualnovella.CustomButton();
            this._continue = new visualnovella.CustomButton();
            this.newgame = new visualnovella.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(260, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.BorderColor = System.Drawing.Color.Black;
            this.exit.BorderThickness = 2;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(104)))));
            this.exit.Location = new System.Drawing.Point(309, 346);
            this.exit.Name = "exit";
            this.exit.Opacity = 210;
            this.exit.Radius = 15;
            this.exit.Size = new System.Drawing.Size(150, 49);
            this.exit.TabIndex = 4;
            this.exit.Text = "Exit";
            this.exit.TransparentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // _continue
            // 
            this._continue.BackColor = System.Drawing.Color.Transparent;
            this._continue.BorderColor = System.Drawing.Color.Black;
            this._continue.BorderThickness = 2;
            this._continue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._continue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._continue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(104)))));
            this._continue.Location = new System.Drawing.Point(309, 266);
            this._continue.Name = "_continue";
            this._continue.Opacity = 210;
            this._continue.Radius = 15;
            this._continue.Size = new System.Drawing.Size(150, 49);
            this._continue.TabIndex = 3;
            this._continue.Text = "Continue";
            this._continue.TransparentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this._continue.UseVisualStyleBackColor = true;
            // 
            // newgame
            // 
            this.newgame.BackColor = System.Drawing.Color.Transparent;
            this.newgame.BorderColor = System.Drawing.Color.Black;
            this.newgame.BorderThickness = 2;
            this.newgame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newgame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newgame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(104)))));
            this.newgame.Location = new System.Drawing.Point(309, 189);
            this.newgame.Name = "newgame";
            this.newgame.Opacity = 210;
            this.newgame.Radius = 15;
            this.newgame.Size = new System.Drawing.Size(150, 49);
            this.newgame.TabIndex = 1;
            this.newgame.Text = "New game";
            this.newgame.TransparentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(32)))), ((int)(((byte)(58)))));
            this.newgame.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(752, 473);
            this.Controls.Add(this.exit);
            this.Controls.Add(this._continue);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.newgame);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CustomButton newgame;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomButton _continue;
        private CustomButton exit;
    }
}

