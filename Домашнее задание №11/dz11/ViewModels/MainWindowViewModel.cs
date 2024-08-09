using dz11.Models;
using dz8.Models;
using System.Collections.ObjectModel;
using System.Reflection;
using System;

namespace dz11.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public User CurrentUser { get; set; }
        public MainWindowViewModel() 
        {
            CurrentUser = new User()
            {
                Id = 7,
                Name = "Kurtis Weissnat",
                Username = "Elwyn.Skiles",
                Email = "Telly.Hoeger@billy.biz",
                Address = new Address()
                {
                    Street = "Rex Trail",
                    Suite = "Suite 280",
                    City = "HoweMouth",
                    Zipcode = "58804-1099",
                    Geo = new Geo()
                    {
                        Lat = "24.8918",
                        Lng = "21.8984",
                    }
                },
                Phone = "210.067.6132",
                Website = "elvis.io",
                Company = new Company()
                {
                    Name = "Johns Group",
                    CatchPhrase = "Configurable multimedia task-force",
                    Bs = "generate enterprise e-trailers"
                }
            };
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
    }
}
