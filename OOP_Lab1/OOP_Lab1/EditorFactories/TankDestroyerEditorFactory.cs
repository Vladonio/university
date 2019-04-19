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
    class TankDestroyerEditorFactory : IVehicleEditorFactory
    {
        public string vehicleName => "Tank Destroyer";

        public VehicleEditorControl CreateEditor(Vehicle vehicle, IList<Module> modules)
        {
            if (!IsValidVehicle(vehicle))
            {
                throw new ArgumentException("Invalid vehicle");
            }

            var editor = new TankDestroyerEditor();

            editor.Modules = modules;

            TankDestroyer targetTankDestroyer = vehicle as TankDestroyer;

            editor.TankDestroyer = targetTankDestroyer;
            editor.SaveCommand = new SaveEdittedVehicleCommand<TankDestroyer>(targetTankDestroyer, editor.ModifiedTankDestroyer);

            return editor;
        }

        public VehicleEditorControl CreateNewEditor(IList<Vehicle> vehicles, IList<Module> modules)
        {
            var editor = new TankDestroyerEditor();

            editor.Modules = modules;

            editor.SaveCommand = new AddNewVehicleCommand(vehicles, editor.ModifiedTankDestroyer);

            return editor;
        }

        public bool IsValidVehicle(Vehicle vehicle)
        {
            return vehicle.GetType() == typeof(TankDestroyer);
        }
    }
}
