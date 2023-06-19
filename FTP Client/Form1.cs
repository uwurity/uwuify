using Microsoft.VisualBasic.ApplicationServices;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FTP_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All file| *.* " })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(ofd.FileName);
                    string fileName = fileInfo.Name;
                    string fullName = fileInfo.FullName;
                    string userName = txt_username.Text;
                    string passwd = txt_password.Text;
                    string server = txt_ip.Text;
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", server, fileName)));
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(userName, passwd);
                    Stream ftpStream = request.GetRequestStream();
                    FileStream fs = File.OpenRead(fullName);
                    byte[] buffer = new byte[1024];
                    double total = (double)fs.Length;
                    int bytesRead = 0;

                    do
                    {

                        bytesRead = fs.Read(buffer, 0, 1024);
                        ftpStream.Write(buffer, 0, bytesRead);

                    }
                    while (bytesRead != 0);

                    fs.Close();
                    ftpStream.Close();
                }
            }
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog ofd = new SaveFileDialog() { Filter = "All file| *.* " })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(ofd.FileName);
                    string fileName = fileInfo.Name;
                    string fullName = fileInfo.FullName;
                    string userName = txt_username.Text;
                    string passwd = txt_password.Text;
                    string server = txt_ip.Text;
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", server, fileName)));
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    request.Credentials = new NetworkCredential(userName, passwd);
                    Stream ftpStream = request.GetRequestStream();
                    FileStream fs = File.OpenRead(fullName);
                    byte[] buffer = new byte[1024];
                    double total = (double)fs.Length;
                    int bytesRead = 0;
                    do
                    {
                        bytesRead = fs.Read(buffer, 0, 1024);
                        ftpStream.Write(buffer, 0, bytesRead);
                    }
                    while (bytesRead != 0);

                    fs.Close();
                    ftpStream.Close();
                }
            }
        }

    }
}