namespace CertSigning
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btn_Signture = new System.Windows.Forms.Button();
            this.lvdropitem = new System.Windows.Forms.ListView();
            this.imagelist = new System.Windows.Forms.ImageList(this.components);
            this.lbtip = new System.Windows.Forms.Label();
            this.tb_filepath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_browse = new System.Windows.Forms.Button();
            this.tb_certname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_generate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_certpath = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Signture
            // 
            this.btn_Signture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Signture.Location = new System.Drawing.Point(399, 221);
            this.btn_Signture.Name = "btn_Signture";
            this.btn_Signture.Size = new System.Drawing.Size(83, 27);
            this.btn_Signture.TabIndex = 0;
            this.btn_Signture.Text = "签名";
            this.btn_Signture.UseVisualStyleBackColor = true;
            this.btn_Signture.Click += new System.EventHandler(this.btn_Signture_Click);
            // 
            // lvdropitem
            // 
            this.lvdropitem.AllowDrop = true;
            this.lvdropitem.LargeImageList = this.imagelist;
            this.lvdropitem.Location = new System.Drawing.Point(94, 26);
            this.lvdropitem.Margin = new System.Windows.Forms.Padding(0);
            this.lvdropitem.Name = "lvdropitem";
            this.lvdropitem.Scrollable = false;
            this.lvdropitem.Size = new System.Drawing.Size(211, 48);
            this.lvdropitem.TabIndex = 3;
            this.lvdropitem.UseCompatibleStateImageBehavior = false;
            this.lvdropitem.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvdropitem_DragDrop);
            this.lvdropitem.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvdropitem_DragEnter);
            // 
            // imagelist
            // 
            this.imagelist.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imagelist.ImageSize = new System.Drawing.Size(32, 32);
            this.imagelist.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lbtip
            // 
            this.lbtip.AutoSize = true;
            this.lbtip.BackColor = System.Drawing.Color.White;
            this.lbtip.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbtip.Location = new System.Drawing.Point(181, 44);
            this.lbtip.Name = "lbtip";
            this.lbtip.Size = new System.Drawing.Size(101, 12);
            this.lbtip.TabIndex = 10;
            this.lbtip.Text = "将程序拖拽至框内";
            // 
            // tb_filepath
            // 
            this.tb_filepath.Location = new System.Drawing.Point(94, 88);
            this.tb_filepath.Name = "tb_filepath";
            this.tb_filepath.ReadOnly = true;
            this.tb_filepath.Size = new System.Drawing.Size(388, 21);
            this.tb_filepath.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "程序路径：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "当前程序：";
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(407, 123);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 6;
            this.btn_browse.Text = "浏览...";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // tb_certname
            // 
            this.tb_certname.Location = new System.Drawing.Point(94, 124);
            this.tb_certname.Name = "tb_certname";
            this.tb_certname.Size = new System.Drawing.Size(221, 21);
            this.tb_certname.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "证书名称：";
            // 
            // btn_generate
            // 
            this.btn_generate.Location = new System.Drawing.Point(326, 123);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(75, 23);
            this.btn_generate.TabIndex = 11;
            this.btn_generate.Text = "生成";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "证书路径：";
            // 
            // tb_certpath
            // 
            this.tb_certpath.Location = new System.Drawing.Point(94, 162);
            this.tb_certpath.Name = "tb_certpath";
            this.tb_certpath.ReadOnly = true;
            this.tb_certpath.Size = new System.Drawing.Size(388, 21);
            this.tb_certpath.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(12, 201);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(494, 1);
            this.textBox2.TabIndex = 12;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 260);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btn_generate);
            this.Controls.Add(this.lbtip);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.tb_certpath);
            this.Controls.Add(this.tb_filepath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_certname);
            this.Controls.Add(this.lvdropitem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Signture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "证书签名";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Signture;
        private System.Windows.Forms.ListView lvdropitem;
        private System.Windows.Forms.ImageList imagelist;
        private System.Windows.Forms.TextBox tb_filepath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_certname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbtip;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_certpath;
        private System.Windows.Forms.TextBox textBox2;
    }
}

