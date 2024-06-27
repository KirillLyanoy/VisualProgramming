using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace dz4
{
    internal class Path
    {   
        static private string _path;
        static Path()
        {
            _path = Directory.GetCurrentDirectory();
        }
        static public void SetPath(string path) { _path = path; }
        static public string GetPath() { return _path; }
        static public void SetLogicalDrives()
        {
     //       _allDirectories = Environment.GetLogicalDrives();
        }
        static public DirectoryInfo[] GetTypeDirectories()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(_path);
            return directoryInfo.GetDirectories();
        }
        static public FileInfo[] GetTypeFiles()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(_path);
            return directoryInfo.GetFiles();
        }
    }
}
