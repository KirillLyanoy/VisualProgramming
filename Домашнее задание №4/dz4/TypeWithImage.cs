using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.IO;

namespace dz4
{
    internal abstract class TypeWithImage //класс, определяющий картинку, путь и имя объекта//
    {
        private Bitmap image; 
        private string fileName; 

        public TypeWithImage(string path)
        {           
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
        public string FileName { get { return fileName; } }        
    }
}
