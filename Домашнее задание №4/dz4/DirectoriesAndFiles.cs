using Avalonia.Controls.Shapes;
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
        static DirectoriesAndFiles() { _path = Directory.GetCurrentDirectory(); }
        static public void SetPath(string path) { _path = path; }
        static public string GetPath() { return _path; }
        static public List<TypeFolder> GetLogicalDrives()
        {
            List<TypeFolder> logicalDrives = new List<TypeFolder> { };            
            foreach (string logicalDrive in Environment.GetLogicalDrives())
            {
                if (Directory.Exists(logicalDrive)) logicalDrives.Add(new TypeFolder(logicalDrive));
            }
            _path = "";
            return logicalDrives; 
        }
        static public TypeFolder[] GetTypeDirectories()
        {           
            TypeFolder[] typeFolders = new TypeFolder[Directory.GetDirectories(_path).Length + 1];            
            typeFolders[0] = new TypeFolder("..");
            int i = 1;
            foreach (string path in Directory.GetDirectories(_path))
            {
                typeFolders[i] = new TypeFolder(path);
                i++;
            }
            return typeFolders;
        }
        static public TypeFile[] GetTypeFiles()
        {            
            TypeFile[] typeFiles = new TypeFile[Directory.GetFiles(_path).Length];
            int i = 0;
            foreach (string path in Directory.GetFiles(_path))
            {
                typeFiles[i] = new TypeFile(path);
                i++;
            }
            return typeFiles;
        }
    }
}
