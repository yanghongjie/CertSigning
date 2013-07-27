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
    public partial class Main : Form
    {
        #region 构造函数
        public Main()
        {
            InitializeComponent();
        } 
        #endregion

        #region 变量及方法定义
        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        private static extern int ExtractIconEx(string lpszFile, int niconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, int nIcons);

        private IntPtr[] largeIcons = new IntPtr[1];
        #endregion

        #region 控件事件
        //拖拽完成
        private void lvdropitem_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            ExtractIconEx(path, 0, largeIcons, new IntPtr[0], 1);
            imagelist.Images.Clear();
            imagelist.Images.Add(Icon.FromHandle(largeIcons[0]));

            ListViewItem lvi = new ListViewItem();
            lvi.ImageIndex = 0;  //listview子项图标索引项  

            this.lvdropitem.Items.Clear();
            this.lvdropitem.Items.Add(lvi);

            tb_filepath.Text = path;
        }
        //拖拽至该控件工作区
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
        //生成证书
        private void btn_generate_Click(object sender, EventArgs e)
        {
            if (tb_certname.Text == string.Empty)
            {
                MessageBox.Show("请填写要生成证书的名称", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string path = FolderBrowserDialog();
            if (string.Empty != path)
            {
                string certName = tb_certname.Text;
                string certpath = Path.Combine(path, certName + ".cer");
                GenerateCert(certName, certpath);
                tb_certpath.Text = certpath;
                MessageBox.Show("生成完毕！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //浏览证书
        private void btn_browse_Click(object sender, EventArgs e)
        {
            string certpath = OpenDialog();
            if (string.Empty != certpath)
            {
                string certName = Path.GetFileNameWithoutExtension(certpath);
                ImportCert(certName, certpath);
                tb_certname.Text = certName;
                tb_certpath.Text = certpath;
            }
        }
        //签名
        private void btn_Signture_Click(object sender, EventArgs e)
        {
            if (tb_filepath.Text == string.Empty)
            {
                MessageBox.Show("未找到需要签名的程序", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tb_certpath.Text == string.Empty)
            {
                MessageBox.Show("未找到用来签名的证书", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Signature(tb_certname.Text, tb_filepath.Text);

            MessageBox.Show("签名完毕！\r\n提示：重新以管理员身份运行该程序可查看签名效果", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } 
        #endregion

        #region 私有方法
        /// <summary>
        /// 证书生成到
        /// </summary>
        private string FolderBrowserDialog()
        {
            string localFilePath = string.Empty;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            // 设置根在桌面
            fbd.RootFolder = System.Environment.SpecialFolder.Desktop;
            // 设置当前选择的路径
            fbd.SelectedPath = "C:";
            // 允许在对话框中包括一个新建目录的按钮
            fbd.ShowNewFolderButton = true;
            // 设置对话框的说明信息
            fbd.Description = "请选择证书输出目录";
            // 打开
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                localFilePath = fbd.SelectedPath;
            }

            return localFilePath;
        }
        /// <summary>
        /// 选择证书
        /// </summary>
        /// <returns></returns>
        private string OpenDialog()
        {
            string localFilePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "证书文件(.cer)|*.cer";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                localFilePath = openFileDialog.FileName;
            }
            return localFilePath;
        }
        /// <summary>
        /// 生成证书
        /// </summary>
        /// <param name="certName">证书名称</param>
        /// <param name="certPath">证书生成后导出路径</param>
        private void GenerateCert(string certName, string certPath)
        {
            //证书创建工具，根据vs版本不同可能位置不一样，下面是vs2012位置，http://msdn.microsoft.com/zh-cn/library/bfsktky3(v=vs.100).aspx
            const string MakeCert = "C:\\Program Files (x86)\\Microsoft SDKs\\Windows\\v7.1A\\bin\\makecert.exe";
            //证书生成成功后默认导出到当前项目根目录
            //string certPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "demo.cer");
            //生成证书命令行，生成在当前用户的个人证书存储区
            string arguments = string.Format("-r -pe -n \"CN={0}\" -a sha1 -b 01/01/2012 -e 01/01/2040 -sky exchange \"{1}\" -ss my", certName, certPath);
            //生成证书
            ProcessStartInfo pi = new ProcessStartInfo(MakeCert, arguments);
            //隐藏
            pi.WindowStyle = ProcessWindowStyle.Hidden;
            //开始生成证书
            Process p = Process.Start(pi);
            p.WaitForExit();
            //找到生成的证书
            X509Certificate2 cert = new X509Certificate2(certPath);
            if (cert != null)
            {
                //查找个人证书区是否已经存在该证书，不存在则添加
                var storeMy = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                storeMy.Open(OpenFlags.ReadWrite);
                bool MyIsExist = storeMy.Certificates.Find(X509FindType.FindByIssuerName, certName, true).Count == 0;
                if (MyIsExist)//(!storeMy.Certificates.Contains(cert))
                {
                    storeMy.Add(cert);
                }
                //查找受信任的根证书颁发机构证书区是否已经存在该证书，不存在则添加
                var storeRoot = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
                storeRoot.Open(OpenFlags.ReadWrite);
                bool RootIsExist = storeRoot.Certificates.Find(X509FindType.FindByIssuerName, certName, true).Count == 0;
                if (RootIsExist)//(!storeRoot.Certificates.Contains(cert))
                {
                    storeRoot.Add(cert);
                }
            }
        }
        /// <summary>
        /// 导入证书
        /// </summary>
        /// <param name="certName">证书名称</param>
        /// <param name="certPath">证书路径</param>
        private void ImportCert(string certName, string certPath)
        {
            //找到生成的证书
            X509Certificate2 cert = new X509Certificate2(certPath);
            if (cert != null)
            {
                //查找个人证书区是否已经存在该证书，不存在则添加
                var storeMy = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                storeMy.Open(OpenFlags.ReadWrite);
                bool MyIsExist = storeMy.Certificates.Find(X509FindType.FindByIssuerName, certName, true).Count == 0;
                if (MyIsExist)//(!storeMy.Certificates.Contains(cert))
                {
                    storeMy.Add(cert);
                }
                //查找受信任的根证书颁发机构证书区是否已经存在该证书，不存在则添加
                var storeRoot = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
                storeRoot.Open(OpenFlags.ReadWrite);
                bool RootIsExist = storeRoot.Certificates.Find(X509FindType.FindByIssuerName, certName, true).Count == 0;
                if (RootIsExist)//(!storeRoot.Certificates.Contains(cert))
                {
                    storeRoot.Add(cert);
                }
            }
        }
        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="certName">证书名称</param>
        /// <param name="ProgramPath">需要签名的程序路径</param>
        private void Signature(string certName, string ProgramPath)
        {
            //签名工具 http://msdn.microsoft.com/zh-cn/library/8s9b9yaz(v=vs.100).aspx
            const string Signtool = "C:\\Program Files (x86)\\Windows Kits\\8.0\\bin\\x86\\signtool.exe";
            //签名命令行
            string arguments = string.Format("sign /a /n \"{0}\" \"{1}\"", certName, ProgramPath);
            //签名
            ProcessStartInfo pi = new ProcessStartInfo(Signtool, arguments);
            //隐藏
            pi.WindowStyle = ProcessWindowStyle.Hidden;
            //开始签名
            Process p = Process.Start(pi);
            p.WaitForExit();
        } 
        #endregion
    }
}
