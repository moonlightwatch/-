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
        private FileCollectionClass fileCollection = new FileCollectionClass();

        private delegate void RefreshViewHandler();
        private RefreshViewHandler refreshHandeler = new RefreshViewHandler(() => { });
        private delegate void RefreshMessageHandler(string msg);
        private RefreshMessageHandler refreshMessageHandeler = new RefreshMessageHandler((string msg) => { });

        public MainForm()
        {
            InitializeComponent();
            this.treeView1.ImageList = new ImageList();
            this.treeView1.ImageList.ImageSize = new Size(16, 16);
            this.treeView1.ImageList.ColorDepth = ColorDepth.Depth32Bit;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            refreshMessageHandeler += RefreshMessage;
            refreshHandeler += RefreshView;
            fileCollection.OnLoadFileFinish += FileCollection_OnLoadFileFinish;
            fileCollection.OnLoadFile += FileCollection_OnLoadFile;
            comboBox1.SelectedIndex = 0;
        }

        private void FileCollection_OnLoadFile(object sender, LoadFileEventArgs e)
        {
            this.Invoke(refreshMessageHandeler, string.Format("已加载 {0} 个文件，获得 MP3 文件 {1} 个", this.fileCollection.MusicFiles.Count, this.fileCollection.MusicFiles.FindAll(m => m.SongName != null).Count));
        }

        private void FileCollection_OnLoadFileFinish(object sender, EventArgs e)
        {
            this.Invoke(refreshHandeler);
            this.Invoke(refreshMessageHandeler, string.Format("完成！ 已加载 {0} 个文件，获得 MP3 文件 {1} 个", this.fileCollection.MusicFiles.Count, this.fileCollection.MusicFiles.FindAll(m => m.SongName != null).Count));
        }

        private void RefreshMessage(string msg)
        {
            this.msgLabel.Text = msg;
        }

        private void RefreshView()
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList.Images.Clear();
            foreach (var tmp in this.imageList1.Images.Keys)
            {
                this.treeView1.ImageList.Images.Add(tmp, this.imageList1.Images[tmp]);
            }
            foreach (var kvp in this.fileCollection.GetAllIcons())
            {
                this.treeView1.ImageList.Images.Add(kvp.Key, kvp.Value);
            }
            Dictionary<string, List<TreeNode>> authorsNodeDic = new Dictionary<string, List<TreeNode>>();
            #region 按歌手检索
            foreach (var musicinfo in this.fileCollection.MusicFiles)
            {
                if (authorsNodeDic.Keys.Contains(musicinfo.Authors))
                {
                    authorsNodeDic[musicinfo.Authors].Add(new TreeNode()
                    {
                        Name = musicinfo.SongName,
                        Text = musicinfo.SongName + " - " + musicinfo.Album,
                        ImageKey = musicinfo.ThisFileInfo.Extension,
                        SelectedImageKey = musicinfo.ThisFileInfo.Extension,
                        StateImageKey = musicinfo.ThisFileInfo.Extension,
                        Tag = musicinfo
                    });
                }
                else
                {
                    authorsNodeDic[musicinfo.Authors] = new List<TreeNode>(){new TreeNode()
                    {
                        Name = musicinfo.SongName,
                        Text = musicinfo.SongName + " - " + musicinfo.Album,
                        ImageKey = musicinfo.ThisFileInfo.Extension,
                        SelectedImageKey = musicinfo.ThisFileInfo.Extension,
                        StateImageKey = musicinfo.ThisFileInfo.Extension,
                        Tag = musicinfo
                    } };
                }
            }
            #endregion
            foreach (var kvp in authorsNodeDic)
            {
                TreeNode tn = new TreeNode()
                {
                    Name = kvp.Key,
                    Text = kvp.Key,
                    SelectedImageKey = "authors",
                    StateImageKey = "authors",
                    ImageKey = "authors",
                };
                Dictionary<string, List<TreeNode>> albumNodeDic = new Dictionary<string, List<TreeNode>>();
                foreach (var cnode in kvp.Value)
                {
                    var mf = cnode.Tag as MusicFileInfo;
                    if (mf == null) continue;
                    if (albumNodeDic.Keys.Contains(mf.Album))
                    {
                        albumNodeDic[mf.Album].Add(cnode);
                    }
                    else
                    {
                        albumNodeDic[mf.Album] = new List<TreeNode>() { cnode };
                    }
                }
                foreach (var albumKvp in albumNodeDic)
                {
                    TreeNode albumNode = new TreeNode()
                    {
                        Name = albumKvp.Key,
                        Text = albumKvp.Key,
                        SelectedImageKey = "album",
                        StateImageKey = "album",
                        ImageKey = "album",
                    };
                    // albumNode.Nodes.AddRange(albumKvp.Value.ToArray());
                    // tn.Nodes.Add(albumNode);
                    tn.Nodes.AddRange(albumKvp.Value.ToArray());
                }
                this.treeView1.Nodes.Add(tn);
            }

        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("音频文件整理工具\n\n受 Chanbo 委托 由 MoonLightWatch 友情制作\n\ncopyright © 2017 MoonLightWatch", "关于");
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                fileCollection.StartLoadFolder(fbd.SelectedPath, true);

            }
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Node.Tag is MusicFileInfo)
            {
                var mf = e.Node.Tag as MusicFileInfo;
                ContextMenuStrip cms = new ContextMenuStrip();
                cms.Items.Add("播放", null, (object o, EventArgs ee) =>
                {
                    Process.Start(mf.ThisFileInfo.FullName);
                });
                cms.Items.Add("在文件浏览器中查看", null, (object o, EventArgs ee) =>
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = "explorer";
                    //打开资源管理器
                    proc.StartInfo.Arguments = @"/select," + mf.ThisFileInfo.FullName;
                    //选中"notepad.exe"这个程序,即记事本
                    proc.Start();
                });
                cms.Items.Add("复制", null, (object o, EventArgs ee) =>
                {
                    Clipboard.SetFileDropList(new System.Collections.Specialized.StringCollection() { mf.ThisFileInfo.FullName });
                });
                cms.Show(System.Windows.Forms.Control.MousePosition);
            }
        }

        private void 选项OToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".csv";
            sfd.AddExtension = true;
            sfd.FileName = "Musics.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                List<string> lines = new List<string>();
                lines.Add(string.Format("{0},{1},{2},{3},{4}", "歌曲名", "歌手", "专辑", "时长", "文件路径"));
                foreach (var item in this.fileCollection.MusicFiles)
                {
                    lines.Add(string.Format("{0},{1},{2},{3},{4}", item.SongName, item.Authors, item.Album, item.Time, item.ThisFileInfo.FullName));
                }
                System.IO.File.WriteAllLines(sfd.FileName, lines, Encoding.UTF8);
            }
        }

        private void 复制CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is MusicFileInfo)
            {
                Clipboard.SetFileDropList(new System.Collections.Specialized.StringCollection() { (treeView1.SelectedNode.Tag as MusicFileInfo).ThisFileInfo.FullName });
            }
        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))    //判断拖来的是否是文件  
                e.Effect = DragDropEffects.Link;                //是则将拖动源中的数据连接到控件  
            else e.Effect = DragDropEffects.None;
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                Array dirs = (System.Array)e.Data.GetData(DataFormats.FileDrop);
                if (dirs.Length > 0 && System.IO.Directory.Exists(dirs.GetValue(0).ToString()))
                {
                    fileCollection.StartLoadFolder(dirs.GetValue(0).ToString(), true);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            this.dataGridView1.Rows.Clear();
            foreach (var mf in this.fileCollection.MusicFiles)
            {
                if (comboBox1.SelectedItem.ToString() == "歌曲名称")
                {
                    if (!mf.SongName.Contains(textBox1.Text))
                    {
                        continue;
                    }
                }
                else if (comboBox1.SelectedItem.ToString() == "歌手")
                {
                    if (!mf.Authors.Contains(textBox1.Text))
                    {
                        continue;
                    }
                }
                else if (comboBox1.SelectedItem.ToString() == "专辑")
                {
                    if (!mf.Album.Contains(textBox1.Text))
                    {
                        continue;
                    }
                }
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);
                row.Cells[0].Value = mf.SongName;
                row.Cells[1].Value = mf.Authors;
                row.Cells[2].Value = mf.Album;
                row.Cells[3].Value = mf.Time;
                row.Cells[4].Value = mf.ThisFileInfo.FullName;
                row.Tag = mf;
                this.dataGridView1.Rows.Add(row);

            }

            Cursor = Cursors.Default;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this.dataGridView1.Rows[e.RowIndex].Tag is MusicFileInfo)
            {
                var mf = this.dataGridView1.Rows[e.RowIndex].Tag as MusicFileInfo;
                ContextMenuStrip cms = new ContextMenuStrip();
                cms.Items.Add("播放", null, (object o, EventArgs ee) =>
                {
                    Process.Start(mf.ThisFileInfo.FullName);
                });
                cms.Items.Add("在文件浏览器中查看", null, (object o, EventArgs ee) =>
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = "explorer";
                    //打开资源管理器
                    proc.StartInfo.Arguments = @"/select," + mf.ThisFileInfo.FullName;
                    //选中"notepad.exe"这个程序,即记事本
                    proc.Start();
                });
                cms.Items.Add("复制", null, (object o, EventArgs ee) =>
                {
                    Clipboard.SetFileDropList(new System.Collections.Specialized.StringCollection() { mf.ThisFileInfo.FullName });
                });
                cms.Show(System.Windows.Forms.Control.MousePosition);
            }
        }
    }
}
