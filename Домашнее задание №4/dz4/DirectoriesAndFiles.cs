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
    internal class DirectoriesAndFiles
    {   
        static private string _path;
        static DirectoriesAndFiles()
        {
            _path = Directory.GetCurrentDirectory();
        }
        static public void SetPath(string path) { _path = path; }
        static public string GetPath() { return _path; }
        static public DirectoryInfo[] GetLogicalDrives()
        {
            DirectoryInfo[] directoryInfo = new DirectoryInfo[Environment.GetLogicalDrives().Length];
            int i = 0;
            foreach (string logicalDrive in Environment.GetLogicalDrives())
            {
                directoryInfo[i] = new DirectoryInfo(logicalDrive);
                i++;
            }
            return directoryInfo; 
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
        static public DirectoryInfo[] GetDirectoryUp()
        {
            DirectoryInfo[] directoryInfo = new DirectoryInfo[1];
            directoryInfo[0] = new DirectoryInfo("..");
            return directoryInfo;
        }
    }
}
