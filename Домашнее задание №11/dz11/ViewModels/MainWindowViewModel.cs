using dz11.Models;
using dz8.Models;
using System.Collections.ObjectModel;
using System.Reflection;
using System;

namespace dz11.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public User UserExample { get; set; }
        public string StringExample { get; set; }
        public int IntExample { get; set; }
        public bool BoolExample { get; set; }
        public double DoubleExample { get; set; }
        public Geo GeoExample { get; set; }
        public MainWindowViewModel() 
        {

            StringExample = "String Example";

            IntExample = 1234567890;

            BoolExample = false;

            DoubleExample = 1234.5678;

            GeoExample = new Geo()
            {
                Lat = "24.8918",
                Lng = "21.8984",
            };

            UserExample = new User()
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
    }
}
