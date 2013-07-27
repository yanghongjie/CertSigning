using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertSigning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            //证书创建工具，根据vs版本不同可能位置不一样，下面是vs2012位置，http://msdn.microsoft.com/zh-cn/library/bfsktky3(v=vs.100).aspx
            const string MakeCert = "C:\\Program Files (x86)\\Microsoft SDKs\\Windows\\v7.1A\\bin\\makecert.exe";
            //证书生成成功后默认导出到当前项目根目录
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "yhj.cer");
            //证书名称
            string certName = "yhj";
            //生成证书命令行，生成在当前用户的个人证书存储区
            string arguments = string.Format("-r -pe -n \"CN={0}\" -a sha1 -b 01/01/2012 -e 01/01/2040 -sky exchange \"{1}\" -ss my", certName, filePath);
            //生成证书
            ProcessStartInfo pi = new ProcessStartInfo(MakeCert, arguments);
            //隐藏生产
            pi.WindowStyle = ProcessWindowStyle.Hidden;
            //开始生成证书
            Process p = Process.Start(pi);
            p.WaitForExit();
            //找到生成的证书
            X509Certificate2 cert = new X509Certificate2(AppDomain.CurrentDomain.BaseDirectory + "yhj.cer");
            if (cert != null)
            {
                //查找受信任的根证书颁发机构证书区是否已经存在该证书，不存在则添加
                var store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadWrite);
                if (!store.Certificates.Contains(cert))
                {
                    store.Add(cert);
                    MessageBox.Show("已添加");
                }
            }
        }

        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        private static extern int ExtractIconEx(string lpszFile, int niconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, int nIcons);

        private IntPtr[] largeIcons = new IntPtr[1];
        private IntPtr[] smallIcons = new IntPtr[1];  


        private void lvdropitem_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            ExtractIconEx(path, 0, largeIcons, smallIcons, 1);
            imagelist.Images.Clear();
            imagelist.Images.Add(Icon.FromHandle(largeIcons[0]));

            ListViewItem lvi = new ListViewItem();
            lvi.ImageIndex = 0;  //listview子项图标索引项  

            this.lvdropitem.Items.Clear();
            this.lvdropitem.Items.Add(lvi);  
         
        }

        private void lvdropitem_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                string extension = System.IO.Path.GetExtension(path);
                if (extension != ".exe")
                {
                    e.Effect = DragDropEffects.None;
                }
                else
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

        }

      
        //"C:\Program Files (x86)\Windows Kits\8.0\bin\x86\signtool.exe" sign /a /n yhj $(TargetPath)




    }
}
