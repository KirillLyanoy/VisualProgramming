using System.Collections.ObjectModel;

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
