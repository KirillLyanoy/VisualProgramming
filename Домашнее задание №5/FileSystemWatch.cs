using System;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace dz5
{
    internal class FileSystemWatch
    {
        static private FileSystemWatcher watcher = new FileSystemWatcher(GetDirectories.GetPath());
      
        
        static public FileSystemWatch()
        {
            watcher.NotifyFilter = NotifyFilters.Attributes
                               | NotifyFilters.DirectoryName
                               | NotifyFilters.FileName;
           
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;         

            watcher.Filter = "*.png";            
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
        }
        
        static public void SetWatcherPath(string path)
        {
            watcher = new FileSystemWatcher(path);
        }
        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            DataContextWithCollection dataContextWithCollection = new DataContextWithCollection();
            string value = $"Created: {e.FullPath}";
            dataContextWithCollection.Collection.Add(new FileWithImage(value));
        }
        private static void OnDeleted(object sender, FileSystemEventArgs e) =>
            Console.WriteLine($"Deleted: {e.FullPath}");

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Renamed:");
            Console.WriteLine($"    Old: {e.OldFullPath}");
            Console.WriteLine($"    New: {e.FullPath}");
        }
    }
}
