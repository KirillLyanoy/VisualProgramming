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
        private object value;
        public object Value { get { return value; } set { this.value = value; } }

        private string propertyName;
        public string PropertyName { get { return propertyName; } set { propertyName = value; } }


        public Component(object value, string propertyName) 
        {
            this.value = value;
            this.propertyName = propertyName;
        }
        public abstract ObservableCollection<Component> Children { get; set; }
        public Component() { }
        public abstract void Add(Component c);
    }
}
