using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 音频文件整理工具
{
    internal delegate void ShowMessageHandler(string msg);

    internal delegate void ShowDataToViewHandler(MP3FileInfo[] data);

    internal delegate void FindOneHandler(MP3FileInfo data, int count);

    public partial class MainForm : Form
    {
        private ShowMessageHandler showMessageHandler = null;
        private ShowDataToViewHandler showDataToViewHandler = null;
        private FindOneHandler findOneHandler = null;
        private MP3FileTool tool = new MP3FileTool();

        private MP3FileInfo[] showingData = new MP3FileInfo[] { };

        public MainForm()
        {
            InitializeComponent();
            this.treeView1.ImageList = new ImageList() { ImageSize = new Size(16, 16) };
            showMessageHandler = new ShowMessageHandler((string msg) =>
            {
                this.msgLabel.Text = msg;
            });
            showDataToViewHandler = new ShowDataToViewHandler((MP3FileInfo[] data) =>
            {
                ShowDataToView(data);
            });
            findOneHandler = new FindOneHandler((MP3FileInfo data, int count) =>
            {
                if (data != null)
                {
                    AddDataToView(data);
                    this.msgLabel.Text = string.Format("找到 {0} 个", count);
                }
            });
            tool.OnFindOne += Tool_OnFindOne;
            tool.OnLoadOne += Tool_OnLoadOne;
            tool.LoadCompleted += Tool_LoadCompleted;

        }

        private void Tool_OnFindOne(object sender, MP3FindOneEventArgs e)
        {
            this.Invoke(findOneHandler, new object[] { e.Itme, e.Count });
        }

        private void Tool_LoadCompleted(object sender, EventArgs e)
        {
            this.Invoke(showDataToViewHandler, new object[] { tool.GetAllFileInfos() });
        }

        private void Tool_OnLoadOne(object sender, MP3LoadOneEventArgs e)
        {
            ShowMessage(string.Format("{0}/{1} {2}", e.Index, e.Total, e.Itme.Title));
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

        private void AddDataToView(MP3FileInfo item)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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

        private void ShowMessage(string msg)
        {
            this.Invoke(showMessageHandler, new object[] { msg });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.comboBox_searchType.SelectedIndex = 0;

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
                var task = tool.LoadFromFolderAsync(folderBrowser.SelectedPath, true);
            }
        }


        private void 曲名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var files = tool.RenameAllFile(showingData, RenameFormat.Title);
            switch (label_view.Text)
            {
                case "文件预览":
                    ShowDataToView(files);
                    break;
                case "文件预览（按歌手）":
                    var folders1 = tool.FolderByPerformer(showingData);
                    ShowDataToView(folders1);
                    break;
                case "文件预览（按专辑）":
                    var folders2 = tool.FolderByAlbum(showingData);
                    ShowDataToView(folders2);
                    break;
            }
        }

        private void 曲名歌手ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var files = tool.RenameAllFile(tool.GetAllFileInfos(), RenameFormat.Title_Performer);
            switch (label_view.Text)
            {
                case "文件预览":
                    ShowDataToView(files);
                    break;
                case "文件预览（按歌手）":
                    var folders1 = tool.FolderByPerformer(showingData);
                    ShowDataToView(folders1);
                    break;
                case "文件预览（按专辑）":
                    var folders2 = tool.FolderByAlbum(showingData);
                    ShowDataToView(folders2);
                    break;
            }
        }

        private void 歌手曲名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var files = tool.RenameAllFile(tool.GetAllFileInfos(), RenameFormat.Performer_Title);
            switch (label_view.Text)
            {
                case "文件预览":
                    ShowDataToView(files);
                    break;
                case "文件预览（按歌手）":
                    var folders1 = tool.FolderByPerformer(showingData);
                    ShowDataToView(folders1);
                    break;
                case "文件预览（按专辑）":
                    var folders2 = tool.FolderByAlbum(showingData);
                    ShowDataToView(folders2);
                    break;
            }
        }

        private void 平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDataToView(showingData);
            label_view.Text = "文件预览";
        }

        private void 按专辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var folders = tool.FolderByAlbum(showingData);
            ShowDataToView(folders);
            label_view.Text = "文件预览（按专辑）";
        }

        private void 按歌手ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var folders = tool.FolderByPerformer(showingData);
            ShowDataToView(folders);
            label_view.Text = "文件预览（按歌手）";
        }

        private void textBox_searchbox_TextChanged(object sender, EventArgs e)
        {
            RunSearchAsync(textBox_searchbox.Text, comboBox_searchType.SelectedItem.ToString());
        }

        private void comboBox_searchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_searchbox.Text))
            {
                RunSearchAsync(textBox_searchbox.Text, comboBox_searchType.SelectedItem.ToString());
            }
        }

        private async Task RunSearchAsync(string searchText, string searchType)
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList.Images.Clear();
            if (searchType == "搜曲名")
            {
                await tool.Search(searchText, SearchType.Title);
                //     tmpData = sourceData.Where(f => f.Title.Contains(text)).ToArray();
            }
            if (searchType == "搜歌手")
            {
                await tool.Search(searchText, SearchType.Performer);
            }
            if (searchType == "搜专辑")
            {
                await tool.Search(searchText, SearchType.Album);
            }

            label_view.Text = "文件预览";
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is MP3FileInfo)
            {
                pictureBox1.Image = (e.Node.Tag as MP3FileInfo).Picture;
                textBox_info.Text = (e.Node.Tag as MP3FileInfo).DetailsString();
            }
            else
            {
                pictureBox1.Image = null;
                textBox_info.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
            if (e.Button == MouseButtons.Right && treeView1.SelectedNode.Tag is MP3FileInfo)
            {
                ContextMenuStrip cms = new ContextMenuStrip();
                cms.Items.Add("播放", null, (object obj, EventArgs ee) =>
                {
                    Process.Start((treeView1.SelectedNode.Tag as MP3FileInfo).FilePath);
                });

                cms.Show(treeView1.PointToScreen(new Point(e.X, e.Y)));
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && pictureBox1.Image != null)
            {
                ContextMenuStrip cms = new ContextMenuStrip();
                cms.Items.Add("封面另存为", null, (object obj, EventArgs ee) =>
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.FileName = (treeView1.SelectedNode.Tag as MP3FileInfo).Title + ".jpg";
                    sfd.Filter = "图片|*.jpg";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                });

                cms.Show(pictureBox1.PointToScreen(new Point(e.X, e.Y)));
            }
        }

        private void 另存为AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fBrowser = new FolderBrowserDialog();
            if (fBrowser.ShowDialog() == DialogResult.OK)
            {
                List<string> folders = new List<string>();
                Dictionary<string, string> fileCopy_dic = new Dictionary<string, string>();
                foreach (TreeNode tn in treeView1.Nodes)
                {
                    if (tn.Tag is MP3FileInfo)
                    {
                        var file = tn.Tag as MP3FileInfo;
                        fileCopy_dic[file.FilePath] = Path.Combine(fBrowser.SelectedPath, file.FileName);
                    }
                    else
                    {
                        var newFolder = Path.Combine(fBrowser.SelectedPath, tn.Text);
                        if (!Directory.Exists(newFolder))
                        {
                            folders.Add(newFolder);
                        }
                        foreach (TreeNode ctn in tn.Nodes)
                        {
                            if (ctn.Tag is MP3FileInfo)
                            {
                                var file = ctn.Tag as MP3FileInfo;
                                fileCopy_dic[file.FilePath] = Path.Combine(newFolder, file.FileName);
                            }
                        }
                    }
                }
                var result = MessageBox.Show("确定将预览内容另存到：" + fBrowser.SelectedPath, "保存确认", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (var item in folders)
                    {
                        Directory.CreateDirectory(item);
                    }

                    foreach (var key in fileCopy_dic.Keys)
                    {
                        try
                        {
                            File.Copy(key, fileCopy_dic[key], true);
                        }
                        catch (Exception exc)
                        { }
                    }

                    MessageBox.Show("完成");
                }
            }
        }

        private void 导出所有歌曲信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".csv";
            sfd.FileName = "Musics.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("曲名,歌手,专辑,本地路径");
                sb.Append(Environment.NewLine);
                foreach (var item in tool.GetAllFileInfos())
                {
                    sb.Append(item.GetCSVLine());
                    sb.Append(Environment.NewLine);
                }
                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
            }

        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
            if (treeView1.SelectedNode.Tag is MP3FileInfo)
            {
                Process.Start((treeView1.SelectedNode.Tag as MP3FileInfo).FilePath);

            }
        }
    }
}
