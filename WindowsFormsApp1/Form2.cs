using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        string status;
        string save_void;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void download()
        {
            Form1 f1 = new Form1();
            string statusCode;

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            HttpWebRequest req = (HttpWebRequest)WebRequest.CreateDefault(new Uri("http://blog.cannon.org.cn/version.txt"));
            req.Method = "HEAD";//请求头
            //timer1.Interval = 5100;
            //timer1.Enabled = true;
            //f4.timer2.Enabled = true;
            req.Timeout = 5000; //超时时间
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            statusCode = res.StatusCode.ToString();
            if (statusCode == "OK" && Form1.get_c == false)
            {
                if (!Directory.Exists(f1.path + "/Calculator"))
                {
                    MessageBox.Show("缺少相关的文件夹，部分功能可能无法正常显示！", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //timer1.Enabled = false;
                    //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://blog.cannon.org.cn/c_update_status.txt");
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    //vulue = 15;
                    //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    // vulue = 25;
                    Stream responseStream = response.GetResponseStream();
                    //  vulue = 30;

                    Stream stream = new FileStream(f1.path + "/Calculator/c_update_status.txt", FileMode.Create);
                    // vulue = 55;
                    byte[] bArr = new byte[1024];
                    // vulue = 65;
                    int size = responseStream.Read(bArr, 0, bArr.Length);
                    // vulue = 75;
                    while (size > 0)
                    {
                        stream.Write(bArr, 0, size);
                        size = responseStream.Read(bArr, 0, bArr.Length);
                    }
                    stream.Close();
                    // vulue = 85;
                    responseStream.Close();
                    //vulue = 90;
                    readtxt("c_update_status");
                    status = save_void;
                    label8.Text = "目前更新状态：" + status;
                    Form1.get_c = true;
                    // vulue = 95;
                    //f4.label4.Text = "v" + new_version;
                    // vulue = 97;
                }
            }
            if (Form1.get_c == true)
            {
                readtxt("c_update_status");
                status = save_void;
                label8.Text = "目前更新状态：" + status;
            }
        }   

        public void readtxt(string filename)
        {
            
            Form1 f1 = new Form1();
            StreamReader srReadFile = new StreamReader(f1.path + "/Calculator/" + filename + ".txt");
            save_void = Regex.Replace(srReadFile.ReadLine(), "\\s+", " ");
            //new_version = System.Convert.ToDouble(save_void);
            srReadFile.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            double version = f1.version;
            label5.Text = "版本号：" + "v" + version;
            download();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://cannon.org.cn");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
