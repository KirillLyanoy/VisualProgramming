﻿using System.Collections.ObjectModel;

namespace dz8.Models
{
    abstract class Component
    {
        protected string name;
        public string Name { get { return name; } set { name = value; } }
        public Component(string name) { this.name = name; }
        public abstract ObservableCollection<Component> Children { get; set; } 
        public Component() { }
        public abstract void Add(Component c);
    }
}
