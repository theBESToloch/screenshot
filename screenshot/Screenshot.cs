using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

namespace screenshot
{
    public partial class Screenshot : Form
    {
        private Settings set;
        string path_settings = "settings";
        string[] settings = new string[1];

        private static Bitmap BM;

        private SoundPlayer player;

        private screen[] scrn;

        private Bitmap Scrnshot_last = null, Scrnshot_next = new Bitmap(1,1);

        private Point one, two;

        private bool play_end = true;

        public Screenshot()
        {
            InitializeComponent();

            notifyIcon1.Visible = false;

            player = new SoundPlayer();

            timer1 = new Timer();
            timer1.Interval = second;
            timer1.Tick += timer1_Tick;

            try
            {
                settings[0] = File.ReadAllLines(path_settings)[0];
                player = new SoundPlayer(settings[0]);
            }
            catch
            {
                player = new SoundPlayer();
            }

        }

        /// <summary>
        /// обработчик события нажатия мышки на кнопку старт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Text = "screenshot";
            WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = true;
            form_transperent();
        }

        /// <summary>
        /// функция запоминания точек границы области и закрытия форм
        /// </summary>
        /// <param name="scrn_"> экземпляр класса screen</param>
        public void dispose_form(Point scrn_pos, Point one_, Point two_)
        {
            one = new Point(scrn_pos.X + one_.X, scrn_pos.Y + one_.Y);
            two = new Point(scrn_pos.X + two_.X, scrn_pos.Y + two_.Y);

            foreach (screen scrn_ in scrn) {
                scrn_.Dispose();
            }

            Scrnshot_last = Screenshot_bitmap();

            timer();
        }

        /// <summary>
       /// функция создания экземпляров класса screenshot(формы) и их отображения на всех экранах 
       /// </summary>
        private void form_transperent()
        {
            int a = Screen.AllScreens.Length;
            scrn = new screen[a];
            for (int i = 0; i < a; i++)
            {
                scrn[i] = new screen(Screen.AllScreens[i], this);
                scrn[i].DesktopBounds = Screen.AllScreens[i].WorkingArea;
                scrn[i].StartPosition = FormStartPosition.Manual;
                scrn[i].Location = new Point(Screen.AllScreens[i].WorkingArea.X, Screen.AllScreens[i].WorkingArea.Y);
                scrn[i].Show();
                scrn[i].Activate();
            }

        }

        /// <summary>
        /// функция запоминания области 
        /// </summary>
        /// <returns></returns>
        private Bitmap Screenshot_bitmap()
        {   
            BM = new Bitmap(Math.Max(one.X, two.X) - Math.Min(one.X, two.X), Math.Max(one.Y, two.Y) - Math.Min(one.Y, two.Y));
            Graphics scr = Graphics.FromImage(BM as Image);

            scr.CopyFromScreen(new Point(Math.Min(one.X, two.X), Math.Min(one.Y, two.Y)),
                                new Point(0, 0),
                                    BM.Size);
            return BM;
        }

        /// <summary>
        /// функция условия проигрывания музыки
        /// </summary>
        private void screenshot_comparison()
        {
            if (play_end == true){
               
                if (!CompareBitmapsFast(Scrnshot_last, Scrnshot_next))
                    try
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }
                    catch
                    {
                        player = new SoundPlayer();
                        backgroundWorker1.RunWorkerAsync(); 
                    }
            }
        }

        /// <summary>
        /// функция сравнения двух изображений
        /// </summary>
        /// <param name="bmp1"></param>
        /// <param name="bmp2"></param>
        /// <returns></returns>
        private static bool CompareBitmapsFast(Bitmap bmp1, Bitmap bmp2)
        {
            if (!bmp1.Size.Equals(bmp2.Size) || !bmp1.PixelFormat.Equals(bmp2.PixelFormat))
            {
                return false;
            }
            int bytes = bmp1.Width * bmp1.Height * (Image.GetPixelFormatSize(bmp1.PixelFormat) / 8);

            bool result = true;
            byte[] b1bytes = new byte[bytes];
            byte[] b2bytes = new byte[bytes];

            BitmapData bitmapData1 = bmp1.LockBits(new Rectangle(0, 0, bmp1.Width - 1, bmp1.Height - 1), ImageLockMode.ReadOnly, bmp1.PixelFormat);
            BitmapData bitmapData2 = bmp2.LockBits(new Rectangle(0, 0, bmp2.Width - 1, bmp2.Height - 1), ImageLockMode.ReadOnly, bmp2.PixelFormat);

            Marshal.Copy(bitmapData1.Scan0, b1bytes, 0, bytes);
            Marshal.Copy(bitmapData2.Scan0, b2bytes, 0, bytes);

            for (int n = 0; n <= bytes - 1; n++)
            {
                if (b1bytes[n] != b2bytes[n])
                {
                    result = false;
                    break;
                }
            }

            bmp1.UnlockBits(bitmapData1);
            bmp2.UnlockBits(bitmapData2);

            return result;
        }

#region обработка сворачивания форм и событий нажатия кнопочек

        /// <summary>
        /// обработка закрытия формы
        /// </summary>
        /// <param neme="sender"></param>
        /// <param name="e"></param>
        /// 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(path_settings, settings, Encoding.UTF8);
            Dispose();
        }

        /// <summary>
        /// правый клик на иконку
        /// </summary>
        private void tray_right_click()
        {
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
        }

        /// <summary>
        /// обработка событий нажатия на значек программы в трее
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {


            }

            if (e.Button == MouseButtons.Right)
            {
                tray_right_click();
            }
        }

        #endregion

#region обработчики кнопочек в трее

        /// <summary>
        /// обновление области
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scrnshot_last = Screenshot_bitmap();
        }

        private void продолжитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            form_transperent();
            Scrnshot_last = null;
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if(settings.Length!=0)
                set = new Settings(this, settings[0]);
            else
                set = new Settings(this, "");
            set.ShowDialog();
        }

        public void dispose_settings(string setting_)
        {
            settings[0] = setting_;
            set.Dispose();
            try
            {
                player.SoundLocation = settings[0];
            }
            catch {
                player = new SoundPlayer();
            }
            timer1.Enabled = true;
        }

#endregion

# region обработчик таймера

        int second = 1000;

        private void timer()
        {
            timer1.Enabled = true;
        }

        private void минToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 60000;
        }

        private void минToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 120000;
        }

        private void минToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Scrnshot_next.Dispose();

                Scrnshot_next = Screenshot_bitmap();

                screenshot_comparison();

            }

            catch (Exception ex)
            {

                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void паузаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

#endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            play_end = false;
            player.PlaySync();
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            play_end = true;
        }
    }
}
