using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4
{
    internal class GetDirectory
    {
        static private string _path = "C:\\";
        static public string[] allfiles = Directory.GetFiles(_path);
        static public string[] allfolders = Directory.GetDirectories(_path);
        static public void SetPath(string path) { _path = path; }
        static public string GetPath() { return _path; }

        static public void SetNewDirectory(string path)
        {
            allfolders = Directory.GetDirectories(path);
            allfiles = Directory.GetFiles(path);
        }
    }
}
