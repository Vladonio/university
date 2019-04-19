using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.ViewModels
{
    internal class AppViewModel
    {
        public VehiclesTabViewModel VehiclesTab { get; }

        public ModulesTabViewModel ModulesTab { get; }

        public AppViewModel()
        {
            ModulesTab = new ModulesTabViewModel();
            VehiclesTab = new VehiclesTabViewModel(ModulesTab.Modules);
        }
    }
}
