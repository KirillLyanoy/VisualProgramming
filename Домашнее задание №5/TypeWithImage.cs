using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.IO;

namespace dz5
{
    internal abstract class TypeWithImage //класс, определяющий картинку и имя объекта//
    {
        private Bitmap _image;
        private string _Name;
        private string _Path;
        private string _type;

        public Bitmap ImagePath { get { return _image; } }
        public string Name { get { return _Name; } }
        public string Path { get { return _Path; } set { _Path = value; } }
        public string Type { get { return _type; } }

        public TypeWithImage(string path)
        {
            _Path = path;
            if (path == "..")
            {
                _type = "folderUp";
                _image = new Bitmap(AssetLoader.Open(new Uri("avares://dz5/Assets/folderUp.png")));
                _Name = "..";
            } 
            else
            {
                if (Directory.Exists(path))
                {
                    _type = "folder";
                    _image = new Bitmap(AssetLoader.Open(new Uri("avares://dz5/Assets/folder.png")));
                    _Name = new DirectoryInfo(path).Name;
                }
                else
                {
                    _type = "file";
                    _image = new Bitmap(AssetLoader.Open(new Uri("avares://dz5/Assets/file.png")));
                    _Name = new FileInfo(path).Name;
                }
            }
        }
    }
}
