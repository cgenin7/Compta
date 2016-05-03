using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Compta.CustomControls
{
    public class TabControlEx : TabControl
    {
        protected override void OnCreateControl()
        {
            this.SetStyle(ControlStyles.DoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint |
               ControlStyles.SupportsTransparentBackColor,true);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            Invalidate();
            base.OnMouseEnter(e);
            
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnSystemColorsChanged(EventArgs e)
        {
            Invalidate();
            base.OnSystemColorsChanged(e);
        }

        protected virtual void DrawTabPage(Graphics graphics, int index, TabPage page)
        {
            Brush backgroundBrush;
            Brush textBrush = Brushes.White;

            int textwidth = (int)graphics.MeasureString(page.Text, this.Font).Width;

            Rectangle r = GetTabRect(index);
            Point p = this.PointToClient(Cursor.Position);

            bool highlight = new Rectangle(p.X, p.Y, 1, 1).IntersectsWith(r);

            if (index == SelectedIndex)
            {
                textBrush = Brushes.Black;

                backgroundBrush = new LinearGradientBrush(r, CustomColors.LightYellow, CustomColors.DarkYellow, LinearGradientMode.Vertical);
                if (Alignment == TabAlignment.Top)
                {
                    r.X -= 2;
                    r.Width += 2;
                    r.Height += 5;
                }
                else if (Alignment == TabAlignment.Left)
                {
                    r.Width += 3;
                    r.Height += 2;
                }
            }
            else
            {
                if (Alignment == TabAlignment.Top)
                {
                    r.Height += 1;
                }
                else if (Alignment == TabAlignment.Left)
                {
                    r.Width += 1;
                }

                if (highlight)
                {
                    backgroundBrush = new LinearGradientBrush(r, ControlPaint.Light(CustomColors.DarkBlue), ControlPaint.LightLight(CustomColors.DarkBlue), LinearGradientMode.Vertical);
                }
                else
                    backgroundBrush = new SolidBrush(CustomColors.DarkBlue);
            }

            GraphicsPath path;
            if (Alignment == TabAlignment.Top)
                path = RoundedRectangle.Create(r, 1, RoundedRectangle.RectangleCorners.TopLeft | RoundedRectangle.RectangleCorners.TopRight);
            else
                path = RoundedRectangle.Create(r, 1, RoundedRectangle.RectangleCorners.TopLeft | RoundedRectangle.RectangleCorners.BottomLeft);
            graphics.FillPath(backgroundBrush, path);
           // graphics.FillRectangle(backgroundBrush, r);

            if (Alignment == TabAlignment.Left)
            {
                StringFormat format = new StringFormat(StringFormatFlags.DirectionVertical);
                graphics.DrawString(page.Text, this.Font, textBrush, r.Left + 1, r.Top + (r.Height - textwidth) / 2, format);
                // graphics.DrawRectangle(new Pen(CustomColors.DarkYellow, 3), new Rectangle(r.Width, 0, 1, Height));
            }
            else
            {
                graphics.DrawString(page.Text, this.Font, textBrush, r.Left + (r.Width - textwidth) / 2, r.Top + 2);
                graphics.DrawRectangle(new Pen(CustomColors.DarkYellow, 3), new Rectangle(0, r.Height, Width, 1));
                graphics.DrawRectangle(new Pen(CustomColors.DarkYellow, 3), new Rectangle(0, r.Height, 1, page.ClientRectangle.Height));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;

            e.Graphics.DrawRectangle(new Pen(CustomColors.LightGrey), new Rectangle(0, 0, Width, Height));
            if (Alignment == TabAlignment.Top)
            {
                e.Graphics.FillRectangle(new SolidBrush(CustomColors.DarkBlue), new Rectangle(rec.X, rec.Y, rec.Width, 22));
            }
            else if (Alignment == TabAlignment.Left)
            {
                e.Graphics.FillRectangle(new SolidBrush(CustomColors.DarkBlue), new Rectangle(rec.X, rec.Y, 22, rec.Height));
            }

            for (int i = 0; i < this.TabPages.Count; i++ )
            {
                if (i != SelectedIndex)
                {
                    TabPage page = this.TabPages[i];
                    DrawTabPage(e.Graphics, i, page);
                }
                
            }
            if (SelectedIndex >= 0)
                DrawTabPage(e.Graphics, SelectedIndex, TabPages[SelectedIndex]);
        }
    }
}

