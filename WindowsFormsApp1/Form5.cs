using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Collections.Generic;
//using System.Linq;
using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.IO;
using System.Net;
using System.Globalization;
//using System.Text;
//using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
        public void newtxt(string txt2, string filename)
        {
            Form1 f1 = new Form1();
            FileStream fs1 = new FileStream(f1.path + "/Calculator/" + filename, FileMode.Create, FileAccess.Write);//创建写入文件 
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine(txt2);//开始写入值
            sw.Close();
            fs1.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.DateTime currentTime = new System.DateTime();
            int y = currentTime.Year;
            int m = currentTime.Month;
            int d = currentTime.Day;
            int h = currentTime.Hour;
            int m2 = currentTime.Minute;
            string strY = DateTime.Now.Second.ToString();
            string strM = DateTime.Now.Minute.ToString();
            string text = textBox1.Text + "\r\n" + textBox2.Text + "\r\n" + textBox3.Text;
            newtxt(text, DateTime.Now.Year.ToString() + "-" + DateTime.Now.DayOfYear.ToString() + "-"  + strY + "-" + strM + "-" + "bug_upload.txt");
            Upload("ftp","", DateTime.Now.Year.ToString() + "-" + DateTime.Now.DayOfYear.ToString() + "-" + strY + "-" + strM + "-" + "bug_upload.txt", "ftp://nas.cannon.org.cn:24/bugs_upload/");
        }
        
        public void Upload(string userId, string pwd, string filename, string ftpPath)
        {
            try
            {
                Form1 f1 = new Form1();
                FileInfo fileInf = new FileInfo(f1.path + "/Calculator/" + filename);
                FtpWebRequest reqFTP;
                // 根据uri创建FtpWebRequest对象
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpPath + fileInf.Name));
                // ftp用户名和密码
                reqFTP.Credentials = new NetworkCredential(userId, pwd);

                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = true;//被动模式(这个要和搭建的ftp服务对应)
                reqFTP.ContentLength = fileInf.Length;
                reqFTP.Timeout = 2000;//响应请求等待的时间
                                               // 缓冲大小设置为2kb
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;
                // 打开一个文件流 (System.IO.FileStream) 去读上传的文件
                FileStream fs = fileInf.OpenRead();
                //try
                //{
                // 把上传的文件写入流
                using (Stream strm = reqFTP.GetRequestStream())
                {
                    contentLen = fs.Read(buff, 0, buffLength);
                    while (contentLen != 0)
                    {
                        strm.Write(buff, 0, contentLen);
                        contentLen = fs.Read(buff, 0, buffLength);
                    }
                    // 关闭两个流
                    strm.Close();
                    fs.Close();
                }
                MessageBox.Show("反馈成功！感谢您的支持！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (WebException e)
            {
                MessageBox.Show(e.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw e;
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show("请关闭代理工具！","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
            
            // catch (Exception ex)
            // {

            // }
            
        


    }
    }
}
