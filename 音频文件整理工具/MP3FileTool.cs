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

        internal MP3FileInfo[] RenameAllFile(MP3FileInfo[] files, RenameFormat format)
        {
            foreach (var item in files)
            {
                item.FileName = item.FormatFileName(format);
            }
            return files;
        }

        internal MP3FileInfo[] GetFileByAlbum(string album)
        {
            return fileInfos.FindAll(f => f.Album == album).ToArray();
        }

        internal MP3FileInfo[] GetFileByPerformer(string performer)
        {
            return fileInfos.FindAll(f => f.Performer == performer).ToArray();
        }

        internal MP3FolderInfo[] FolderByAlbum(MP3FileInfo[] files)
        {
            List<MP3FolderInfo> result = new List<MP3FolderInfo>();
            foreach (var item in files)
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
            return result.ToArray();
        }

        internal MP3FolderInfo[] FolderByPerformer(MP3FileInfo[] files)
        {
            List<MP3FolderInfo> result = new List<MP3FolderInfo>();
            foreach (var item in files)
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
            return result.ToArray();
        }

        internal bool SaveToFolder(string targetPath, MP3FileInfo[] files)
        {
            if (!Directory.Exists(targetPath))
            {
                return false;
            }

            foreach (var item in files)
            {
                try
                {
                    File.Copy(item.FilePath, Path.Combine(targetPath, item.FileName), true);
                }
                catch (Exception exc)
                {
                    System.Windows.Forms.MessageBox.Show(exc.Message, "保存出错");
                    return false;
                }
            }
            return true;
        }

        internal bool SaveToFolder(string targetPath, MP3FolderInfo[] folders)
        {
            if (!Directory.Exists(targetPath))
            {
                return false;
            }
            foreach (var folder in folders)
            {
                var files = folder.FileInfos;
                if (files.Count > 0)
                {
                    Directory.CreateDirectory(Path.Combine(targetPath, folder.Name));
                }
                foreach (var item in files)
                {
                    try
                    {
                        File.Copy(item.FilePath, Path.Combine(targetPath, folder.Name, item.FileName), true);
                    }
                    catch (Exception exc)
                    {
                        System.Windows.Forms.MessageBox.Show(exc.Message, "保存出错");
                        return false;
                    }
                }
            }
            return true;
        }
    }


}
