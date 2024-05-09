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
        private CustomUserControl menuFrame;
        private Label buttonMainMenu, buttonSave, buttonLoad, buttonClose, labelTitle;
        private Sound effect;
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
            #region Declaration of variables
            characterImage = new PictureBox();
            codeEditor = new TextBox();
            menu = new PictureBox();
            menuFrame = new CustomUserControl();
            buttonMainMenu = new Label();
            buttonSave = new Label();
            buttonLoad = new Label();
            buttonClose = new Label();
            menuFrame = new CustomUserControl { Controls = {buttonMainMenu, buttonSave, buttonLoad, buttonClose } };
            nextPage = new PictureBox();
            previousPage = new PictureBox();
            labelTitle = new Label();
            nextPageWhite = new PictureBox();
            previousPageWhite = new PictureBox();
            dialogLabel = new CustomLabel { Controls = { nextPage, previousPage} };
            effect = new Sound();
            #endregion

            novellaForm = new Form
            {
                Controls = { menuFrame,codeEditor, dialogLabel, characterImage, menu, labelTitle, nextPageWhite, previousPageWhite }
            };

            pages = new List<NovellaPage>
            {
                new NovellaPage("Monday"),
                new NovellaPage(Setting.Name,Properties.Resources.girl,Properties.Resources.back),
                new NovellaPage(Setting.Gender.ToString(),Properties.Resources.girl,Properties.Resources.back),
                new NovellaPage("You need to work",Properties.Resources.girl,Properties.Resources.back,"return 5;",new Point(0,0)),
            };

            #region Design and events
            characterImage.BackColor = Color.Transparent;
            characterImage.SizeMode = PictureBoxSizeMode.StretchImage;

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
            typeof(Form).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            novellaForm, new object[] { true });
            novellaForm.KeyDown += Novella_KeyDown;

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
            //добавить метод для сериализации в JSON (int i, string Name, Gender Gender)
            //сохранять с следующим текстом: {Локация}, {дата} {время}
            //3 поля сохранения

            buttonLoad.Text = "Load";
            buttonLoad.Location = new Point((420 - buttonLoad.Width) / 2, 110);
            //выбор 1 из 3 полей сохранения

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

            menuFrame.BorderColor = Color.Black;
            menuFrame.BorderThickness = 3;
            menuFrame.Opacity = 150;
            menuFrame.Radius = 10;
            menuFrame.TransparentBackColor = Color.Gray;
            menuFrame.Size = new Size(400, 200);
            menuFrame.Left = (ClientSize.Width - menuFrame.Width) / 2;
            menuFrame.Top = (ClientSize.Height - menuFrame.Height) / 2;
            menuFrame.MouseEnter += MenuFrame_MouseEnter;
            menuFrame.MouseLeave += MenuFrame_MouseLeave;
            menuFrame.VisibleChanged += MenuFrame_VisibleChanged;

            foreach (PictureBox item in new PictureBox[] { nextPage, nextPageWhite })
            {
                item.BackColor = Color.Transparent;
                item.SizeMode = PictureBoxSizeMode.StretchImage;
                item.Size = new Size(30, 30);
                item.Click += (s, e) => CreatePage(pages[++i]);
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

            #endregion

            novellaForm.Show();

            CreatePage(pages[i]);
        }

        private void MenuFrame_VisibleChanged(object sender, EventArgs e)
        {
            if (!menuFrame.Visible)
                novellaForm.Click -= MenuFrameBack_Click;
        }

        private void PreviousPage_Click(object sender, EventArgs e)
        {
            if ((i - 1) >= 0)
                CreatePage(pages[--i]);
        }

        private void MenuFrame_MouseLeave(object sender, EventArgs e) => novellaForm.Click += MenuFrameBack_Click;

        private void MenuFrame_MouseEnter(object sender, EventArgs e) => novellaForm.Click -= MenuFrameBack_Click;

        private void MenuFrameBack_Click(object sender, EventArgs e) => menuFrame.Visible = !menuFrame.Visible;
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
                        CreatePage(pages[--i]);
                    break;
                case Keys.Escape:
                    menuFrame.Visible = !menuFrame.Visible;
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
            codeEditor.Enabled = false;
            Invisibility(labelTitle, codeEditor, dialogLabel, characterImage, nextPageWhite, previousPageWhite, menuFrame);
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
                Visibility(characterImage, dialogLabel);
                characterImage.Image = page.Person;
                characterImage.Location = new Point(49, 83);
                characterImage.Size = new Size(246, 365);
                dialogLabel.Size = new Size(700, 100);
                dialogLabel.Text = string.Empty;
                effect.Play(Properties.Resources.typing);
                foreach (char item in page.Dialog)
                {
                    dialogLabel.Text += item;
                    await Task.Delay(20);
                }
                effect.Stop();
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
