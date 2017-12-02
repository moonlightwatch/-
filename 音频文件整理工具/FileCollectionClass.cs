using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace 音频文件整理工具
{
    public class FileCollectionClass
    {
        private List<MusicFileInfo> musicFiles = new List<MusicFileInfo>();

        public List<MusicFileInfo> MusicFiles { get => musicFiles; set => musicFiles = value; }

        #region 事件
        public event LoadFileEventHandler OnLoadFile = new LoadFileEventHandler((object sender, LoadFileEventArgs e) => { });
        //public event LoadFileEventHandler OnLoadFileError = new LoadFileEventHandler((object sender, LoadFileEventArgs e) => { });
        public event EventHandler OnLoadFileFinish = new EventHandler((object sender, EventArgs e) => { });

        #endregion

        public FileCollectionClass()
        {
        }

        public void StartLoadFolder(string folderPath, bool recursively)
        {
            Task t = new Task(() =>
            {
                var files = GetAllFilePath(folderPath, recursively);
                foreach (var filepath in files)
                {
                    try
                    {
                        MusicFileInfo mf = new MusicFileInfo(filepath);
                        MusicFiles.Add(mf);
                        OnLoadFile(this, new LoadFileEventArgs(mf));
                    }
                    catch (Exception exc)
                    { }
                }
                OnLoadFileFinish(this, new EventArgs());
            });
            t.Start();
        }

        #region 工具函数
        public Dictionary<string, Image> GetAllIcons()
        {
            Dictionary<string, Image> Images = new Dictionary<string, Image>();
            foreach (var mf in MusicFiles)
            {
                string fileName = "tmp" + mf.ThisFileInfo.Extension;
                File.Create(fileName).Close();
                Image img = System.Drawing.Icon.ExtractAssociatedIcon(fileName).ToBitmap();
                Images[mf.ThisFileInfo.Extension] = img;
                File.Delete(fileName);
            }
            return Images;
        }

        private List<string> GetAllFilePath(string rootFolder, bool recursively)
        {
            if (!Directory.Exists(rootFolder))
            {
                return new List<string>();
            }
            List<string> allFilePath = new List<string>();

            foreach (var files in Directory.GetFiles(rootFolder))
            {
                allFilePath.Add(files);
            }
            if (recursively)
            {
                foreach (var dir in Directory.GetDirectories(rootFolder))
                {
                    allFilePath.AddRange(GetAllFilePath(dir, recursively));
                }
            }

            return allFilePath;
        }
        #endregion
    }
}
