using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Reflection;
using visualnovella.Classes;
using System.Linq;

namespace visualnovella
{
    public partial class Form1 : Form
    {
        private int i = -1;
        private bool back;
        private PictureBox characterImage, menu, nextPage, previousPage, nextPageWhite, previousPageWhite;
        private CustomLabel dialogLabel;
        private TextBox codeEditor;
        private Form novellaForm;
        private CustomUserControl menuFrame, saveLoadFrame;
        private Label buttonMainMenu, buttonSave, buttonLoad, buttonClose, labelTitle;
        private Sound effect, music;
        private Button save1, save2, save3;
        private string action;
        private string[] scenario;
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
                string[] savesList = FileManage.GetFilesFromFolder(FileManage.pathForSave + "\\" + i);
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
            scenario = FileManage.ReadFromFile();
            #endregion



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

            characterImage.Location = new Point(49, 83);
            characterImage.Size = new Size(246, 365);
            characterImage.Visible = true;

            dialogLabel.Visible = true;
            dialogLabel.Size = new Size(700, 100);

            novellaForm.BackColor = DefaultBackColor;

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
                    GoForward();
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
            Invisibility(labelTitle, codeEditor, nextPageWhite, previousPageWhite, menuFrame, saveLoadFrame);
            novellaForm.Show();
            GoForward();
            GoForward();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Button save = sender as Button;
            if (action == "Save")
            {
                FileManage.ClearFiles(save.Tag.ToString());
                string saveName = NovellaScenario.CurrentLocation + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute;
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
                GoForward();
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
                    GoForward();
                    break;
                case Keys.Space:
                    GoForward();
                    break;
                case Keys.Left:
                    if ((i-1) >= 0)
                    {
                        GoBack();
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
        private void GoBack()
        {
            --i;
            GeneratePage();
        }
        private void GoForward()
        {
            ++i;
            GeneratePage();
        }

        private async void GeneratePage()
        {
            if (scenario[i].Trim() == "***")
            {
                ++i;
                string[] changes = scenario[i].Replace(" ", "").Split('|');
                if (changes[0].Split(':')[0] == "Back")
                {
                    NovellaScenario.CurrentBackground = Properties.Resources.ResourceManager.GetObject(changes[0].Split(':')[1]) as Bitmap;
                    NovellaScenario.CurrentLocation = changes[0].Split(':')[1];
                    novellaForm.BackgroundImage = NovellaScenario.CurrentBackground;
                }
                else
                {
                    NovellaScenario.CurrentCharacter = Properties.Resources.ResourceManager.GetObject(changes[0].Split(':')[1]) as Bitmap;
                    characterImage.Image = NovellaScenario.CurrentCharacter;
                }
                if (changes.Length == 2)
                {
                    NovellaScenario.CurrentCharacter = Properties.Resources.ResourceManager.GetObject(changes[1].Split(':')[1]) as Bitmap;
                    characterImage.Image = NovellaScenario.CurrentCharacter;
                }
                ++i;
                return;
            }
            else if (scenario[i].Trim() == "****")
            {

            }
            else
            {
                dialogLabel.Text = string.Empty;
                if (scenario[i].Contains("[player]"))
                    scenario[i] = scenario[i].Replace("[player]", Setting.Name);
                foreach (char item in scenario[i])
                {
                    dialogLabel.Text += item;
                    await Task.Delay(10);
                }
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
