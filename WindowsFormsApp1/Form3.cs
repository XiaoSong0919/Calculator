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
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string change_b1 = "0";
        string void_b1;
        string save_void;
        public Form3()
        {
            InitializeComponent();
        }
       
        private void Form3_Load(object sender, EventArgs e)
        {
            readtxt("history");
            if (save_void == "1")
            {
                checkBox1.Checked = true;
                void_b1 = "1";
            }
            button3.Enabled = false;
        }
        public void readtxt(string filename)
        {
            StreamReader srReadFile = new StreamReader(path + "/Calculator/" + filename + ".txt");

            save_void = Regex.Replace(srReadFile.ReadLine(), "\\s+", " ");
            srReadFile.Close();
        }
        public void writetxt(string txt, string filename)
        {
            deletetxt(filename);
            String appDir = path + "/Calculator/" + filename + ".txt";
            System.IO.StreamWriter sw = new StreamWriter(appDir);//saOrAp表示覆盖或者是追加
            sw.WriteLine(txt);
            sw.Close();
        }
        public void deletetxt(string filename2)
        {
            String appDir = path + "/Calculator/" + filename2 + ".txt";
            FileStream stream = File.Open(appDir, FileMode.OpenOrCreate, FileAccess.Write);
            stream.Seek(0, SeekOrigin.Begin);
            stream.SetLength(0);
            stream.Close();
        }
        public void savetxt(string data,string name,string name_void)
        {
            if (data == "1")
            {
                deletetxt(name);
                writetxt(name_void, name);
            }
            change_b1 = "0";
            button3.Enabled = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            savetxt(change_b1,"history",void_b1);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            change_b1 = "1";
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
            savetxt(change_b1, "history", void_b1);
            this.Close();
        }
    }
}
