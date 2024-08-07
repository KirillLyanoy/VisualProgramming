﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dz5
{
    internal class GetDirectories
    {
        static private string _path = Environment.CurrentDirectory;
        static GetDirectories() { _path = Directory.GetCurrentDirectory(); }
        static public void SetPath(string path) { _path = path; }
        static public string GetPath() { return _path; }
        //получить список логических дисков//
        static public List<FolderWithImage> GetLogicalDrives()
        {
            List<FolderWithImage> logicalDrives = [];
            foreach (string logicalDrive in Environment.GetLogicalDrives())
            {
                if (Directory.Exists(logicalDrive)) logicalDrives.Add(new FolderWithImage(logicalDrive));
            }            
            return logicalDrives;
        }
        //получить массив папок//
        static public FolderWithImage[] GetCurrentDirectories(string path)
        {
            try
            {
                FolderWithImage[] folders = new FolderWithImage[Directory.GetDirectories(path).Length + 1];
                //первый элемент является будет переходить на родительскую директорию//
                folders[0] = new FolderWithImage("..");
                int i = 1;
                foreach (string getPath in Directory.GetDirectories(path))
                {
                    folders[i] = new FolderWithImage(getPath);
                    i++;
                }
                return folders;
            }
            catch (System.UnauthorizedAccessException) 
            {
                FolderWithImage[] folders = [new FolderWithImage("..")];
                return folders;
            }          
        }
        //получить массив файлов//       
        static public FileWithImage[] GetCurrentFiles(string path)
        {
            try
            {
                List<string> onlyImages = CreateOnlyImageList(path);
                FileWithImage[] files = new FileWithImage[onlyImages.Count];
                int i = 0;
                foreach (string getPath in onlyImages)
                {
                    files[i] = new FileWithImage(getPath);
                    i++;
                }
                return files;
            }
            catch (System.UnauthorizedAccessException)
            {
                FileWithImage[] files = [];
                return files;
            }
        }
        //получение изображений из всего списка файлов//
        static private List<string> CreateOnlyImageList(string path)
        {
            List<string> onlyImages = [];
            string[] formats = [".png", ".jpg", "jpeg"];
            foreach (var file in Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly).Where(x => formats.Any(x.EndsWith)))
            {
                onlyImages.Add(file);
            }
            return onlyImages;
        }
    }
}
