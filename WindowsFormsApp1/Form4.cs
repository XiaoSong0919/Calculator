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
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        string save_void;
        double version = 1.3;
        double new_version;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://songyuhao.51vip.biz:83/version.txt");
            progressBar1.Value = 15;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            progressBar1.Value = 25;
            Stream responseStream = response.GetResponseStream();
            progressBar1.Value = 30;
            Stream stream = new FileStream(path + "/Calculator/version.txt", FileMode.Create);
            progressBar1.Value = 55;
            byte[] bArr = new byte[1024];
            progressBar1.Value = 65;
            int size = responseStream.Read(bArr, 0, bArr.Length);
            progressBar1.Value = 75;
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, bArr.Length);
            }
            stream.Close();
            progressBar1.Value = 85;
            responseStream.Close();
            progressBar1.Value = 90;
            readtxt("version");
            progressBar1.Value = 95;
            label4.Text = "v" + save_void;
            progressBar1.Value = 97;
            if (new_version > 1.3)
            {
                progressBar1.Value = 99;
                DialogResult = MessageBox.Show("检测到新版本，是否下载？","检测完成",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                progressBar1.Value = 100;
                if (DialogResult == DialogResult.OK)
                {
                    update("http://songyuhao.51vip.biz:83/Calculator.exe");
                } 
            }
            else
            {
                progressBar1.Value = 100;
                MessageBox.Show("暂无新版本", "检测完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void readtxt(string filename)
        {
            StreamReader srReadFile = new StreamReader(path + "/Calculator/" + filename + ".txt");
            save_void = Regex.Replace(srReadFile.ReadLine(), "\\s+", " ");
            new_version = System.Convert.ToDouble(save_void);
            srReadFile.Close();
        }
        public void update(string url)
        {
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
            progressBar1.Value = 100;
            DialogResult = MessageBox.Show("升级成功！是否立即重启软件？", "升级完毕",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
