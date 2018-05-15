using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace 音频文件整理工具
{
    public class MP3FileInfo
    {
        /// <summary>
        /// 是否有ID3头
        /// </summary>
        public bool HaveID3 { get; set; } = false;
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 曲名
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 演唱者
        /// </summary>
        public string Performer { get; set; }
        /// <summary>
        /// 专辑
        /// </summary>
        public string Album { get; set; }
        /// <summary>
        /// 年代
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public Image Picture { get; set; }

        /// <summary>
        /// 获取格式化名称
        /// </summary>
        /// <param name="format">格式化类型</param>
        /// <returns>格式化后的名称</returns>
        public string FormatFileName(RenameFormat format)
        {
            string result = Title;
            switch (format)
            {
                case RenameFormat.Performer_Title:
                    result = string.Format("{0}-{1}.mp3", this.Performer, this.Title);
                    break;
                case RenameFormat.Title_Performer:
                    result = string.Format("{0}-{1}.mp3", this.Title, this.Performer);
                    break;
                case RenameFormat.Title:
                    result = string.Format("{0}.mp3", this.Title);
                    break;
            }
            return result.Replace("\\", "").Replace("/", "");
        }

        public string DetailsString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("曲名：{0}", this.Title));
            sb.Append(Environment.NewLine);
            sb.Append(string.Format("歌手：{0}", this.Performer));
            sb.Append(Environment.NewLine);
            sb.Append(string.Format("专辑：{0}", this.Album));
            sb.Append(Environment.NewLine);
            sb.Append(string.Format("年代：{0}", this.Year));
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(string.Format("文件名：{0}", this.FileName));
            sb.Append(Environment.NewLine);
            var fs = File.Open(this.FilePath, FileMode.Open, FileAccess.Read);
            sb.Append(Environment.NewLine);
            sb.Append(string.Format("文件尺寸：{0:N2} M", (fs.Length / 1024.0) / 1024.0));
            fs.Close();
            sb.Append(Environment.NewLine);
            sb.Append(string.Format("文件路径：{0}", this.FilePath));
            return sb.ToString();
        }

        public string GetCSVLine()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Title.Replace(",", ""));
            sb.Append(",");
            sb.Append(this.Performer.Replace(",", ""));
            sb.Append(",");
            sb.Append(this.Album.Replace(",", ""));
            sb.Append(",");
            sb.Append(this.FilePath.Replace(",", ""));
            return sb.ToString();
        }
    }

    internal class MP3FolderInfo
    {
        public string Name { get; set; }

        private List<MP3FileInfo> fileInfos = new List<MP3FileInfo>();
        private List<MP3FolderInfo> folderInfos = new List<MP3FolderInfo>();

        public List<MP3FileInfo> FileInfos { get => fileInfos; set => fileInfos = value; }
        internal List<MP3FolderInfo> FolderInfos { get => folderInfos; set => folderInfos = value; }
    }

    /// <summary>
    /// 重命名格式
    /// </summary>
    public enum RenameFormat
    {
        Performer_Title,//演唱者-曲名
        Title_Performer,//曲名-演唱者
        Title,//仅曲名
    }
}
