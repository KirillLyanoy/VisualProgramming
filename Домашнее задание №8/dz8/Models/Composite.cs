using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz8.Models
{
    internal class Composite : Component
    {
        public ObservableCollection<Component> children = new ObservableCollection<Component>();
        public override ObservableCollection<Component> Children { get { return children; } set { children = value; } }

        

        public Composite(string name) : base(name) { }
        public Composite() : base() { }
        public override void Add(Component component)
        {
            children.Add(component);
        }
    }

}
