using dz8.Models;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
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
                ToTree(user, components);
            }
          
        }
        private void ToTree<T>(T data, ObservableCollection<Component> collection)
        {          
            Type type = typeof(T);
            PropertyInfo[] propertyes = type.GetProperties();
            object[] arrObj = new object[propertyes.Length];
            foreach (PropertyInfo property in propertyes)
            {
                if (property.GetValue(data) is int || property.GetValue(data) is string)
                {
                    collection.Add(new Leaf(Convert.ToString(property.GetValue(data))));
                }
                else
                {
                    //collection.Add(new Composite(Convert.ToString(property.GetValue(data))));
                    Component component = new Composite(Convert.ToString(property.GetValue(data)));
                    ToTree(data, component.Children);
                    collection.Add((Component)component);
                }
            }        
        }
        public override string GetName()
        {
            return "Tree";
        }
    }
}
