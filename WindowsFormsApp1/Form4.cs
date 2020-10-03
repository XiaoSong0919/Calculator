using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Web;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        Form1 f1 = new Form1();
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string save_void;
        public double version = 1.32;
        double new_version;
        
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f1.check_update();

            
        }
       
        

        private void Form4_Load(object sender, EventArgs e)
        {
            timer2.Interval = 100;
            timer2.Enabled = true;
            version = f1.version;
            label6.Text = "v" + version;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("更新失败：连接超时", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = f1.vulue;
            label4.Text = "v" + f1.save_void;
        }
    }
}
