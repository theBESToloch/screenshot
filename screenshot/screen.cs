using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace screenshot
{
    public partial class screen : Form
    {
        private Bitmap printscreen, restangle;
        Graphics graphics;
        private Screenshot refForm;
        

        public screen(Screen scr, Screenshot refForm)
        {
            InitializeComponent();
            this.refForm = refForm;

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.AllowTransparency = true;
            
            this.TransparencyKey = this.BackColor;//он же будет заменен на прозрачный цвет
            printscreen = new Bitmap(scr.Bounds.Width , scr.Bounds.Height);

            

            graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(scr.Bounds.X, scr.Bounds.Y, 0, 0, printscreen.Size);
            pictureBox1.BackgroundImage = printscreen;
            graphics.Dispose();
            restangle = new Bitmap(scr.Bounds.Width, scr.Bounds.Height);
            graphics = Graphics.FromImage(restangle);
        }

        private Point one_, two_, one;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            one_ = new Point(e.X, e.Y);
            if (one.IsEmpty == true)
            {
                 one = one_;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            two_ = new Point(e.X, e.Y);
            if (Math.Abs(one.X - two_.X) != 0 && Math.Abs(one.Y - two_.Y) != 0)
            {
                refForm.dispose_form(new Point(this.Location.X, this.Location.Y), one, two_);
            }
        }

        Brush brush = new SolidBrush(Color.FromArgb(128, 128, 0, 0));
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (one_.IsEmpty != true)
            {
                graphics.Clear(Color.Transparent);
                graphics.DrawRectangle(new Pen(Color.Red), Math.Min(one.X, e.X), Math.Min(one.Y, e.Y), Math.Abs(one.X - e.X), Math.Abs(one.Y - e.Y));
                graphics.FillRectangle(brush, Math.Min(one.X, e.X), Math.Min(one.Y, e.Y), Math.Abs(one.X - e.X), Math.Abs(one.Y - e.Y));
                pictureBox1.Image = restangle;
            }
        }
    }
}
