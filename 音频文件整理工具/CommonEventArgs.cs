using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 音频文件整理工具
{
    public delegate void MP3LoadOneEventHandler(object sender, MP3LoadOneEventArgs e);

    public class MP3LoadOneEventArgs : EventArgs
    {
        public MP3FileInfo Itme { get; set; }
        public int Index { get; set; }
        public int Total { get; set; }
    }
}
