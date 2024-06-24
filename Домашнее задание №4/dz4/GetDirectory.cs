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
    internal class GetDirectory
    {
        static private string _path = "C:\\";
        static private string[] _allFiles = Directory.GetFiles(_path);
        static private string[] _allDirectories = Directory.GetDirectories(_path);



        static public void SetPath(string path) { _path = path; }
        static public string GetPath() { return _path; }
        static public string[] GetFiles() 
        {
            for (int i = 0; i < _allFiles.Length; i++) _allFiles[i] = Path.GetFileName(_allFiles[i]);
            return _allFiles;
        }
        static public string[] GetDirectories() 
        {
            for (int i = 0; i < _allDirectories.Length; i++) _allDirectories[i] = Path.GetFileName(_allDirectories[i]);
            return _allDirectories; 
        }
        static public void SetLogicalDrives()
        {
     //       _allDirectories = Environment.GetLogicalDrives();
        }
        static public void SetNewDirectory()
        {
            _allDirectories = Directory.GetDirectories(_path);
            _allFiles = Directory.GetFiles(_path);
        }
    }
}
