using System.Drawing;
using System.Windows.Forms;

namespace visualnovella
{
    public partial class TestPage : Form
    {
        PictureBox pictureBox1;
        CustomLabel customLabel1;
        public TestPage()
        {
            pictureBox1 = new PictureBox();
            customLabel1 = new CustomLabel();
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.anna;
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
            customLabel1.Text = Setting.Gender+" "+Setting.Name;
            customLabel1.TransparentBackColor = Color.White;
            BackgroundImage = Properties.Resources.university;
            ClientSize = new Size(752, 473);
            Controls.Add(customLabel1);
            Controls.Add(pictureBox1);
            Text = "TestPage";
        }
    }
}
