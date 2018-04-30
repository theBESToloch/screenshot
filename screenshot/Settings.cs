using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace screenshot
{
    public partial class Settings : Form
    {
        private string settings = "";
        private Screenshot refForm;

        public Settings(Screenshot refForm, string settings)
        {
            InitializeComponent();
            this.settings = settings;
            this.refForm = refForm;
            textBox1.Text = settings;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = textBox1.Text;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            settings = textBox1.Text;
            refForm.dispose_settings(settings);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
