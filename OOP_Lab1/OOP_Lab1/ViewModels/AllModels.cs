using OOP_Lab1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.ViewModels
{
    [Serializable]
    public class AllModels
    {
        public ObservableCollection<Module> MyModules { get; set; }

        public ObservableCollection<Vehicle> MyVehicles { get; set; }

        public AllModels(ObservableCollection<Module> modules, ObservableCollection<Vehicle> vehicles)
        {
            this.MyModules = modules;
            this.MyVehicles = vehicles;
        }

        public AllModels()
        {

        }
    }
}
