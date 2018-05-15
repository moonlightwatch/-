using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 音频文件整理工具
{

    public partial class MainForm : Form
    {
        private MP3FileTool tool = new MP3FileTool();

        public MainForm()
        {
            InitializeComponent();
            this.treeView1.ImageList = new ImageList() { ImageSize = new Size(16, 16) };
        }

        private void ShowDataToView(MP3FileInfo[] fileInfos)
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList.Images.Clear();
            foreach (var item in fileInfos)
            {
                this.treeView1.ImageList.Images.Add(item.FilePath, item.Picture);
                this.treeView1.Nodes.Add(new TreeNode(item.FileName)
                {
                    Tag = item,
                    ImageKey = item.FilePath,
                    SelectedImageKey = item.FilePath,
                    StateImageKey = item.FilePath
                });
            }
        }

        private void ShowDataToView(MP3FolderInfo[] folders)
        {
            //this.listView1.Groups.Clear();
            //this.listView1.Items.Clear();
            //foreach (var folder in folders)
            //{
            //    var group = new ListViewGroup(folder.Name) { Tag = folder };
            //    this.listView1.Groups.Add(group);
            //    foreach (var item in folder.FileInfos)
            //    {
            //        this.listView1.Items.Add(new ListViewItem(item.FileName, group) { Tag = item });
            //    }
            //}
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("放弃未保存的任何操作？", "关闭", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                tool.LoadFromFolder(folderBrowser.SelectedPath, true);
                ShowDataToView(tool.GetAllFileInfos());
            }

        }

        private void 按歌手分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var folders = tool.FolderByPerformer();
            ShowDataToView(folders);
        }

        private void 按专辑分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var folders = tool.FolderByAlbum();
            ShowDataToView(folders);
        }
    }
}
