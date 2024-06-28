using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4
{
    internal class GetTypes
    {
        private Bitmap image;
        private string filePath;
        private string fileName;
  

        public GetTypes(string path)
        {
            filePath = path;
            if (path == "..")
            {
                image = new Bitmap(AssetLoader.Open(new Uri("avares://dz4/Assets/folderUp.png")));
                fileName = "..";
            }
            else
            {
                if (Directory.Exists(path))
                {
                   
                    image = new Bitmap(AssetLoader.Open(new Uri("avares://dz4/Assets/folder.png")));                
                    fileName = new DirectoryInfo(path).Name;
                }
                else
                {

                    image = new Bitmap(AssetLoader.Open(new Uri("avares://dz4/Assets/file.png")));
                    fileName = new FileInfo(path).Name;
                }
            }
        }
        public Bitmap ImagePath { get { return image; } }
        public string FilePath { get { return filePath; } }
        public string FileName { get { return fileName; } }

        
    }
}
