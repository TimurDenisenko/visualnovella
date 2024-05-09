using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace visualnovella
{
    internal class CustomLabel : Label
    {
        private int radius = 10;
        private Color borderColor = Color.Black;
        private int borderThickness = 1;
        private int opacity;
        public CustomLabel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
        }
        public int Opacity
        {
            get { return opacity; }
            set
            {
                if (value >= 0 && value <= 255)
                    opacity = value;
                this.Invalidate();
            }
        }

        public Color transparentBackColor;
        public Color TransparentBackColor
        {
            get { return transparentBackColor; }
            set
            {
                transparentBackColor = value;
                this.Invalidate();
            }
        }

        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return Color.Transparent;
            }
            set
            {
                base.BackColor = Color.Transparent;
            }
        }
        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        public int BorderThickness
        {
            get { return borderThickness; }
            set
            {
                borderThickness = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, 2 * radius, 2 * radius, 180, 90);
            path.AddArc(Width - 2 * radius, 0, 2 * radius, 2 * radius, 270, 90);
            path.AddArc(Width - 2 * radius, Height - 2 * radius, 2 * radius, 2 * radius, 0, 90);
            path.AddArc(0, Height - 2 * radius, 2 * radius, 2 * radius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);
            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                e.Graphics.DrawPath(pen, path);
            }
            if (Parent != null)
            {
                using (var bmp = new Bitmap(Parent.Width, Parent.Height))
                {
                    Parent.Controls.Cast<Control>()
                          .Where(c => Parent.Controls.GetChildIndex(c) > Parent.Controls.GetChildIndex(this))
                          .Where(c => c.Bounds.IntersectsWith(this.Bounds))
                          .OrderByDescending(c => Parent.Controls.GetChildIndex(c))
                          .ToList()
                          .ForEach(c => c.DrawToBitmap(bmp, c.Bounds));


                    e.Graphics.DrawImage(bmp, Left, Top);
                    using (var b = new SolidBrush(Color.FromArgb(this.Opacity, this.TransparentBackColor)))
                    {
                        e.Graphics.FillRectangle(b, this.ClientRectangle);
                    }
                    Rectangle textRect = new Rectangle(ClientRectangle.X + 15, ClientRectangle.Y+15, ClientRectangle.Width, ClientRectangle.Height);
                    TextRenderer.DrawText(e.Graphics, Text, this.Font, textRect, this.ForeColor, Color.Transparent, TextFormatFlags.Left | TextFormatFlags.Top);
                }
            }
        }
    }
}