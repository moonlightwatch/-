using Shell32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace 音频文件整理工具
{
    public class MusicFileInfo
    {
        /// <summary>
        /// 歌曲名
        /// </summary>
        public string SongName { get; set; }
        /// <summary>
        /// 歌手
        /// </summary>
        public string Authors { get; set; }
        /// <summary>
        /// 专辑
        /// </summary>
        public string Album { get; set; }
        /// <summary>
        /// 时长
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        public FileInfo ThisFileInfo { get; set; }

        public MusicFileInfo(string filePath)
        {
            if (File.Exists(filePath))
            {
                ThisFileInfo = new FileInfo(filePath);
                try
                {
                    var sh = new Shell();
                    Folder dir = sh.NameSpace(System.IO.Path.GetDirectoryName(filePath));
                    FolderItem item = dir.ParseName(System.IO.Path.GetFileName(filePath));
                    SongName = dir.GetDetailsOf(item, 21);   // MP3 歌曲名
                    Authors = dir.GetDetailsOf(item, 20);  //Authors
                    Album = dir.GetDetailsOf(item, 14);  // MP3 专辑
                    var tmp = dir.GetDetailsOf(item, 27);  // 获取歌曲时长
                    Time = tmp.Substring(tmp.IndexOf(":") + 1);
                    Type = dir.GetDetailsOf(item, 9);
                }
                catch (Exception exc)
                { }
            }
        }

        public override string ToString()
        {
            return this.ThisFileInfo.Name;
        }
    }
}
