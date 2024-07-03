﻿using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.IO;

namespace dz5
{
    internal abstract class TypeWithImage //класс, определяющий картинку и имя объекта//
    {
        private Bitmap image;
        private string fileName;
        private string filePath;

        public TypeWithImage(string path)
        {
            filePath = path;
            if (path == "..")
            {
                image = new Bitmap(AssetLoader.Open(new Uri("avares://dz5/Assets/folderUp.png")));
                fileName = "..";
            } 
            else
            {
                if (Directory.Exists(path))
                {

                    image = new Bitmap(AssetLoader.Open(new Uri("avares://dz5/Assets/folder.png")));
                    fileName = new DirectoryInfo(path).Name;
                }
                else
                {

                    image = new Bitmap(AssetLoader.Open(new Uri("avares://dz5/Assets/file.png")));
                    fileName = new FileInfo(path).Name;
                }
            }
        }
        public Bitmap ImagePath { get { return image; } }
        public string FileName { get { return fileName; } }

        public string FilePath { get { return filePath; } }
    }
}
