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
        private PictureBox characterImage;
        private CustomLabel dialogLabel;
        private TextBox codeEditor;
        private Form novellaForm;
        private PictureBox menu;
        private UserControl menuFrame;
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
            characterImage = new PictureBox();
            dialogLabel = new CustomLabel();
            codeEditor = new TextBox();
            menu = new PictureBox();
            menuFrame = new UserControl();

            novellaForm = new Form
            {
                Controls = { codeEditor, dialogLabel, characterImage, menu, menuFrame }
            };

            pages = new List<NovellaPage>
            {
                new NovellaPage(Setting.Name,Properties.Resources.girl,Properties.Resources.back, PageType.Text),
                new NovellaPage(Setting.Gender.ToString(),Properties.Resources.girl,Properties.Resources.back, PageType.Text),
                new NovellaPage("You need to work",Properties.Resources.girl,Properties.Resources.back,"return 5;",new Point(0,0), PageType.Code),
            };

            #region Design and events
            characterImage.BackColor = Color.Transparent;
            characterImage.SizeMode = PictureBoxSizeMode.StretchImage;

            dialogLabel.Click+= (s, args) => CreatePage(pages[++i]);
            dialogLabel.BorderColor = Color.Black;
            dialogLabel.BorderThickness = 3;
            dialogLabel.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dialogLabel.ImageAlign = ContentAlignment.TopLeft;
            dialogLabel.Location = new Point(22, 364);
            dialogLabel.MinimumSize = new Size(700, 100);
            dialogLabel.Opacity = 150;
            dialogLabel.Padding = new Padding(15, 15, 0, 0);
            dialogLabel.Radius = 10;
            dialogLabel.TransparentBackColor = Color.White;

            codeEditor.Multiline = true;
            codeEditor.TabStop = false;
            codeEditor.KeyDown += TextBox_KeyDown;

            novellaForm.ClientSize = new Size(752,473);
            novellaForm.Text = "ITopia";
            novellaForm.KeyDown += Novella_KeyDown;

            menu.Location = new Point(10,10);
            menu.BackColor = Color.Transparent;
            menu.Image = Properties.Resources.menu;
            menu.SizeMode = PictureBoxSizeMode.StretchImage;
            menu.Size = new Size(50, 50);

            //MENUFRAME надо сделать
            #endregion

            novellaForm.Show();

            CreatePage(pages[i]);
        }
        private void Menu()
        {
            menuFrame
        }
        private void Novella_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    CreatePage(pages[++i]);
                    break;
                case Keys.Space:
                    CreatePage(pages[++i]);
                    break;
                case Keys.Left:
                    CreatePage(pages[--i]);
                    break;
                case Keys.Escape:
                    Menu();
                    break;
                default:
                    break;
            }
        }

        private async void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    codeEditor.SelectedText = "   ";
                    break;
                case Keys.Insert:
                    try
                    {
                        ScriptState result = await CSharpScript.RunAsync(codeEditor.Text, ScriptOptions.Default.WithReferences(typeof(MessageBox).Assembly));
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
        }

        private async void CreatePage(NovellaPage page)
        {
            if (page.PageType == PageType.Code)
            {
                codeEditor.Visible = true;
                codeEditor.Size = new Size(200, 200);
                codeEditor.Location = page.CodeEditorLocation;
                codeEditor.Text = page.Code;
            }
            else
                codeEditor.Visible = false;
            characterImage.Image = page.Person;
            characterImage.Location = new Point(49, 83);
            characterImage.Size = new Size(246, 365);
            dialogLabel.Size = new Size(700, 100);
            dialogLabel.Text = string.Empty;
            foreach (char item in page.Dialog)
            {
                dialogLabel.Text += item;
                await Task.Delay(20);
            }
            novellaForm.BackgroundImage = page.Background;
        }
    }
}
