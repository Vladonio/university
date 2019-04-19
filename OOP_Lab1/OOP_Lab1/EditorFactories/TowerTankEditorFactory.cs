using OOP_Lab1.Controls.Vehicles;
using OOP_Lab1.EditCommands;
using OOP_Lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.EditorFactories
{
    class TowerTankEditorFactory : IVehicleEditorFactory
    {
        public string vehicleName => "Tower Tank";

        public VehicleEditorControl CreateEditor(Vehicle vehicle, IList<Module> modules)
        {
            if (!IsValidVehicle(vehicle))
            {
                throw new ArgumentException("Invalid vehicle");
            }

            var editor = new TowerTankEditor();

            editor.Modules = modules;

            TowerTank targetTowerTank = vehicle as TowerTank;

            editor.TowerTank = targetTowerTank;
            editor.SaveCommand = new SaveEdittedVehicleCommand<TowerTank>(targetTowerTank, editor.ModifiedTowerTank);

            return editor;
        }

        public VehicleEditorControl CreateNewEditor(IList<Vehicle> vehicles, IList<Module> modules)
        {
            var editor = new TowerTankEditor();

            editor.Modules = modules;

            editor.SaveCommand = new AddNewVehicleCommand(vehicles, editor.ModifiedTowerTank);

            return editor;
        }

        public bool IsValidVehicle(Vehicle vehicle)
        {
            return vehicle.GetType() == typeof(TowerTank);
        }
    }
}
