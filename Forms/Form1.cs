using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Reflection;
using visualnovella.Classes;

namespace visualnovella
{
    public partial class Form1 : Form
    {
        private List<NovellaPage> pages;
        private int i;
        private PictureBox characterImage, menu, nextPage, previousPage, nextPageWhite, previousPageWhite;
        private CustomLabel dialogLabel;
        private TextBox codeEditor;
        private Form novellaForm;
        private CustomUserControl menuFrame, saveLoadFrame;
        private Label buttonMainMenu, buttonSave, buttonLoad, buttonClose, labelTitle;
        private Sound effect, music;
        private Button save1, save2, save3;
        private string action;
        public Form1()
        {
            InitializeComponent();
            newgame.MouseEnter += btn_MouseEnter;
            newgame.MouseLeave += btn_MouseLeave;
            _continue.MouseEnter += btn_MouseEnter;
            _continue.MouseLeave += btn_MouseLeave;
            exit.MouseEnter += btn_MouseEnter;
            exit.MouseLeave += btn_MouseLeave;

            save1 = new Button();
            save2 = new Button();
            save3 = new Button();
            saveLoadFrame = new CustomUserControl { Controls = { save1, save2, save3 }, Visible = false, };
            menuFrame = new CustomUserControl { };
            foreach (CustomUserControl item in new CustomUserControl[] { menuFrame, saveLoadFrame })
            {
                item.BorderColor = Color.Black;
                item.BorderThickness = 3;
                item.Opacity = 150;
                item.Radius = 10;
                item.TransparentBackColor = Color.Gray;
                item.Size = new Size(400, 200);
                item.Left = (ClientSize.Width - menuFrame.Width) / 2;
                item.Top = (ClientSize.Height - menuFrame.Height) / 2;
                item.MouseEnter += Menu_MouseEnter2;
                item.MouseLeave += Menu_MouseLeave2;
                item.VisibleChanged += Menu_VisibleChanged2;
            }

            Button[] saves = new Button[] { save1, save2, save3 };
            foreach (Button item in saves)
            {
                item.Size = new Size(saveLoadFrame.Width - 50, saveLoadFrame.Height / 4);
                item.Font = new Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Point, 204);
                item.BackColor = Color.Gray;
                item.Left = (saveLoadFrame.Width - item.Width) / 2;
                item.Click += Save_Click;
            }
            for (int i = 0; i < 3; i++)
            {
                string[] savesList = FileManage.GetFilesFromFolder(FileManage.path + "\\" + i);
                saves[i].Tag = i;
                try
                {
                    saves[i].Text = savesList[0];
                }
                catch (Exception)
                {
                    saves[i].Text = "Empty";
                }
            }
            save1.Top = 15;
            save2.Top = 75;
            save3.Top = 135;

            Controls.Add(saveLoadFrame);
            newgame.SendToBack();
            _continue.SendToBack();
            exit.SendToBack();
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

        private void _continue_Click(object sender, EventArgs e)
        {
            saveLoadFrame.Visible = true;
            action = "Load";
        }

        private void Game()
        {
            #region Declaration of variables
            characterImage = new PictureBox();
            codeEditor = new TextBox();
            menu = new PictureBox();
            menuFrame = new CustomUserControl();
            buttonMainMenu = new Label();
            buttonSave = new Label();
            buttonLoad = new Label();
            buttonClose = new Label();
            menuFrame.Controls.AddRange(new Label[] { buttonMainMenu, buttonSave, buttonLoad, buttonClose });
            nextPage = new PictureBox();
            previousPage = new PictureBox();
            labelTitle = new Label();
            nextPageWhite = new PictureBox();
            previousPageWhite = new PictureBox();
            dialogLabel = new CustomLabel { Controls = { nextPage, previousPage } };
            effect = new Sound();
            #endregion


            pages = new List<NovellaPage>
            {
                new NovellaPage("Monday","none"),
                new NovellaPage("MH - (No way, first day of new university and I’m late)",Properties.Resources.MH,Properties.Resources.university,"University"),
                new NovellaPage("MH - (Where is this classroom A398?)",Properties.Resources.MH,Properties.Resources.university,"University"),
                new NovellaPage("Anna - Hi, you look lost. Don't know where your classroom is?",Properties.Resources.anna,Properties.Resources.university,"University"),
                new NovellaPage("MH - Hi, yep, I can’t find A398.",Properties.Resources.MH,Properties.Resources.university,"University"),
                new NovellaPage("Anna - My name is Anna, what is your name?",Properties.Resources.anna,Properties.Resources.university,"University"),
                new NovellaPage("MH - "+Setting.Name,Properties.Resources.MH,Properties.Resources.university,"University"),
                new NovellaPage("Anna - Nice to meet you. Let me show you where your classroom is. I have a lecture nearby.",Properties.Resources.anna,Properties.Resources.university,"University"),
                new NovellaPage("MH - Let’s go",Properties.Resources.MH,Properties.Resources.university,"University"),
                new NovellaPage("Anna - Here is the classroom A398. So, bye bye.",Properties.Resources.anna,Properties.Resources.corridor,"Corridor"),
                new NovellaPage("MH - Bye, bye! Thank you!",Properties.Resources.MH,Properties.Resources._class,"Class"),
                new NovellaPage("MH - (She ran to her classroom so fast, I think she was already late when we met. At least she helped me)",Properties.Resources.MH,Properties.Resources._class,"Class"),
                new NovellaPage("… … …",Properties.Resources.MH,Properties.Resources._class,"Class"),
                new NovellaPage("MH - (First day and we have a lecture for about 4 hours. \nNow it has become soooo boring. Only after 2 hours is end)",Properties.Resources.MH,Properties.Resources._class,"Class"),
                new NovellaPage("… … …",Properties.Resources.MH,Properties.Resources._class,"Class"),
                new NovellaPage("Teacher - Now I am gonna explain you, some basics of C#. ",Properties.Resources.MH,Properties.Resources._class,"Class"),
                new NovellaPage("Task: Calculating the sum of numbers\r\n\r\nYour friend is planning a party and decided to make it more interesting by holding a competition for \nthe most creative pair of numbers. \nHe wants to create a program that will allow participants to quickly find out the sum of any pair of numbers.\n You need to return 5",
                Properties.Resources.computer,
                "using System;\r\n return Sum(x, y);\r\n     \r\n public static int Sum(int x, int y)\r\n        {\r\n            return;\r\n}\r\n",
                new Point(120,170), "Computer"),
                new NovellaPage("MH - (Finally, a break! I need some caffeine.)",Properties.Resources.MH,Properties.Resources.corridor,"Corridor"),
                new NovellaPage("...",Properties.Resources.MH,Properties.Resources.dining,"Caffeine"),
                new NovellaPage($"David - Oh, Hi {Setting.Name}. Do you remember me? We studied in the same primary school. ",Properties.Resources.David,Properties.Resources.dining,"Caffeine"),
                new NovellaPage("MH - Hi David! As you can see, I still remember you. What course did you enroll in?",Properties.Resources.MH,Properties.Resources.dining,"Caffeine"),
                new NovellaPage("David - Informatic systems. And you? ",Properties.Resources.David,Properties.Resources.dining,"Caffeine"),
            };

            novellaForm = new Form
            {
                Controls = { saveLoadFrame, menuFrame, codeEditor, dialogLabel, characterImage, menu, labelTitle, nextPageWhite, previousPageWhite }
            };

            novellaForm.KeyPreview = true;
            novellaForm.KeyDown += Novella_KeyDown;

            #region Design and events
            characterImage.BackColor = Color.Transparent;
            characterImage.SizeMode = PictureBoxSizeMode.StretchImage;

            dialogLabel.BorderColor = Color.Black;
            dialogLabel.BorderThickness = 3;
            dialogLabel.Font = new Font("Arial", 7.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
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

            typeof(Form).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            novellaForm, new object[] { true });

            menu.Location = new Point(10,10);
            menu.BackColor = Color.Transparent;
            menu.Image = Properties.Resources.menu;
            menu.SizeMode = PictureBoxSizeMode.StretchImage;
            menu.Size = new Size(50, 50);
            menu.Click += (s, e) => menuFrame.Visible = true;

            buttonMainMenu.Text = "Main screen";
            buttonMainMenu.Location = new Point((360 - buttonMainMenu.Width) / 2, 30);
            buttonMainMenu.Click += (s, e) => Application.Restart();

            buttonSave.Text = "Save";
            buttonSave.Location = new Point((420 - buttonSave.Width) / 2, 70);
            buttonSave.Click += MenuSave_Click;

            buttonLoad.Text = "Load";
            buttonLoad.Location = new Point((420 - buttonLoad.Width) / 2, 110);
            buttonLoad.Click += MenuSave_Click;

            buttonClose.Text = "Close";
            buttonClose.Location = new Point((420 - buttonClose.Width) / 2, 150);
            buttonClose.Click += (s, e) => menuFrame.Visible = false;

            foreach (Label item in new Label[] { buttonMainMenu, buttonSave, buttonLoad, buttonClose})
            {
                item.Font = new Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Point, 204);
                item.AutoSize = true;
                item.MouseEnter += (s, e) => item.ForeColor = Color.White;
                item.MouseLeave += (s, e) => item.ForeColor = Color.Black;
            }

            foreach (PictureBox item in new PictureBox[] { nextPage, nextPageWhite })
            {
                item.BackColor = Color.Transparent;
                item.SizeMode = PictureBoxSizeMode.StretchImage;
                item.Size = new Size(30, 30);
                item.Click += (s, e) =>
                {
                    CreatePage(pages[++i]);
                };
            }

            foreach (CustomUserControl item in new CustomUserControl[] { menuFrame, saveLoadFrame })
            {
                item.MouseEnter += Menu_MouseEnter;
                item.MouseLeave += Menu_MouseLeave;
                item.VisibleChanged += Menu_VisibleChanged;
                item.MouseEnter -= Menu_MouseEnter2;
                item.MouseLeave -= Menu_MouseLeave2;
                item.VisibleChanged -= Menu_VisibleChanged2;
            }

            nextPage.Location = new Point(dialogLabel.Width - 30, dialogLabel.Height - 30);
            nextPage.Image = Properties.Resources.forward;
            nextPage.MouseEnter += (s,e) => nextPage.Image = Properties.Resources.forwardWhite;
            nextPage.MouseLeave += (s, e) => nextPage.Image = Properties.Resources.forward;

            nextPageWhite.Location = new Point(dialogLabel.Right - 30, dialogLabel.Bottom - 30);
            nextPageWhite.Image = Properties.Resources.forwardWhite;

            foreach (PictureBox item in new PictureBox[] { previousPage, previousPageWhite })
            {
                item.BackColor = Color.Transparent;
                item.SizeMode = PictureBoxSizeMode.StretchImage;
                item.Size = new Size(30, 30);
                item.Click += PreviousPage_Click;
            }

            Image tempImage = new Bitmap(Properties.Resources.forward);
            tempImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            Image tempImageWhite = new Bitmap(Properties.Resources.forwardWhite);
            tempImageWhite.RotateFlip(RotateFlipType.Rotate180FlipNone);
            previousPage.Image = tempImage;
            previousPage.Location = new Point(0, dialogLabel.Height - 30);
            previousPage.MouseEnter += (s, e) => previousPage.Image = tempImageWhite;
            previousPage.MouseLeave += (s, e) => previousPage.Image = tempImage;

            previousPageWhite.Location = new Point(dialogLabel.Left, dialogLabel.Bottom - 30);
            previousPageWhite.Image = tempImageWhite;

            labelTitle.Font = new Font("Arial", 25, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.White;
            labelTitle.AutoSize = true;

            music = new Sound();
            music.Music();
            #endregion

            novellaForm.Show();

            CreatePage(pages[i]);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Button save = sender as Button;
            if (action == "Save")
            {
                FileManage.ClearFiles(save.Tag.ToString());
                string saveName = pages[i].Location + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute;
                FileManage.SerializeToFile(new SaveClass(i, Setting.Name, Setting.Gender), save.Tag + "\\" + saveName);
                save.Text = saveName;
            }
            else
            {
                SaveClass saved = FileManage.DeserializeFromFile<SaveClass>(save.Tag.ToString());
                Setting.Name = saved.Name;
                Setting.Gender = saved.Gender;
                i = saved.PageNum;
                this.Hide();
                Game();
            }
        }
        private void MenuSave_Click(object sender, EventArgs e)
        {
            saveLoadFrame.Visible = true;
            Label button = sender as Label;
            action = button.Text;
        }
        private void Menu_VisibleChanged(object sender, EventArgs e)
        {
            if (!menuFrame.Visible)
                novellaForm.Click -= MenuFrameBack_Click;
        }
        private void Menu_VisibleChanged2(object sender, EventArgs e)
        {
            if (!menuFrame.Visible)
                this.Click -= MenuFrameBack_Click2;
        }
        private void PreviousPage_Click(object sender, EventArgs e)
        {
            if ((i - 1) >= 0)
            {
                CreatePage(pages[--i]);
            }
        }
        private void Menu_MouseLeave(object sender, EventArgs e) => novellaForm.Click += MenuFrameBack_Click;

        private void Menu_MouseEnter(object sender, EventArgs e) => novellaForm.Click -= MenuFrameBack_Click;

        private void MenuFrameBack_Click(object sender, EventArgs e) 
        {
            menuFrame.Visible = !menuFrame.Visible;
            if (saveLoadFrame.Visible)
                saveLoadFrame.Visible = false;
        }

        private void Menu_MouseLeave2(object sender, EventArgs e) => this.Click += MenuFrameBack_Click2;

        private void Menu_MouseEnter2(object sender, EventArgs e) => this.Click -= MenuFrameBack_Click2;

        private void MenuFrameBack_Click2(object sender, EventArgs e)
        {
            if (saveLoadFrame.Visible)
                saveLoadFrame.Visible = false;
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
                    if ((i-1) >= 0)
                    {
                        CreatePage(pages[--i]);
                    }
                    break;
                case Keys.Escape:
                    menuFrame.Visible = !menuFrame.Visible;
                    if (saveLoadFrame.Visible)
                        saveLoadFrame.Visible = false;
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

        private void CreatePage(NovellaPage page)
        {
            codeEditor.Enabled = false;
            Invisibility(labelTitle, codeEditor, dialogLabel, characterImage, nextPageWhite, previousPageWhite, menuFrame, saveLoadFrame);
            if (page.PageType == PageType.Code || page.PageType == PageType.Text)
            {
                if (page.PageType == PageType.Code)
                {
                    codeEditor.Enabled = true;
                    codeEditor.Visible = true;
                    codeEditor.Size = new Size(200, 200);
                    codeEditor.Location = page.CodeEditorLocation;
                    codeEditor.Text = page.Code;
                }
                else
                {
                    characterImage.Image = page.Person;
                    characterImage.Location = new Point(49, 83);
                    characterImage.Size = new Size(246, 365);
                    characterImage.Visible = true;
                }
                dialogLabel.Visible = true;
                dialogLabel.Size = new Size(700, 100);
                dialogLabel.Text = page.Dialog;
                novellaForm.BackgroundImage = page.Background;
                novellaForm.BackColor = DefaultBackColor;
            }
            else if (page.PageType == PageType.Empty)
            {
                Visibility(labelTitle, nextPageWhite, previousPageWhite);
                labelTitle.Text = page.Title;
                labelTitle.Left = (ClientSize.Width - labelTitle.Width) / 2;
                labelTitle.Top = (ClientSize.Height - labelTitle.Height) / 2;
                novellaForm.BackColor = Color.Black;
                novellaForm.BackgroundImage = null;
            }
        }
        private void Visibility(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.Visible = true;
            }
        }
        private void Invisibility(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.Visible = false;
            }
        }
    }
}
