using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace dz8.Models
{
    abstract class Component
    {
        protected string name;
        public string Name { get { return name; } set { name = value; } }
        public ObservableCollection<Component> children = new ObservableCollection<Component>();
        public ObservableCollection<Component> Children { get { return children; } }
        public Component(string name)
        {
            this.name = name;
        }
        public Component() { }
        public abstract void Add(Component c);
    }
}
