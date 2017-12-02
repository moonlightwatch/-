using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 音频文件整理工具
{
    public delegate void LoadFileEventHandler(object sender, LoadFileEventArgs e);

    public class LoadFileEventArgs : EventArgs
    {
        public MusicFileInfo MusicFile { get; set; }

        public LoadFileEventArgs(MusicFileInfo musicFile)
        {
            this.MusicFile = musicFile;
        }
    }
}
