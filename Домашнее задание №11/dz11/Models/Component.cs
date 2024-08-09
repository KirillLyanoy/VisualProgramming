using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz11.Models
{
    abstract class Component
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        public Component(string name) { this.name = name; }
        public abstract ObservableCollection<Component> Children { get; set; }
        public Component() { }
        public abstract void Add(Component c);
    }
}
