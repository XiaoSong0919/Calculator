using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        //string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string change_b1 = "0";
        string change_b2 = "0";
        string void_b1;
        //string save_void;
        string void_b3;
        bool tmp = false;
        Form1 f1 = new Form1();
        //string save_void;
        public Form3()
        {
            InitializeComponent();
        }
       
        private void Form3_Load(object sender, EventArgs e)
        {
            if (File.Exists(f1.path + "/use.txt"))
            {
                f1.readtxt("use");
            }

            if (File.Exists(f1.path + "/Calculator/history.txt"))
            {
                f1.readtxt("history");
                if (f1.save_void == "1")
                {
                    checkBox1.Checked = true;
                    void_b1 = "1";
                }
            }
            if (File.Exists(f1.path + "/Calculator/update.txt"))
            {
                f1.readtxt("update");
                if (f1.save_void == "1")
                {
                    checkBox3.Checked = true;
                    void_b3 = "1";
                }
            }
            button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f1.writetxt(void_b1, "history",false);
            f1.writetxt(void_b3, "update",false);
            button3.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                void_b1 = "1";
            }
            else
            {
                void_b1 = "0";
            }
            button3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1.writetxt(void_b1, "history", false);
            f1.writetxt(void_b3, "update", false);
            this.Close();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                void_b3 = "1";
            }
            else
            {
                void_b3 = "0";
            }
            button3.Enabled = true;
        }

        
    }
}
