using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RightClickSimulate
{
    public partial class frmMain : Form
    {
        bool isStatic = false;

        MouseButtons clickedButton = MouseButtons.None;
        Point firstMouseDown = new Point();
        Point firstFormPos = new Point();

        public frmMain()
        {
            InitializeComponent();
        }

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        public void DoMouseClick(MouseEventFlags firstEvent, MouseEventFlags secondEvent, Point position)
        {
            Point curPos = Cursor.Position;
            int X = position.X;
            int Y = position.Y;
            Cursor.Position = new Point(X - 1, Y - 1);
            mouse_event((int)firstEvent | (int)secondEvent, X, Y, 0, 0);
        }

        private Color GetReadableForeColor(Color c)
        {
            return Color.FromArgb(c.R ^ 0x80, c.G ^ 0x80, c.B ^ 0x80);
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            clickedButton = e.Button;
            firstMouseDown = Cursor.Position;
            firstFormPos = this.Location;
        }
        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (clickedButton != MouseButtons.None)
            {
                if (Cursor.Position.X > firstMouseDown.X)
                {
                    this.Left = firstFormPos.X + (Cursor.Position.X - firstMouseDown.X);
                }
                else if (Cursor.Position.X < firstMouseDown.X)
                {
                    this.Left = firstFormPos.X - (firstMouseDown.X - Cursor.Position.X);
                }

                if (Cursor.Position.Y > firstMouseDown.Y)
                {
                    this.Top = firstFormPos.Y + (Cursor.Position.Y - firstMouseDown.Y);
                }
                else if (Cursor.Position.Y < firstMouseDown.Y)
                {
                    this.Top = firstFormPos.Y - (firstMouseDown.Y - Cursor.Position.Y);
                }
            }
        }
        private void frmMain_MouseUp(object sender, MouseEventArgs e)
        {
            //if (ModifierKeys != Keys.Control)
            //{
            //    switch (clickedButton)
            //    {
            //        case MouseButtons.Left:
            //            DoMouseClick(MouseEventFlags.LEFTDOWN, MouseEventFlags.LEFTUP, this.Location);
            //            break;
            //        case MouseButtons.Middle:
            //            DoMouseClick(MouseEventFlags.MIDDLEDOWN, MouseEventFlags.MIDDLEUP, this.Location);
            //            break;
            //        case MouseButtons.Right:
            //            DoMouseClick(MouseEventFlags.RIGHTDOWN, MouseEventFlags.RIGHTUP, this.Location);
            //            break;
            //    }
            //}

            if (clickedButton == MouseButtons.Left)
            {
                DoMouseClick(MouseEventFlags.RIGHTDOWN, MouseEventFlags.RIGHTUP, this.Location);
            }

            clickedButton = MouseButtons.None;

            if (isStatic)
                this.Location = firstFormPos;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            sysTray.Visible = true;
        }
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                //clickedButton = MouseButtons.None;

                //if (MessageBox.Show(this, "Are you sure want to exit?", "Exit?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                //{
                Application.Exit();
                //}
            }
        }
        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(250, 200);
            Graphics g = this.CreateGraphics();
            g = Graphics.FromImage(bmp);
            g.CopyFromScreen(this.Location.X - 20, this.Location.Y - 20, 10, 10, new Size(100, 100));

            Bitmap bmpZoom = bmp;
            g = Graphics.FromImage(bmpZoom);

            int new4W = Convert.ToInt32(bmp.Width / 2.5);
            int new4H = Convert.ToInt32(bmp.Height / 2.5);
            int new2W = bmp.Width / 2;
            int new2H = bmp.Height / 2;

            Rectangle srcRect = new Rectangle(new4W - 88, new4H - 68, new2W, new2H);
            Rectangle dstRect = new Rectangle(0, 0, bmpZoom.Width, bmpZoom.Height);
            g.DrawImage(bmp, dstRect, srcRect, GraphicsUnit.Pixel);

            this.BackgroundImage = bmp;

            GraphicsPath myPath = new GraphicsPath();
            GraphicsPath myPath2 = new GraphicsPath();

            Point[] myArray2 =
             {
                 new Point(20,40),
                 new Point(0,0),
                 new Point(40,20),
                 new Point(40,40)
             };

            myPath2.AddLines(myArray2);
            myPath.AddPath(myPath2, true);

            this.Region = new Region(myPath);

            e.Graphics.DrawRectangle(new Pen(GetReadableForeColor((this.BackgroundImage as Bitmap).GetPixel(10, 10)), 20), this.DisplayRectangle);
        }

        private void frmMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (cntMnuSysTray.Visible)
            {
                cntMnuSysTray.Close();
            }
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            sysTray.Visible = false;
        }

        private void cntMnuSysTray_Static_CheckedChanged(object sender, EventArgs e)
        {
            isStatic = cntMnuSysTray_Static.Checked;
        }
        private void cntMnuSysTray_Exit_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show(this, "Are you sure want to exit?", "Exit?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            //{
            Application.Exit();
            //}
        }

        private void cntMnuSysTray_MouseLeave(object sender, EventArgs e)
        {
            cntMnuSysTray.Close();
        }

        private void sysTray_MouseClick(object sender, MouseEventArgs e)
        {
            cntMnuSysTray.Show(Control.MousePosition);
        }
        private void sysTray_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(sysTray, null);
            }
        }

    }
}
