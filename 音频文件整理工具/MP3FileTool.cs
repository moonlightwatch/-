using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Drawing;

namespace 音频文件整理工具
{
    internal class MP3FileTool
    {
        /// <summary>
        /// MP3文件信息集合
        /// </summary>
        private List<MP3FileInfo> fileInfos = new List<MP3FileInfo>();

        internal void LoadFromFolder(string path, bool reopen)
        {

            if (!Directory.Exists(path))
            {
                return;
            }
            if (reopen == true)
            {
                fileInfos.Clear();
            }
            MP3Loader loader = new MP3Loader();
            var files = Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories);
            foreach (var item in files)
            {
                var tmp = loader.LoadFromFile(item);
                if (tmp != null)
                {
                    fileInfos.Add(tmp);
                }
            }
        }

        internal void LoadFromFile(string path, bool reopen)
        {
            if (!File.Exists(path))
            {
                return;
            }
            if (reopen == true)
            {
                fileInfos.Clear();
            }
            MP3Loader loader = new MP3Loader();
            var tmp = loader.LoadFromFile(path);
            if (tmp != null)
            {
                fileInfos.Add(tmp);
            }
        }

        internal MP3FileInfo[] GetAllFileInfos()
        {
            return fileInfos.ToArray();
        }

        internal void RenameAllFile(RenameFormat format)
        {
            foreach (var item in fileInfos)
            {
                item.FileName = item.FormatFileName(format);
            }
        }

        internal List<MP3FolderInfo> FolderByAlbum()
        {
            List<MP3FolderInfo> result = new List<MP3FolderInfo>();
            foreach (var item in fileInfos)
            {
                var tmp = result.Find(f => f.Name == item.Album);
                if (tmp == null)
                {
                    MP3FolderInfo newFolder = new MP3FolderInfo();
                    newFolder.Name = item.Album;
                    newFolder.FileInfos.Add(item);
                    result.Add(newFolder);
                }
                else
                {
                    tmp.FileInfos.Add(item);
                }
            }
            return result;
        }

        internal List<MP3FolderInfo> FolderByPerformer()
        {
            List<MP3FolderInfo> result = new List<MP3FolderInfo>();
            foreach (var item in fileInfos)
            {
                var tmp = result.Find(f => f.Name == item.Performer);
                if (tmp == null)
                {
                    MP3FolderInfo newFolder = new MP3FolderInfo();
                    newFolder.Name = item.Performer;
                    newFolder.FileInfos.Add(item);
                    result.Add(newFolder);
                }
                else
                {
                    tmp.FileInfos.Add(item);
                }
            }
            return result;
        }
    }


}
