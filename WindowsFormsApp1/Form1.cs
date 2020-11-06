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
using Microsoft.Win32; //写入注册表
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net;
using IWshRuntimeLibrary;
using System.CodeDom;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double num = 0;//储存器1
        double num2 = 0;//储存器2
        double num3 = 0;//GT储存器
        double num4;//M储存器
        double tmp;//临时
        //double num10,num12,num13,num20;//临时
        bool point = false;//小数点判定
        bool ifpoint = false;//小数点判定
        bool text1_zero = true;//数值为0判定
        bool GT = false;//GT判定
        bool M = false;//触发储存器判定
        bool first = false;//第一次输入判定
        bool o_check = false;//连算判定
        int cishu = 0;//未知
        public int vulue = 0;
        bool cishu3 = false;
        bool combo = false;//连击判定
        bool combo2 = false;
        public static bool get_c = false;
        string o = null;
        string operation = null;//运算符号标记
        public string save_void;//自动保存判定
        double num23;//临时
        string url = "blog.cannon.org.cn";//更新服务器网址
        bool history;//关闭时数值保存
        public double version = 1.40;//版本号
        public double new_version;//web获取最新版本号
        public string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//我的文档路径
        string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);//桌面路径
        string app_path_name = System.IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath);
        string app_path = Application.StartupPath;
        //Form4 f4 = new Form4();
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

        public void addnum(bool cishu2 = false)//加法函数
        {
            if (cishu2 == true)
            {
                double answer3;
                string answer4;
                num2 = double.Parse(textBox1.Text);
                answer3 = num23 + num2;
                answer4 = answer3.ToString();
                textBox1.Text = answer4;
                num3 = num3 + answer3;
                GT = true;
            }
            else
            {
                double answer;
                string answer2;
                num2 = double.Parse(textBox1.Text);
                answer = num + num2;
                answer2 = answer.ToString();
                textBox1.Text = answer2;
                num3 = num3 + answer;
            }
        }
        public void delnum(bool cishu2 = false)//减法函数
        {
            if (cishu2 == true)
            {
                double answer3;
                string answer4;
                num2 = double.Parse(textBox1.Text);
                answer3 = num23 - num2;
                answer4 = answer3.ToString();
                textBox1.Text = answer4;
                num3 = num3 + answer3;
                GT = true;
                //o = "-";
            }
            else
            {
                double answer;
                string answer2;
                num2 = double.Parse(textBox1.Text);
                answer = num - num2;
                answer2 = answer.ToString();
                textBox1.Text = answer2;
                num3 = num3 + answer;
            }

        }
        public void xnum(bool cishu2 = false)//乘法函数
        {
            if (cishu2 == true)
            {
                double answer3;
                string answer4;
                num2 = double.Parse(textBox1.Text);
                answer3 = num23 * num2;
                answer4 = answer3.ToString();
                textBox1.Text = answer4;
                num3 = num3 + answer3;
                GT = true;
            }
            else
            {
                double answer;
                string answer2;
                num2 = double.Parse(textBox1.Text);
                answer = num * num2;
                answer2 = answer.ToString();
                textBox1.Text = answer2;
                num3 = num3 + answer;
            }

        }
        public void _num(bool cishu2 = false)//除法函数
        {
            if (cishu2 == true)
            {
                double answer3;
                string answer4;
                num2 = double.Parse(textBox1.Text);
                answer3 = num23 / num2;
                answer4 = answer3.ToString();
                textBox1.Text = answer4;
                num3 = num3 + answer3;
                GT = true;
            }
            else
            {
                double answer;
                string answer2;
                num2 = double.Parse(textBox1.Text);
                answer = num / num2;
                answer2 = answer.ToString();
                textBox1.Text = answer2;
                num3 = num3 + answer;
            }

        }
        public void nummath(double str1,bool p_true = false)//输出函数
        {
            string str3;
            if (p_true == true && ifpoint == false)
            {
                str3 = textBox1.Text;
                ifpoint = true;
                point = false;
                textBox1.Text = str3 + ".";
            }
            else
            {
                if (text1_zero == true || combo == true)
                {

                    //num20 = double.Parse(textBox1.Text);

                    string str4 = "";
                    //string str3;
                    str3 = str4 + str1;
                    textBox1.Text = str3;
                    text1_zero = false;
                    combo = false;


                }
                else if (p_true != true)
                {
                    //num20 = double.Parse(textBox1.Text);
                    //string str3;
                    str3 = textBox1.Text;
                    //point = false;
                    textBox1.Text = str3 + str1;
                }
            }
            
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(app_path);
            Form4 f4 = new Form4();
            timer3.Interval = 100;
            timer3.Enabled = true;
            textBox1.Text = "0";
            textBox2.Text = "";
            timer1.Enabled = false;
            timer1.Interval = 5000;
            //--------------------Update_App_Path    Start-----------------------------
            if (app_path =="Calculator2.exe")//判断当前运行程序版本
            {
                //newtxt(0,"change.txt");
                System.IO.File.Delete(app_path + "/Calculator.exe");
                //System.IO.File.Delete(desktop_path + "/Calculator.exe");
                System.IO.File.Copy(Application.ExecutablePath, app_path + "/Calculator.exe");
                //System.IO.File.Copy(Application.ExecutablePath, desktop_path + "/Calculator.exe");
                Process process = new Process();
                //process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = app_path + "/Calculator.exe";
                //process.StartInfo.CreateNoWindow = true;
                process.Start();
                System.Environment.Exit(0);
            }
            if (System.IO.File.Exists(app_path + "/Calculator2.exe"))
            {
                System.IO.File.Delete(app_path + "/Calculator2.exe");
                System.IO.File.Delete(app_path + "/Calculator/change.txt");
            }
            

            if (!System.IO.File.Exists(path + "/Calculator/update.txt") && Directory.Exists(path + "/Calculator"))
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
            //------------------------------End-------------------------------
                if (Directory.Exists(path + "/Calculator"))//如果不存在就创建file文件夹
                {

                }
                else
                {
  
                    
                    //创建相应文件夹及txt
                      Directory.CreateDirectory(path + "/Calculator");//创建该文件夹
                      System.IO.File.Copy(Application.ExecutablePath, path + "/Calculator/Calculator.exe");
                    string shortcutPath = Path.Combine(desktop_path, string.Format("{0}.lnk", "Calculator"));
                    WshShell shell = new WshShell();
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);//创建快捷方式对象
                    shortcut.TargetPath = path + "/Calculator/Calculator.exe";//指定目标路径
                    shortcut.WorkingDirectory = Path.GetDirectoryName(path + "/Calculator/Calculator.exe");//设置起始位置
                    shortcut.WindowStyle = 1;//设置运行方式，默认为常规窗口
                    shortcut.Description = "";//设置备注
                    shortcut.IconLocation = string.IsNullOrWhiteSpace(path + "/Calculator/Calculator.exe") ? path + "/Calculator/Calculator.exe" : path + "/Calculator/Calculator.exe";//设置图标路径
                    shortcut.Save();//保存快捷方式
                    //System.IO.File.Copy(Application.ExecutablePath, desktop_path + "/Calculator.exe");
                      newtxt(0,"history.txt");
                      not(1, "use.txt");
                      newtxt(0, "history_savetext.txt");
                      //以下为判断创建情况
                       DialogResult = MessageBox.Show("是否启用自动检查更新？", "检查更新", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                      if (DialogResult == DialogResult.OK)
                      {
                        newtxt(1, "update.txt");
                      }
                      else
                      {
                        newtxt(0, "update.txt");
                      }

                 
               
                
                 DialogResult = MessageBox.Show("检测到您第一次运行本程序，祝您使用愉快！", "欢迎", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                
                //else
                //{
                //Directory.CreateDirectory(path + "/tmp");
                //    not(0,"use.txt");
                //}

            }
            if (System.IO.File.Exists(path + "/use.txt"))
            {
            rot("use");
            }
            if (save_void == "0")
            {

            }
            else
            {
                if (System.IO.File.Exists(path + "/Calculator/history.txt"))
                {
                    readtxt("history");
                    if (save_void == "1")
                    {
                        DialogResult = MessageBox.Show("检测到您已开启关闭自动保存计算数据，是否加载？", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
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
                }
                if (System.IO.File.Exists(path + "/Calculator/update.txt"))
                { 
                    readtxt("update");
                    if (save_void == "1")
                    {
                        check_update();
                    }
                }
            }

        }
        public void check_update()
        {
            Form4 f4 = new Form4();
            string statusCode;
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                HttpWebRequest req = (HttpWebRequest)WebRequest.CreateDefault(new Uri("https://gitee.com/XiaoSong0919/Calculator/raw/master/version.txt"));
                req.Method = "HEAD";//请求头
                timer1.Interval = 5100;
                timer1.Enabled = true;
                //f4.timer2.Enabled = true;
                req.Timeout = 5000; //超时时间
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                statusCode = res.StatusCode.ToString();
                if (statusCode == "OK")
                {
                    timer1.Enabled = false;
                    //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://gitee.com/XiaoSong0919/Calculator/raw/master/version.txt");
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    vulue = 15;
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    vulue = 25;
                    Stream responseStream = response.GetResponseStream();
                    vulue = 30;
                    Stream stream = new FileStream(path + "/Calculator/version.txt", FileMode.Create);
                    vulue = 55;
                    byte[] bArr = new byte[1024];
                    vulue = 65;
                    int size = responseStream.Read(bArr, 0, bArr.Length);
                    vulue = 75;
                    while (size > 0)
                    {
                        stream.Write(bArr, 0, size);
                        size = responseStream.Read(bArr, 0, bArr.Length);
                    }
                    stream.Close();
                    vulue = 85;
                    responseStream.Close();
                    vulue = 90;
                    readtxt("version");
                    vulue = 95;
                    //f4.label4.Text = "v" + new_version;
                    vulue = 97;
                    if (new_version < version)
                    {
                        MessageBox.Show("？？？尼玛情况？？？", "检测完成", MessageBoxButtons.OK, MessageBoxIcon.Question);


                    }
                    else
                    {
                        if (new_version > version)
                        {
                            vulue = 99;
                            DialogResult = MessageBox.Show("检测到新版本，是否下载？", "检测完成", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            vulue = 100;
                            if (DialogResult == DialogResult.OK)
                            {
                                update("https://github.com/XiaoSong0919/Calculator/releases/download/v" + new_version + "/Calculator.exe");
                            }
                        }
                        else
                        {

                            timer1.Enabled = false;
                            vulue = 100;
                            MessageBox.Show("暂无新版本", "检测完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    timer1.Enabled = false;
                    MessageBox.Show("更新失败：网络错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (WebException)
            {

            }

        }
        public void update(string url)
        {
            Form4 f4 = new Form4();
            string statusCode;
            HttpWebRequest req = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
            req.Method = "HEAD";//请求头
            timer1.Interval = 5100;
            timer1.Enabled = true;
            req.Timeout = 5000; //超时时间
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            statusCode = res.StatusCode.ToString();
            if (statusCode == "OK")
            {
                timer1.Enabled = false;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                Stream stream = new FileStream(path + "/Calculator/Calculator2.exe", FileMode.Create);
                //System.IO.File.Copy(Application.ExecutablePath, desktop_path + "/Calculator.exe");
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, bArr.Length);
                while (size > 0)
                {
                    stream.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, bArr.Length);
                }
                stream.Close();
                responseStream.Close();
                f4.progressBar1.Value = 100;
                DialogResult = MessageBox.Show("升级成功！是否立即重启软件？", "升级完毕", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (DialogResult == DialogResult.OK)
                {
                    Process process = new Process();
                    //process.StartInfo.UseShellExecute = false;
                    process.StartInfo.FileName = path + "/Calculator/Calculator2.exe";
                    //process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    System.Environment.Exit(0);
                }
            }
            else
            {
                timer1.Enabled = false;
                MessageBox.Show("更新失败：网络错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public void not(int txt3, string filename2)
        {
            FileStream fs1 = new FileStream(path  + "/" + filename2, FileMode.Create, FileAccess.Write);//创建写入文件 
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine(txt3);//开始写入值
            sw.Close();
            fs1.Close();
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
            try
            {
                StreamReader srReadFile = new StreamReader(path + "/Calculator/" + filename + ".txt");
                save_void = Regex.Replace(srReadFile.ReadLine(), "\\s+", " ");
                new_version = System.Convert.ToDouble(save_void);
                srReadFile.Close();
            }
            catch(FormatException e)
            {
                MessageBox.Show("程序内部错误! \n" + e.ToString() ,"Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void rot(string filename3)
        {
            StreamReader srReadFile = new StreamReader(path + "/" + filename3 + ".txt");
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
            FileStream stream = System.IO.File.Open(appDir, FileMode.OpenOrCreate, FileAccess.Write);
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
            num23 = double.Parse(textBox1.Text);
            nummath(1);
            cishu3 = false;
            //combo = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            num23 = double.Parse(textBox1.Text);
            nummath(2);
            cishu3 = false;
            //combo = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            num23 = double.Parse(textBox1.Text);
            nummath(3);
            cishu3 = false;
            //combo = false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            num23 = double.Parse(textBox1.Text);
            nummath(4);
            cishu3 = false;
            //combo = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            num23 = double.Parse(textBox1.Text);
            nummath(5);
            cishu3 = false;
           // combo = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            num23 = double.Parse(textBox1.Text);
            nummath(6);
            cishu3 = false;
           // combo = false;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            num23 = double.Parse(textBox1.Text);
            nummath(7);
            cishu3 = false;
            //combo = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            num23 = double.Parse(textBox1.Text);
            nummath(8);
            cishu3 = false;
            //combo = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            num23 = double.Parse(textBox1.Text);
            nummath(9);
            cishu3 = false;
            //combo = false;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            num23 = double.Parse(textBox1.Text);
            nummath(0);
            cishu3 = false;
           // combo = false;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            nummath(0,true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            point = false;
            ifpoint = false;
            text1_zero = true;
            first = false;
            combo = false;
            cishu3 = true;
            GT = false;
            M = false;
            num = num2 = num3 = num4 = tmp = num23 = 0;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            operation = "+";
            num = double.Parse(textBox1.Text);
            if (o == "-" && combo2 == true && cishu3 == false)
            {
                delnum(true);
                //delnum(true);
                cishu3 = true;
                o = "+";
            }
            else if (o == "x" && combo2 == true && cishu3 == false)
            {
                xnum(true);
                //delnum(true);
                cishu3 = true;
                o = "+";
            }
            else if (o == "/" && combo2 == true && cishu3 == false)
            {
                _num(true);
                //delnum(true);
                cishu3 = true;
                o = "+";
            }
            else if (combo2 == true && cishu3 == false)
            {
                addnum(true);
                cishu3 = true;
                o = "+";
            }
            
            combo = true;
            combo2 = true;
            //if (M == false)
            //{
             //   textBox2.Text = "GT";
            //}
            //if (GT == true && M == true)
            //{
             //   textBox2.Text = "GT,M";
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            operation = "-";
            //combo = true;
            num = double.Parse(textBox1.Text);
            if (o == "+" && combo2 == true && cishu3 == false)
            {
                addnum(true);
                //delnum(true);
                cishu3 = true;
                o = "-";
            }
            else if (o == "/" && combo2 == true && cishu3 == false)
            {
                _num(true);
                //delnum(true);
                cishu3 = true;
                o = "-";
            }
            else if (o == "x" && combo2 == true && cishu3 == false)
            {
                xnum(true);
                //delnum(true);
                cishu3 = true;
                o = "-";
            }
            else if (combo2 == true && cishu3 == false)
            {
                delnum(true);
                cishu3 = true;
                o = "-";
            }
            combo = true;
            combo2 = true;
          //  if (M == false)
            //    {
              //      textBox2.Text = "GT";
                //}
                //if (GT == true && M == true)
                //{
                 //   textBox2.Text = "GT,M";
                //}
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            operation = "x";
           // combo = true;
            num = double.Parse(textBox1.Text);
            if (o == "+" && combo2 == true && cishu3 == false)
            {
                addnum(true);
                //delnum(true);
                cishu3 = true;
                o = "x";
            }
            else if (o == "/" && combo2 == true && cishu3 == false)
            {
                _num(true);
                //delnum(true);
                cishu3 = true;
                o = "x";
            }
            else if (o == "-" && combo2 == true && cishu3 == false)
            {
                delnum(true);
                //delnum(true);
                cishu3 = true;
                o = "x";
            }
            else if (combo2 == true && cishu3 == false)
            {
                xnum(true);
                cishu3 = true;

            }
            combo = true;
            combo2 = true;
            //           if (M == false)
            //             {
            //               textBox2.Text = "GT";
            //         }
            //       if (GT == true && M == true)
            //     {
            //       textBox2.Text = "GT,M";
            // }



            //textBox1.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            operation = "/";
       //     combo = true;
            num = double.Parse(textBox1.Text);
            if (o == "+" && combo2 == true && cishu3 == false)
            {
                addnum(true);
                //delnum(true);
                cishu3 = true;
                o = "/";
            }
            else if (o == "-" && combo2 == true && cishu3 == false)
            {
                delnum(true);
                //delnum(true);
                cishu3 = true;
                o = "/";
            }
            else if (o == "x" && combo2 == true && cishu3 == false)
            {
                xnum(true);
                //delnum(true);
                cishu3 = true;
                o = "/";
            }
            else if (combo2 == true && cishu3 == false)
            {
                _num(true);
                cishu3 = true;

            }
            combo = true;
            combo2 = true;
            //            if (M == false)
            //              {
            //                textBox2.Text = "GT";
            //          }
            //        if (GT == true && M == true)
            //      {
            //        textBox2.Text = "GT,M";
            //  }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string  answer;
            string num5 = "";
            double num6 = 0;
            //combo = true;
            //combo2 = false;
            cishu3 = true;
            first = true;
            num2 = double.Parse(textBox1.Text);
            if (operation == "+")
            {
                if (combo2 == true)
                {
                    addnum(true);
                    GT = true;
                    combo = true;
                    combo2 = false;

                }
                else
                {
                    addnum(false);
                    GT = true;
                }
                
            }
            if (operation == "-")
            {
                delnum(false);
                GT = true;
            }
            if (operation == "x")
            {
                xnum(false);
                GT = true;
            }
            if (operation == "/")
            {
                _num(false);
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
            num2 = 0;
            ifpoint = false;
            cishu3 = false;
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
            timer2.Interval = 2000;
            timer2.Enabled = true;
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
            MessageBox.Show("更新失败：连接超时", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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

        private void timer2_Tick(object sender, EventArgs e)
        {
            cishu = 0;
            timer2.Enabled = false;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (GT == true && M == false)
            {
                textBox2.Text = "GT";
            }
            else if (GT == false && M == true)
            {
                textBox2.Text = "M";
            }
            else if (GT == true && M == true)
            {
                textBox2.Text = "GT,M";
            }
        }

        private void 问题反馈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void 其他ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

