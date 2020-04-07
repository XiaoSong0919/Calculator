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
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double num = 0;//储存器1
        double num2;//储存器2
        double num3;//GT储存器
        double num4;//M储存器
        double tmp;//临时
        double num10,num12,num13,num20;
        bool point = false;
        bool ifpoint = false;
        bool text1_zero = true;
        bool GT = false;
        bool M = false;
        bool first = false;
        bool o_check = false;
        int cishu = 0;
        int combo = 0;
        string operation = null;
        string save_void;
        string num23;
        bool history;
        double version = 1.2;
        double new_version;
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
            if (e.KeyChar == '1')
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
                button8.PerformClick();// 执行按钮“1”的操作
                e.Handled = true;
            }
            if (e.KeyChar == '-')
            {
                button3.PerformClick();// 执行按钮“1”的操作
                e.Handled = true;
            }
            if (e.KeyChar == 'x' || e.KeyChar == '*')
            {
                button7.PerformClick();// 执行按钮“1”的操作
                e.Handled = true;
            }
            if (e.KeyChar == '÷'|| e.KeyChar == '/')
            {
                button5.PerformClick();// 执行按钮“1”的操作
                e.Handled = true;
            }

        }
        public void nummath(double str1)
        {
            if (text1_zero == true) 
            {
               
                    num20 = double.Parse(textBox1.Text);
              
                string str4 = "";
                string str3;
                str3 = str4 + str1;
                textBox1.Text = str3;
                text1_zero = false;

               
            }
            else if (first == true)
            {
                num20 = double.Parse(textBox1.Text);
                string str5 = str1.ToString();
                textBox1.Text = str5;
                text1_zero = false;
                first = false;
            }
            else
            {
                num20 = double.Parse(textBox1.Text);
                string str3;
                str3 = textBox1.Text;
                point = false;
                textBox1.Text = str3 + str1;
            }
            
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            if (File.Exists(path + "/Calculator/Calculator2.exe") && !File.Exists(path + "/Calculator/change.txt"))
            {
                newtxt(0,"change.txt");
                System.IO.File.Delete(path + "/Calculator/Calculator.exe");
                System.IO.File.Delete(desktop_path + "/Calculator.exe");
                System.IO.File.Copy(Application.ExecutablePath, path + "/Calculator/Calculator.exe");
                System.IO.File.Copy(Application.ExecutablePath, desktop_path + "/Calculator.exe");
                Process process = new Process();
                //process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = path + "/Calculator/Calculator.exe";
                //process.StartInfo.CreateNoWindow = true;
                process.Start();
                System.Environment.Exit(0);
            }
            if (File.Exists(path + "/Calculator/change.txt"))
            {
                System.IO.File.Delete(path + "/Calculator/Calculator2.exe");
                System.IO.File.Delete(path + "/Calculator/change.txt");
            }
            textBox1.Text = "0";
            textBox2.Text = "";
            timer1.Enabled = false;
            timer1.Interval = 5000;

            if (!File.Exists(path + "/Calculator/update.txt") && Directory.Exists(path + "/Calculator"))
            {
                DialogResult = MessageBox.Show("欢迎更新新版本。是否启用自动检查更新？", "检查更新", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (DialogResult == DialogResult.OK)
                {
                    newtxt(1, "update.txt");
                }
                else
                {
                    newtxt(0, "update.txt");
                }
            }
                if (Directory.Exists(path + "/Calculator"))//如果不存在就创建file文件夹
                {

                }
                else
                {
                DialogResult = MessageBox.Show("检测到您第一次运行此程序，需要创建快捷方式至桌面和创建相应的文件夹吗？", "错误", MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
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
                    DialogResult = MessageBox.Show("是否启用自动检查更新？", "检查更新", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (DialogResult == DialogResult.OK)
                    {
                        newtxt(1, "update.txt");
                    }
                    else
                    {
                        newtxt(0, "update.txt");
                    }

                }

            }
            readtxt("history");
            if (save_void == "1")
            {
                DialogResult = MessageBox.Show("检测到您已开启关闭自动保存计算数据，是否加载？","Question",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
                if (DialogResult == DialogResult.OK)
                {
                    history = true;
                    readtxt("history_savetext");
                    textBox1.Text = save_void;
                    first = true;
                }
                else
                {
                    history = false;
                }

                
            }
            else
            {
                history = false;
            }
            readtxt("update");
            if (save_void == "1")
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://songyuhao.51vip.biz:83/version.txt");
                //progressBar1.Value = 15;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //progressBar1.Value = 25;
                Stream responseStream = response.GetResponseStream();
                //progressBar1.Value = 30;
                Stream stream = new FileStream(path + "/Calculator/version.txt", FileMode.Create);
               // progressBar1.Value = 55;
                byte[] bArr = new byte[1024];
                //progressBar1.Value = 65;
                int size = responseStream.Read(bArr, 0, bArr.Length);
                //progressBar1.Value = 75;
                while (size > 0)
                {
                    stream.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, bArr.Length);
                }
                stream.Close();
                //progressBar1.Value = 85;
                responseStream.Close();
                //progressBar1.Value = 90;
                readtxt("version");
                //progressBar1.Value = 95;
                //label4.Text = "v" + save_void;
                //progressBar1.Value = 97;
                if (new_version > 1.3)
                {
                    //progressBar1.Value = 99;
                    //DialogResult = MessageBox.Show("检测到新版本，是否下载？", "检测完成", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    //progressBar1.Value = 100;
                    //if (DialogResult == DialogResult.OK)
                    //{
                        
                    //}
                    update("http://songyuhao.51vip.biz:83/Calculator.exe");
                }
                else
                {
                    //progressBar1.Value = 100;
                    MessageBox.Show("暂无新版本", "检查更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        public void update(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream responseStream = response.GetResponseStream();
            Stream stream = new FileStream(path + "/Calculator/Calculator.exe", FileMode.Create);
            System.IO.File.Copy(Application.ExecutablePath, desktop_path + "/Calculator.exe");
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, bArr.Length);
            }
            stream.Close();
            responseStream.Close();
            //progressBar1.Value = 100;
            MessageBox.Show("升级成功！", "升级完毕", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                first = false;
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
            first = false;
            combo = 0;
            GT = false;
            M = false;
            num = num2 = num3 = num4 = tmp = num13 = 0;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (combo > 1)
            {

            }
            else
            {
                operation = "+";
            }
            if (operation != "+")
            {
                o_check = true;
            }
            else
            {
                o_check = false;
            }
            //operation = "+";
            num = double.Parse(textBox1.Text);
            first = true;
            combo = combo + 1;
            string num23 = num13.ToString();
            if (combo > 1)
            {
                if (o_check == true)
                {
                    //num20 = double.Parse(textBox1.Text);
                    if (operation == "x")
                    {
                        operation = "+";
                        num13 = num * num20;
                        num23 = num13.ToString();
                        textBox1.Text = num23;
                        num3 = num3 + num13;
                        GT = true;
                    }
                    else if (operation == "-")
                    {
                        operation = "+";
                        num23 = num13.ToString();
                        num13 = num20 - num;
                        textBox1.Text = num23;
                        num3 = num3 + num13;
                        GT = true;
                    }
                    else if (operation == "/")
                    {
                        operation = "+";
                        num13 = num20 / num;
                        num23 = num13.ToString();
                        textBox1.Text = num23;
                        num3 = num3 + num13;
                        GT = true;
                    }
                }
                else
                {
                    operation = "+";
                    num13 = num + num20;
                    num23 = num13.ToString();
                    textBox1.Text = num23;
                    num3 = num3 + num13;
                    GT = true;
                }
                if (M == false)
                {
                    textBox2.Text = "GT";
                }
                if (GT == true && M == true)
                {
                    textBox2.Text = "GT,M";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (combo > 1)
            {

            }
            else
            {
                operation = "-";
            }
            if (operation != "-")
            {
                o_check = true;
            }
            else
            {
                o_check = false;
            }
            //operation = "-";
            num = double.Parse(textBox1.Text);
            first = true;
            combo = combo + 1;
            string num23 = num13.ToString();
            if (combo > 1)
            {
                //num20 = double.Parse(textBox1.Text);
                if (o_check == true)
                {
                    if (operation == "x")
                    {
                        operation = "-";
                        num13 = num * num20;
                        num23 = num13.ToString();
                        textBox1.Text = num23;
                        num3 = num3 + num13;
                        GT = true;
                    }
                    else if (operation == "+")
                    {
                        operation = "-";
                        num13 = num + num20;
                        num23 = num13.ToString();
                        textBox1.Text = num23;
                        num3 = num3 + num13;
                        GT = true;
                    }
                    else if (operation == "/")
                    {
                        operation = "-";
                        num13 = num20 / num;
                        num23 = num13.ToString();
                        textBox1.Text = num23;
                        num3 = num3 + num13;
                        GT = true;
                    }
                }
                else
                {
                    operation = "-";
                    num13 = num20 - num;
                    num23 = num13.ToString();
                    textBox1.Text = num23;
                    num3 = num3 + num13;
                    GT = true;
                }
                if (M == false)
                {
                    textBox2.Text = "GT";
                }
                if (GT == true && M == true)
                {
                    textBox2.Text = "GT,M";
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (combo > 1)
            {

            }
            else
            {
                operation = "x";
            }
            if (operation != "x")
            {
                o_check = true;
            }
            else
            {
                o_check = false;
            }
            num = double.Parse(textBox1.Text);
            first = true;
            combo = combo + 1;
            string num23 = num13.ToString();
            if (combo > 1)
            {
                //num20 = double.Parse(textBox1.Text);
                if (o_check == true)
                {
                    if (operation == "-")
                    {
                        operation = "x";
                        num23 = num13.ToString();
                        num13 = num20 - num;
                        textBox1.Text = num23;
                        num3 = num3 + num13;
                        GT = true;
                    }
                    else if (operation == "+")
                    {
                        operation = "x";
                        num13 = num + num20;
                        num23 = num13.ToString();
                        textBox1.Text = num23;
                        num3 = num3 + num13;
                        GT = true;
                    }
                    else if (operation == "/")
                    {
                        operation = "x";
                        num13 = num20 / num;
                        num23 = num13.ToString();
                        textBox1.Text = num23;
                        num3 = num3 + num13;
                        GT = true;
                    }
                }
                else
                {
                    operation = "x";
                    num13 = num * num20;
                    num23 = num13.ToString();
                    textBox1.Text = num23;
                    num3 = num3 + num13;
                    GT = true;

                }
                if (M == false)
                {
                    textBox2.Text = "GT";
                }
                if (GT == true && M == true)
                {
                    textBox2.Text = "GT,M";
                }

            }
            
            //textBox1.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (combo > 1)
            {

            }
            else
            {
                operation = "/";
            }
            if (operation != "/")
            {
                o_check = true;
            }
            else
            {
                o_check = false;
            }

            num = double.Parse(textBox1.Text);
            first = true;
            combo = combo + 1;
            string num23 = num13.ToString();
            if (combo > 1)
            {
                //num20 = double.Parse(textBox1.Text);
                if (o_check == true)
                {
                    if (operation == "x")
                    {
                        operation = "/";
                        num13 = num * num20;
                        num23 = num13.ToString();
                        textBox1.Text = num23;
                        num3 = num3 + num13;
                        GT = true;
                    }
                    else if (operation == "+")
                    {
                        operation = "/";
                        num13 = num + num20;
                        num23 = num13.ToString();
                        textBox1.Text = num23;
                        num3 = num3 + num13;
                        GT = true;
                    }
                    else if (operation == "-")
                    {
                        operation = "/";
                        num23 = num13.ToString();
                        num13 = num20 - num;
                        textBox1.Text = num23;
                        num3 = num3 + num13;
                        GT = true;
                    }
                }
                else
                {
                    operation = "/";
                    num13 = num20 / num;
                    num23 = num13.ToString();
                    textBox1.Text = num23;
                    num3 = num3 + num13;
                    GT = true;
                }
                if (M == false)
                {
                    textBox2.Text = "GT";
                }
                if (GT == true && M == true)
                {
                    textBox2.Text = "GT,M";
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string  answer;
            string num5 = "";
            double num6 = 0;
            first = true;
            num2 = double.Parse(textBox1.Text);
            if (operation == "+")
            {
                if (combo > 1)
                {
                    num6 = num2 + num13;
                }
                else
                {
                    num6 = num + num2;
                }
                answer = num5 + num6;
                textBox1.Text = answer;
                num3 = num3 + num6;
                GT = true;
                combo = 0;
            }
            if (operation == "-")
            {
                if (combo > 1)
                {
                    num6 = num13 - num2;
                }
                else
                {
                    num6 = num - num2;
                }
                combo = 0;
                answer = num5 + num6;
                textBox1.Text = answer;
                num3 = num3 + num6;
                GT = true;
            }
            if (operation == "x")
            {
                if (combo > 1)
                {
                    num6 = num13 * num2;
                }
                else
                {
                    num6 = num * num2;
                }
                combo = 0;
                answer = num5 + num6;
                textBox1.Text = answer;
                num3 = num3 + num6;
                GT = true;
            }
            if (operation == "/")
            {
                if (combo > 1)
                {
                    num6 = num13 / num2;
                }
                else
                {
                    num6 = num / num2;
                }
                combo = 0;
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

        private void 推出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("你确定要退出吗？","确定？",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (DialogResult == DialogResult.OK)
            {
                System.Environment.Exit(0);
            }
        }

        private void 检查更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

