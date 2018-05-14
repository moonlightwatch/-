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
        internal bool HaveID3 { get; set; } = false;
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

    }
}
