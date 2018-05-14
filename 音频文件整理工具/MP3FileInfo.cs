using System;
using System.Collections.Generic;
using System.Drawing;
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
        /// MD5
        /// </summary>
        public string MD5 { get; set; }
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
            switch (format)
            {
                case RenameFormat.Performer_Title:
                    return string.Format("{0}-{1}", this.Performer, this.Title);
                case RenameFormat.Title_Performer:
                    return string.Format("{0}-{1}", this.Title, this.Performer);
                case RenameFormat.Title:
                    return this.Title;
            }
            return Title;
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
