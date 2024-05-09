using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace visualnovella
{
    public partial class SettingForm : Form
    {
        private char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public SettingForm()
        {
            InitializeComponent();
        }

        private void gender_Click(object sender, EventArgs e)
        {
            CustomButton btn = sender as CustomButton;
            Setting.Gender = btn.Text == "Male" ? Gender.Male : Gender.Female;
            customButton1.Visible = false;
            customButton2.Visible = false;
            groupBox1.Visible = true;
            customTextBox1.Visible = true;
            customTextBox1.KeyDown += CustomTextBox1_KeyDown; 
            customTextBox1.Click += CustomTextBox1_Click; 
        }

        private void CustomTextBox1_Click(object sender, EventArgs e)
        {
            customTextBox1.Text = string.Empty;
            customTextBox1.ForeColor = Color.Black;
        }

        private void CustomTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (customTextBox1.Text == string.Empty || customTextBox1.Text.ToUpper().ToCharArray().Where(x => alpha.Contains(x)).Count() != customTextBox1.Text.Length)
            {
                MessageBox.Show("Viga", "Vale nimi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Setting.Name = customTextBox1.Text;
            Close();
        }
    }
}
