using System;
using System.Collections.ObjectModel;

namespace dz8.Models{
    internal class Leaf : Component
    {
        public Leaf(string name) : base(name) { }
        public Leaf() : base() { }
        public override ObservableCollection<Component> Children { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }
    }
}
