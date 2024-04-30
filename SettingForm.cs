using System;
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
    public partial class SettingForm : Form
    {
        public Gender Gender { get; set; }
        public SettingForm()
        {
            InitializeComponent();
        }

        private void gender_Click(object sender, EventArgs e)
        {
            CustomButton btn = sender as CustomButton;
            Gender = btn.Text == "Male" ? Gender.Male : Gender.Female;
            customButton1.Visible = false;
            customButton2.Visible = false;
            groupBox1.Visible = true;
            customTextBox1.Visible = true;
        }
    }
}
