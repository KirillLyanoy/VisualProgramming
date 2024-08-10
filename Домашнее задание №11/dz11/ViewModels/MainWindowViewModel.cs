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
        public string CurrentString { get; set; }
        public Company CurrentCompany { get; set; }
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
            CurrentString = "HelloKitty";


            CurrentCompany = new Company()
            {
                Name = "Johns Group",
                CatchPhrase = "Configurable multimedia task-force",
                Bs = "generate enterprise e-trailers"
            };
        }
    }
}
