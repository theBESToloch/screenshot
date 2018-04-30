namespace screenshot
{
    partial class Screenshot
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Screenshot));
            this.Button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.продолжитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.паузаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таймерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.минToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.минToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.минToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.AllowDrop = true;
            this.Button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Button1.Location = new System.Drawing.Point(61, 42);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(148, 34);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "старт";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "screenshot";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.продолжитьToolStripMenuItem,
            this.паузаToolStripMenuItem,
            this.обновитьToolStripMenuItem,
            this.таймерToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 136);
            // 
            // продолжитьToolStripMenuItem
            // 
            this.продолжитьToolStripMenuItem.Name = "продолжитьToolStripMenuItem";
            this.продолжитьToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.продолжитьToolStripMenuItem.Text = "продолжить";
            this.продолжитьToolStripMenuItem.Click += new System.EventHandler(this.продолжитьToolStripMenuItem_Click);
            // 
            // паузаToolStripMenuItem
            // 
            this.паузаToolStripMenuItem.Name = "паузаToolStripMenuItem";
            this.паузаToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.паузаToolStripMenuItem.Text = "пауза";
            this.паузаToolStripMenuItem.Click += new System.EventHandler(this.паузаToolStripMenuItem_Click);
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.обновитьToolStripMenuItem.Text = "обновить";
            this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // таймерToolStripMenuItem
            // 
            this.таймерToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.минToolStripMenuItem1,
            this.минToolStripMenuItem,
            this.минToolStripMenuItem2});
            this.таймерToolStripMenuItem.Name = "таймерToolStripMenuItem";
            this.таймерToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.таймерToolStripMenuItem.Text = "таймер";
            // 
            // минToolStripMenuItem1
            // 
            this.минToolStripMenuItem1.Name = "минToolStripMenuItem1";
            this.минToolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
            this.минToolStripMenuItem1.Text = "1 мин";
            this.минToolStripMenuItem1.Click += new System.EventHandler(this.минToolStripMenuItem1_Click);
            // 
            // минToolStripMenuItem
            // 
            this.минToolStripMenuItem.Name = "минToolStripMenuItem";
            this.минToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.минToolStripMenuItem.Text = "2 мин";
            this.минToolStripMenuItem.Click += new System.EventHandler(this.минToolStripMenuItem_Click);
            // 
            // минToolStripMenuItem2
            // 
            this.минToolStripMenuItem2.Name = "минToolStripMenuItem2";
            this.минToolStripMenuItem2.Size = new System.Drawing.Size(106, 22);
            this.минToolStripMenuItem2.Text = "1 сек";
            this.минToolStripMenuItem2.Click += new System.EventHandler(this.минToolStripMenuItem2_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.настройкиToolStripMenuItem.Text = "настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exitToolStripMenuItem.Text = "exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Screenshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 123);
            this.Controls.Add(this.Button1);
            this.Name = "Screenshot";
            this.Text = "Screenshot";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem таймерToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem минToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem минToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem минToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem паузаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem продолжитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
    }
}

