using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Win32; //写入注册表时要用到
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double num = 0;//储存器1
        double num2;//储存器2
        double num3;//GT储存器
        double num4;//M储存器
        double tmp;//临时
        bool point = false;
        bool ifpoint = false;
        bool text1_zero = true;
        bool GT = false;
        bool M = false;
        int cishu = 0;
        string operation;
        string save_void;
        bool history;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public Form1()
        {
            InitializeComponent();
        }
 
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar  == '1')
            {
                nummath(1);
                e.Handled = true;
            }
            if (e.KeyChar == '2')
            {
                nummath(2);
                e.Handled = true;
            }
            if (e.KeyChar == '3')
            {
                nummath(3);
                e.Handled = true;
            }
            if (e.KeyChar == '4')
            {
                nummath(4);
                e.Handled = true;
            }
            if (e.KeyChar == '5')
            {
                nummath(5);
                e.Handled = true;
            }
            if (e.KeyChar == '6')
            {
                nummath(6);
                e.Handled = true;
            }
            if (e.KeyChar == '7')
            {
                nummath(7);
                e.Handled = true;
            }
            if (e.KeyChar == '8')
            {
                nummath(8);
                e.Handled = true;
            }
            if (e.KeyChar == '9')
            {
                nummath(9);
                e.Handled = true;
            }
            if (e.KeyChar == '0')
            {
                nummath(0);
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                button23.PerformClick();// 执行按钮“1”的操作
                e.Handled = true;
            }
            if (e.KeyChar == '+')
            {
                button1.PerformClick();// 执行按钮“1”的操作
                e.Handled = true;
            }
            if (e.KeyChar == '-')
            {
                button1.PerformClick();// 执行按钮“1”的操作
                e.Handled = true;
            }
            if (e.KeyChar == 'x' || e.KeyChar == '*')
            {
                button1.PerformClick();// 执行按钮“1”的操作
                e.Handled = true;
            }
            if (e.KeyChar == '÷'|| e.KeyChar == '/')
            {
                button1.PerformClick();// 执行按钮“1”的操作
                e.Handled = true;
            }

        }
        public void nummath(double str1)
        {
            if (text1_zero == true) 
            {
                string str4 = "";
                string str3;
                str3 = str4 + str1;
                textBox1.Text = str3;
                text1_zero = false;

               
            }
            else
            {
                string str3;
                str3 = textBox1.Text;
                point = false;
                textBox1.Text = str3 + str1;
            }

        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            timer1.Enabled = false;
            timer1.Interval = 5000;
            
            
            if (Directory.Exists(path + "/Calculator"))//如果不存在就创建file文件夹
                {

                }
                else
                {
                DialogResult = MessageBox.Show("检测到您第一次运行此程序，需要创建快捷方式至桌面和创建相应的文件夹吗？", "错误", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (DialogResult == DialogResult.OK)
                {
                    //创建相应文件夹及txt
                    Directory.CreateDirectory(path + "/Calculator");//创建该文件夹
                    System.IO.File.Copy(Application.ExecutablePath, path + "/Calculator/Calculator.exe");
                    System.IO.File.Copy(Application.ExecutablePath, desktop_path + "/Calculator.exe");
                    newtxt(0,"history.txt");
                    newtxt(0, "history_savetext.txt");
                    //以下为判断创建情况
                    if (!Directory.Exists(path + "/Calculator"))
                    {
                        MessageBox.Show("创建失败！", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("创建成功！", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
            }
            readtxt("history");
            if (save_void == "1")
            {
                history = true;
                readtxt("history_savetext");
                textBox1.Text = save_void;
            }
            else
            {
                history = false;
            }


        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (history == true)
            {
                deletetxt("history_savetext");
                writetxt(textBox1.Text,"history_savetext");
            }

        }
        private void Form1_FormClosed(Object sender, FormClosedEventArgs e)
        {
            if (history == true)
            {
                deletetxt("history_savetext");
                writetxt(textBox1.Text, "history_savetext");
            }
        }

        public void newtxt(int txt2, string filename)
        {
            FileStream fs1 = new FileStream(path + "/Calculator/" + filename , FileMode.Create, FileAccess.Write);//创建写入文件 
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine(txt2);//开始写入值
            sw.Close();
            fs1.Close();
        }
        public void readtxt(string filename)
        {
            StreamReader srReadFile = new StreamReader(path + "/Calculator/" + filename + ".txt");
            save_void = Regex.Replace(srReadFile.ReadLine(), "\\s+", " ");
            srReadFile.Close();
        }
        public void writetxt(string txt,string filename)
        {
            deletetxt(filename);
            String appDir = path + "/Calculator/" + filename + ".txt";
            StreamWriter sw = new StreamWriter(appDir);//saOrAp表示覆盖或者是追加
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            text1_zero = false;
            if (textBox1.Text == "0")
            {
                text1_zero = true;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            nummath(1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            nummath(2);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            nummath(3);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            nummath(4);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            nummath(5);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            nummath(6);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            nummath(7);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            nummath(8);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            nummath(9);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            nummath(0);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (ifpoint == false)
            {
                string str3;
                str3 = textBox1.Text;
                ifpoint = true;
                point = false;
                textBox1.Text = str3 + ".";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            point = false;
            ifpoint = false;
            text1_zero = true;
            GT = false;
            M = false;
            num = num2 = num3 = num4 = tmp = 0;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            operation = "+";
            num = 0;
            num = double.Parse(textBox1.Text);
            textBox1.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            operation = "-";
            num = 0;
            num = double.Parse(textBox1.Text);
            textBox1.Text = "0";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            operation = "x";
            num = 0;
            num = double.Parse(textBox1.Text);
            textBox1.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            operation = "/";
            num = 0;
            num = double.Parse(textBox1.Text);
            textBox1.Text = "0";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string  answer;
            string num5 = "";
            double num6 = 0;
            num2 = double.Parse(textBox1.Text);
            if (operation == "+")
            {
                num6 = num + num2;
                answer = num5 + num6;
                textBox1.Text = answer;
                num3 = num3 + num6;
                GT = true;
            }
            if (operation == "-")
            {
                num6 = num - num2;
                answer = num5 + num6;
                textBox1.Text = answer;
                num3 = num3 + num6;
                GT = true;
            }
            if (operation == "x")
            {
                num6 = num * num2;
                answer = num5 + num6;
                textBox1.Text = answer;
                num3 = num3 + num6;
                GT = true;
            }
            if (operation == "/")
            {
                num6 = num / num2;
                answer = num5 + num6;
                textBox1.Text = answer;
                num3 = num3 + num6;
                GT = true;
            }
            if (M == false)
            {
                textBox2.Text = "GT";
            }
            if (GT == true&&M == true)
            {
                textBox2.Text = "GT,M";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (M == true)
            {
                string num5;
                num4 = double.Parse(textBox1.Text) + num4;
                num5 = Convert.ToString(num4);
                textBox1.Text = num5;
            }
            else
            {
                text1_zero = true;
                num4 = double.Parse(textBox1.Text);
                M = true;
            }
            if (M == true&& GT == false )
            {
                textBox2.Text = "M";
            }
            if (GT == true && M == true)
            {
                textBox2.Text = "GT,M";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string num5 = Convert.ToString(num4);
            textBox1.Text = num5;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            num4 = 0;
            if (GT == true )
            {
                textBox2.Text = "GT";
                M = false;
            }
            else
            {
                textBox2.Text = "";
                M = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (M == true)
            {
                string num5;
                num4 = num4 - double.Parse(textBox1.Text);
                num5 = Convert.ToString(num4);
                textBox1.Text = num5;
            }
            else
            {
                text1_zero = true;
                num4 = double.Parse(textBox1.Text);
                M = true;
            }
            if (M == true && GT == false)
            {
                textBox2.Text = "M";
            }
            if (GT == true && M == true)
            {
                textBox2.Text = "GT,M";
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (M == true)
            {
                textBox2.Text = "M";
                GT = false;
            }
            else
            {
                textBox2.Text = "";
                GT = false;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string num5 = Convert.ToString(num3);
            textBox1.Text = num5;
            cishu = cishu + 1;
            timer1.Enabled = true;
            if (cishu  == 2)
            {
                cishu = 0;
                num3 = 0;
                textBox1.Text = "0";
                GT = false;
                if (M == true)
                {
                    textBox2.Text = "M";
                }
                else
                {
                    textBox2.Text = "";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cishu = 0;
            timer1.Enabled = false;

        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }
    }
}

