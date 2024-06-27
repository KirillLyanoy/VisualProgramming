using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4
{
    // Класс, который нужен для элемента перехода вверх по директории: ".."//
    internal class DirectoryInfoUp: FileSystemInfo
    {
        public override void Delete() { }
        public override bool Exists { get; }
        public override string Name { get; }
    }
}
