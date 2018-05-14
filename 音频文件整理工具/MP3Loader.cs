using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace 音频文件整理工具
{
    internal class MP3Loader
    {
        /// <summary>
        /// 从文件读取MP3FileInfo
        /// 文件不存在则返回null
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns>MP3FileInfo对象</returns>
        internal MP3FileInfo LoadFromFile(string filepath)
        {
            if (!File.Exists(filepath) || !filepath.ToLower().EndsWith(".mp3"))
            {
                return null;
            }
            var bytes = File.ReadAllBytes(filepath);
            MP3FileInfo mp3Info = new MP3FileInfo();
            mp3Info.FileName = Path.GetFileName(filepath);
            mp3Info.HaveID3 = checkID3(bytes);
            mp3Info.MD5 = makeMD5(bytes);
            if (mp3Info.HaveID3)
            {
                var tags = readFrames(bytes);
                foreach (var key in tags.Keys)
                {
                    switch (key)
                    {
                        case "TIT2":
                            mp3Info.Title = readFrameContent(tags[key]);
                            break;
                        case "TPE1":
                            mp3Info.Performer = readFrameContent(tags[key]);
                            break;
                        case "TALB":
                            mp3Info.Album = readFrameContent(tags[key]);
                            break;
                        case "TYER":
                            mp3Info.Year = readFrameContent(tags[key]);
                            break;
                        case "APIC":
                            mp3Info.Picture = readImage(tags[key]);
                            break;
                    }
                }
            }
            if (string.IsNullOrEmpty(mp3Info.Album))
            {
                mp3Info.Album = "未知";
            }
            if (string.IsNullOrEmpty(mp3Info.Performer))
            {
                mp3Info.Performer = "未知";
            }
            return mp3Info;
        }
        /// <summary>
        /// 检查ID3头
        /// </summary>
        /// <param name="fileBytes">文件内容</param>
        /// <returns>是否包含ID3头</returns>
        private bool checkID3(byte[] fileBytes)
        {
            if (Encoding.ASCII.GetString(fileBytes, 0, 3) == "ID3")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 读取数据帧
        /// </summary>
        /// <param name="fileBytes">文件内容</param>
        /// <returns>数据帧字典</returns>
        private Dictionary<string, byte[]> readFrames(byte[] fileBytes)
        {
            Dictionary<string, byte[]> result = new Dictionary<string, byte[]>();
            byte[] bytes = fileBytes.ToArray();
            long position = 10;
            while (true)
            {
                try
                {
                    List<byte> frameTypeBytes = new List<byte>() { bytes[position], bytes[position + 1], bytes[position + 2], bytes[position + 3] };
                    var frameType = Encoding.ASCII.GetString(frameTypeBytes.ToArray());
                    List<byte> frameSizeBytes = new List<byte>() { bytes[position + 4], bytes[position + 5], bytes[position + 6], bytes[position + 7] };
                    var frameSize = frameSizeBytes[0] * 0x100000000 + frameSizeBytes[1] * 0x10000 + frameSizeBytes[2] * 0x100 + frameSizeBytes[3];
                    var frameContent = new List<byte>();
                    for (long i = position + 10; i < (position + 10 + frameSize); i++)
                    {
                        frameContent.Add(bytes[i]);
                    }
                    position += (10 + frameSize);
                    if (frameType.Contains("\0"))
                    {
                        break;
                    }
                    result[frameType] = frameContent.ToArray();
                }
                catch (Exception exc)
                {
                    break;
                }
            }

            return result;
        }
        /// <summary>
        /// 读取文本帧文本
        /// </summary>
        /// <param name="content">文本帧内容</param>
        /// <returns>文本</returns>
        private string readFrameContent(byte[] content)
        {
            Encoding encoding = GetEncoding(content);
            return encoding.GetString(content, 1, content.Length - 1);
        }
        /// <summary>
        /// 读取图片帧的图片
        /// </summary>
        /// <param name="content">图片帧内容</param>
        /// <returns>图片对象</returns>
        private Image readImage(byte[] content)
        {

            List<byte> fileContent = new List<byte>(content);
            var start = fileContent.Find(c => c > 128 || c == 'B');
            fileContent = fileContent.Skip(fileContent.IndexOf(start)).ToList();
            try
            {
                MemoryStream ms = new MemoryStream(fileContent.ToArray());
                return Image.FromStream(ms);
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 计算MD5
        /// </summary>
        /// <param name="bytes">内容</param>
        /// <returns>内容的MD5</returns>
        private string makeMD5(byte[] bytes)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(bytes);
            return BitConverter.ToString(output).Replace("-", "").ToUpper();
        }
        /// <summary>
        /// 获取文本帧的编码
        /// </summary>
        /// <param name="bytes">文本帧内容</param>
        /// <returns>编码对象</returns>
        private Encoding GetEncoding(byte[] bytes)
        {
            switch (bytes[0])
            {
                case 0:
                    return Encoding.ASCII;
                case 1:
                    return Encoding.GetEncoding("UTF-16");
                case 2:
                    return Encoding.GetEncoding("UTF-16BE");
                case 3:
                    return Encoding.UTF8;
                default:
                    return Encoding.ASCII;
            }
        }
    }
}
