﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visualnovella
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            newgame.MouseEnter += btn_MouseEnter;
            newgame.MouseLeave += btn_MouseLeave;
            _continue.MouseEnter += btn_MouseEnter;
            _continue.MouseLeave += btn_MouseLeave;
            exit.MouseEnter += btn_MouseEnter;
            exit.MouseLeave += btn_MouseLeave;
        }

        private async void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            for (int i = 0; i < 5; i++)
            {
                btn.Size = new Size(btn.Size.Width - i, btn.Size.Height - i);
                btn.Location = new Point(btn.Location.X + i/2, btn.Location.Y + i/2);
                await Task.Delay(3);
            }
        }

        private async void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            for (int i = 0; i < 5; i++)
            {
                btn.Size = new Size(btn.Size.Width + i, btn.Size.Height + i);
                btn.Location = new Point(btn.Location.X-i/2, btn.Location.Y-i/2);
                await Task.Delay(20);
            }
        }

        private void exit_Click(object sender, EventArgs e) => Close();
    }
}
