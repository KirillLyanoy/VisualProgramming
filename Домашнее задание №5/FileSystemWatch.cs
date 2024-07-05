using System.IO;

namespace dz5
{
    internal class FileSystemWatch
    {
        static private FileSystemWatcher watcher;

        static FileSystemWatch()
        {
            CreateNewFileSystemWatcher(GetDirectories.GetPath());
        }    

        public static void CreateNewFileSystemWatcher(string path)
        {           
            if (path != "") watcher = new FileSystemWatcher(path);
         
            watcher.NotifyFilter = NotifyFilters.Attributes
                              | NotifyFilters.DirectoryName
                              | NotifyFilters.FileName;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;
            try
            {
                watcher.EnableRaisingEvents = true;
            }
            catch (System.IO.FileNotFoundException)
            {
                watcher.EnableRaisingEvents = false;
            }
                           
        }
        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"{e.FullPath}";
            if (Directory.Exists(value))
            {
                DataContextWithCollection dataContextWithCollection = new DataContextWithCollection();
                dataContextWithCollection.Collection.Add(new FolderWithImage(value));
            }
            else if (CheckExtension(value))
            {
                DataContextWithCollection dataContextWithCollection = new DataContextWithCollection();
                dataContextWithCollection.Collection.Add(new FileWithImage(value));
            }            
        }
        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            string value = $"{e.FullPath}";

            DataContextWithCollection dataContextWithCollection = new DataContextWithCollection();
            foreach (var item in dataContextWithCollection.Collection)
            {
                if (item.Path == value)
                {
                    dataContextWithCollection.Collection.Remove(item);
                    return;
                }
            }
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            string oldPath = ($"{e.OldFullPath}");
            string newName = ($"{e.FullPath}");

            DataContextWithCollection dataContextWithCollection = new DataContextWithCollection();
            foreach (var item in dataContextWithCollection.Collection)
            {
                if (item.Path == oldPath)
                {
                    int index = dataContextWithCollection.Collection.IndexOf(item);
                    if (Directory.Exists(item.Path))
                    {
                        dataContextWithCollection.Collection.Remove(item);
                        dataContextWithCollection.Collection.Insert(index, new FolderWithImage(newName));
                    }
                    else
                    {
                        dataContextWithCollection.Collection.Remove(item);
                        dataContextWithCollection.Collection.Insert(index, new FileWithImage(newName));
                    }
                    return;
                }
            }
        }

        private static bool CheckExtension(string path) 
        {
            return (path.EndsWith(".png") || path.EndsWith(".jpg") || path.EndsWith(".jpeg"));
        }        
    }
}
