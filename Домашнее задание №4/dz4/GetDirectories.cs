﻿using System;
using System.Collections.Generic;
using System.IO;

namespace dz4
{
    internal class GetDirectories
    {   
        static private string _path;
        static GetDirectories() { _path = Directory.GetCurrentDirectory(); }
        static public void SetPath(string path) { _path = path; }
        static public string GetPath() { return _path; }
        //получить список логических дисков//
        static public List<FolderWithImage> GetLogicalDrives() 
        {
            List<FolderWithImage> logicalDrives = new List<FolderWithImage> { };            
            foreach (string logicalDrive in Environment.GetLogicalDrives())
            {                
                if (Directory.Exists(logicalDrive)) logicalDrives.Add(new FolderWithImage(logicalDrive));
            }
            _path = "";
            return logicalDrives; 
        }
        //получить массив папок//
        static public FolderWithImage[] GetCurrentDirectories()
        {
            try
            {
                FolderWithImage[] folders = new FolderWithImage[Directory.GetDirectories(_path).Length + 1];
                //первый элемент является будет переходить на родительскую директорию//
                folders[0] = new FolderWithImage("..");
                int i = 1;
                foreach (string path in Directory.GetDirectories(_path))
                {
                    folders[i] = new FolderWithImage(path);
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
        static public FileWithImage[] GetCurrentFiles()
        {
            try
            {
                FileWithImage[] files = new FileWithImage[Directory.GetFiles(_path).Length];
                int i = 0;
                foreach (string path in Directory.GetFiles(_path))
                {
                    files[i] = new FileWithImage(path);
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
    }
}
