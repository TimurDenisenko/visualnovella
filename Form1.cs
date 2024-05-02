using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace visualnovella
{
    public partial class Form1 : Form
    {
        private List<Form> pages;
        private int i;
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

        private void newgame_Click(object sender, EventArgs e)
        {
            this.Hide();
            SettingForm sf = new SettingForm();
            sf.Closed += (s, args) => Game();
            sf.Show();
        }
        private void Game()
        {
            pages = new List<Form>
            {
                CreatePage(Properties.Resources.girl,Properties.Resources.back,Setting.Name),
                CreatePage(Properties.Resources.girl,Properties.Resources.back,Setting.Gender.ToString()),
                CreatePage(Properties.Resources.girl,Properties.Resources.back,new Point(0,0),"You need to work",@""),
            };
            pages[i].Show();
        }
        private Form CreatePage(Bitmap person, Bitmap back, string dialog)
        {
            PictureBox pictureBox1 = new PictureBox();
            CustomLabel customLabel1 = new CustomLabel();
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = person;
            pictureBox1.Location = new Point(49, 83);
            pictureBox1.Size = new Size(246, 365);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            customLabel1.BorderColor = Color.Black;
            customLabel1.BorderThickness = 3;
            customLabel1.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            customLabel1.ImageAlign = ContentAlignment.TopLeft;
            customLabel1.Location = new Point(22, 364);
            customLabel1.MinimumSize = new Size(700, 100);
            customLabel1.Opacity = 150;
            customLabel1.Padding = new Padding(15, 15, 0, 0);
            customLabel1.Radius = 10;
            customLabel1.Size = new Size(700, 100);
            customLabel1.Text = dialog;
            customLabel1.TransparentBackColor = Color.White;
            customLabel1.Click += (s, e) =>
            {
                pages[i].Close();
                pages[++i].Show();
            };
            return new Form
            {
                BackgroundImage = back,
                ClientSize = new Size(752, 473),
                Text = "ITopia",
                Controls = { customLabel1, pictureBox1}
            };
        }
        private Form CreatePage(Bitmap person, Bitmap back,Point pointOfCode, string dialog,string code)
        {
            PictureBox pictureBox1 = new PictureBox();
            CustomLabel customLabel1 = new CustomLabel();
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = person;
            pictureBox1.Location = new Point(49, 83);
            pictureBox1.Size = new Size(246, 365);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            customLabel1.BorderColor = Color.Black;
            customLabel1.BorderThickness = 3;
            customLabel1.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            customLabel1.ImageAlign = ContentAlignment.TopLeft;
            customLabel1.Location = new Point(22, 364);
            customLabel1.MinimumSize = new Size(700, 100);
            customLabel1.Opacity = 150;
            customLabel1.Padding = new Padding(15, 15, 0, 0);
            customLabel1.Radius = 10;
            customLabel1.Size = new Size(700, 100);
            customLabel1.Text = dialog;
            customLabel1.TransparentBackColor = Color.White;
            customLabel1.Click += (s, e) =>
            {
                pages[i].Close();
                pages[++i].Show();
            };
            return new Form
            {
                BackgroundImage = back,
                ClientSize = new Size(752, 473),
                Text = "ITopia",
                Controls = { customLabel1, pictureBox1 }
            };
        }
    }
}
