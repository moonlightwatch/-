namespace 音频文件整理工具
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_view = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.分类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.曲名歌手ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.歌手曲名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.曲名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分类ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.按专辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按歌手ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.平铺ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.工具TToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(685, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开OToolStripMenuItem,
            this.toolStripSeparator,
            this.保存SToolStripMenuItem,
            this.另存为AToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出XToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打开OToolStripMenuItem.Image")));
            this.打开OToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.打开OToolStripMenuItem.Text = "打开(&O)";
            this.打开OToolStripMenuItem.Click += new System.EventHandler(this.打开OToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("保存SToolStripMenuItem.Image")));
            this.保存SToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.保存SToolStripMenuItem.Text = "保存(&S)";
            // 
            // 另存为AToolStripMenuItem
            // 
            this.另存为AToolStripMenuItem.Name = "另存为AToolStripMenuItem";
            this.另存为AToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.另存为AToolStripMenuItem.Text = "另存为(&A)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            this.退出XToolStripMenuItem.Click += new System.EventHandler(this.退出XToolStripMenuItem_Click);
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.分类ToolStripMenuItem1,
            this.分类ToolStripMenuItem});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.关于AToolStripMenuItem.Text = "关于(&A)...";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(685, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(685, 394);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label_view, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.treeView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(228, 394);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_view
            // 
            this.label_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_view.Location = new System.Drawing.Point(4, 1);
            this.label_view.Name = "label_view";
            this.label_view.Size = new System.Drawing.Size(220, 25);
            this.label_view.TabIndex = 0;
            this.label_view.Text = "文件预览";
            this.label_view.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(4, 30);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(220, 360);
            this.treeView1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(453, 394);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(445, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "文件属性";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 分类ToolStripMenuItem
            // 
            this.分类ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.曲名ToolStripMenuItem,
            this.曲名歌手ToolStripMenuItem,
            this.歌手曲名ToolStripMenuItem});
            this.分类ToolStripMenuItem.Name = "分类ToolStripMenuItem";
            this.分类ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.分类ToolStripMenuItem.Text = "重命名";
            // 
            // 曲名歌手ToolStripMenuItem
            // 
            this.曲名歌手ToolStripMenuItem.Name = "曲名歌手ToolStripMenuItem";
            this.曲名歌手ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.曲名歌手ToolStripMenuItem.Text = "曲名-歌手";
            this.曲名歌手ToolStripMenuItem.Click += new System.EventHandler(this.曲名歌手ToolStripMenuItem_Click);
            // 
            // 歌手曲名ToolStripMenuItem
            // 
            this.歌手曲名ToolStripMenuItem.Name = "歌手曲名ToolStripMenuItem";
            this.歌手曲名ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.歌手曲名ToolStripMenuItem.Text = "歌手-曲名";
            this.歌手曲名ToolStripMenuItem.Click += new System.EventHandler(this.歌手曲名ToolStripMenuItem_Click);
            // 
            // 曲名ToolStripMenuItem
            // 
            this.曲名ToolStripMenuItem.Name = "曲名ToolStripMenuItem";
            this.曲名ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.曲名ToolStripMenuItem.Text = "曲名";
            this.曲名ToolStripMenuItem.Click += new System.EventHandler(this.曲名ToolStripMenuItem_Click);
            // 
            // 分类ToolStripMenuItem1
            // 
            this.分类ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.平铺ToolStripMenuItem,
            this.按专辑ToolStripMenuItem,
            this.按歌手ToolStripMenuItem});
            this.分类ToolStripMenuItem1.Name = "分类ToolStripMenuItem1";
            this.分类ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.分类ToolStripMenuItem1.Text = "分类";
            // 
            // 按专辑ToolStripMenuItem
            // 
            this.按专辑ToolStripMenuItem.Name = "按专辑ToolStripMenuItem";
            this.按专辑ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.按专辑ToolStripMenuItem.Text = "按专辑";
            this.按专辑ToolStripMenuItem.Click += new System.EventHandler(this.按专辑ToolStripMenuItem_Click);
            // 
            // 按歌手ToolStripMenuItem
            // 
            this.按歌手ToolStripMenuItem.Name = "按歌手ToolStripMenuItem";
            this.按歌手ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.按歌手ToolStripMenuItem.Text = "按歌手";
            this.按歌手ToolStripMenuItem.Click += new System.EventHandler(this.按歌手ToolStripMenuItem_Click);
            // 
            // 平铺ToolStripMenuItem
            // 
            this.平铺ToolStripMenuItem.Name = "平铺ToolStripMenuItem";
            this.平铺ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.平铺ToolStripMenuItem.Text = "平铺";
            this.平铺ToolStripMenuItem.Click += new System.EventHandler(this.平铺ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(685, 441);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "音频文件整理工具 - by MoonLightWatch";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为AToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_view;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem 分类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 曲名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 曲名歌手ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 歌手曲名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分类ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 平铺ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按专辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按歌手ToolStripMenuItem;
    }
}

