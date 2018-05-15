﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Resources;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList.Images.Clear();
            foreach (var item in fileInfos)
            {
                if (item.Picture != null)
                {
                    this.treeView1.ImageList.Images.Add(item.FilePath, item.Picture);
                }
                else
                {
                    this.treeView1.ImageList.Images.Add(item.FilePath, ((System.Drawing.Icon)(resources.GetObject("$this.Icon"))));
                }
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
            var folderImg = Image.FromStream(this.GetType().Assembly.GetManifestResourceStream("音频文件整理工具.Resources.folder.bmp"));
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList.Images.Clear();
            this.treeView1.ImageList.Images.Add("folder", folderImg);
            foreach (var folder in folders)
            {
                var folderNode = new TreeNode(folder.Name)
                {
                    ImageKey = "folder",
                    SelectedImageKey = "folder",
                    StateImageKey = "folder"
                };
                this.treeView1.Nodes.Add(folderNode);
                foreach (var item in folder.FileInfos)
                {
                    this.treeView1.ImageList.Images.Add(item.FilePath, item.Picture);
                    folderNode.Nodes.Add(new TreeNode(item.FileName)
                    {
                        Tag = item,
                        ImageKey = item.FilePath,
                        SelectedImageKey = item.FilePath,
                        StateImageKey = item.FilePath
                    });
                }
            }
            this.treeView1.ExpandAll();
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
