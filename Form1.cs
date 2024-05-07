using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace visualnovella
{
    public partial class Form1 : Form
    {
        private List<NovellaPage> pages;
        private int i;
        private PictureBox pictureBox;
        private CustomLabel customLabel;
        private TextBox textBox;
        private Form novella;
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
            sf.Closed += (s, args) =>
            {
                
                Game();
            };
            sf.Show();
        }
        private void Game()
        {
            pictureBox = new PictureBox();
            customLabel = new CustomLabel();
            textBox = new TextBox();
            novella = new Form
            {
                ClientSize = new Size(752, 473),
                Text = "ITopia",
                Controls = { customLabel, pictureBox, textBox }
            };
            pages = new List<NovellaPage>
            {
                new NovellaPage(Setting.Name,Properties.Resources.girl,Properties.Resources.back, PageType.Text),
                new NovellaPage(Setting.Gender.ToString(),Properties.Resources.girl,Properties.Resources.back, PageType.Text),
                new NovellaPage("You need to work",Properties.Resources.girl,Properties.Resources.back,"return 5;",new Point(0,0), PageType.Code),
            };
            novella.Show();
            CreatePage(pages[i]);

        }
        private void CreatePage(NovellaPage page)
        {
            textBox.Visible = false;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Image = page.Person;
            pictureBox.Location = new Point(49, 83);
            pictureBox.Size = new Size(246, 365);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            customLabel.BorderColor = Color.Black;
            customLabel.BorderThickness = 3;
            customLabel.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            customLabel.ImageAlign = ContentAlignment.TopLeft;
            customLabel.Location = new Point(22, 364);
            customLabel.MinimumSize = new Size(700, 100);
            customLabel.Opacity = 150;
            customLabel.Padding = new Padding(15, 15, 0, 0);
            customLabel.Radius = 10;
            customLabel.Size = new Size(700, 100);
            customLabel.Text = page.Dialog;
            customLabel.TransparentBackColor = Color.White;
            customLabel.Click += (s, e) =>
            {
                if (pages[++i].PageType == PageType.Code)
                {
                    CreatePage(pages[i], true);
                }
                else
                {
                    CreatePage(pages[i]);
                }
            };
            novella.BackgroundImage = page.Background;
        }
        private void CreatePage(NovellaPage page, bool isCode)
        {
            textBox.Visible = true;
            textBox.Size = new Size(200,200);
            textBox.Location = page.CodeEditorLocation;
            textBox.Text = page.Code;
            textBox.Multiline = true;
            textBox.TabStop = false;  
            textBox.KeyDown += async (s, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.Tab:
                        textBox.SelectedText = "   ";
                        break;
                    case Keys.Insert:
                        try
                        {
                            ScriptState result = await CSharpScript.RunAsync(textBox.Text, ScriptOptions.Default.WithReferences(typeof(MessageBox).Assembly));
                            MessageBox.Show(result.ReturnValue.ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    default:
                        break;
                }
            };
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = page.Person;
            pictureBox1.Location = new Point(49, 83);
            pictureBox1.Size = new Size(246, 365);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            customLabel.BorderColor = Color.Black;
            customLabel.BorderThickness = 3;
            customLabel.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            customLabel.ImageAlign = ContentAlignment.TopLeft;
            customLabel.Location = new Point(22, 364);
            customLabel.MinimumSize = new Size(700, 100);
            customLabel.Opacity = 150;
            customLabel.Padding = new Padding(15, 15, 0, 0);
            customLabel.Radius = 10;
            customLabel.Size = new Size(700, 100);
            customLabel.Text = page.Dialog;
            customLabel.TransparentBackColor = Color.White;
            customLabel.Click += (s, e) =>
            {
                if (pages[++i].PageType == PageType.Code)
                {
                    CreatePage(pages[i], true);
                }
                else
                {
                    CreatePage(pages[i]);
                }
            };
            novella.BackgroundImage = page.Background;
        }
    }
}
