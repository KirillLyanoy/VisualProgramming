using dz8.Models;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
namespace dz8.ViewModels.Pages
{
    internal class TreeViewModel : BasePageViewModel
    {
        public TreeViewModel()
        {
            GetUsers();
        }  
        private ObservableCollection<Component> components = new ObservableCollection<Component>();
        public ObservableCollection<Component> Components { get { return components; } }
        public override async void GetUsers()
        {
            GetHttpUsersService users = new();
            UsersList = new ObservableCollection<User>(await users.GetUsersList());
            foreach (var user in UsersList) 
            {
                ConvertToTree(user, components);                
            }  
            RenameTitle(components);
        }
        private void ConvertToTree<T>(T data, ObservableCollection<Component> collection)
        {      
            Type type = data.GetType();
            Composite composite = new Composite(Convert.ToString(type.Name));
            PropertyInfo[] propertyes = type.GetProperties();
            object[] arrObj = new object[propertyes.Length];
            foreach (PropertyInfo property in propertyes)
            {
                if (property.GetValue(data) is int || property.GetValue(data) is string)
                {
                    composite.Add(new Leaf(Convert.ToString(property.Name) + ":\t" + Convert.ToString(property.GetValue(data))));
                }
                else
                {                    
                    ConvertToTree(property.GetValue(data), composite.Children);
                }
            }
            collection.Add(composite);  
        }

        private void RenameTitle(ObservableCollection<Component> components)
        {
            foreach (var component in components)
            {
                component.Name = Convert.ToString(component.Children[0].Name);
            }
        }
        public override string GetName()
        {
            return "Tree";
        }
    }
}
