using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz11.Models
{
    internal class Leaf : Component
    {
        public Leaf(string propertyName, object value) : base(propertyName, value) { }
        public Leaf() : base() { }
        public override ObservableCollection<Component> Children { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }
    }
}
