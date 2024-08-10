using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz11.Models
{
    internal class Composite : Component
    {
        public ObservableCollection<Component> children = [];
        public override ObservableCollection<Component> Children { get { return children; } set { children = value; } }

   

        public Composite(string propertyName, object value) : base(propertyName, value) { }
        public Composite() : base() { }

        public override void Add(Component component)
        {
            children.Add(component);
        }
    }
}
