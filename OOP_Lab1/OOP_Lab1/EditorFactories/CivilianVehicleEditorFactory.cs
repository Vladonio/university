using OOP_Lab1.Controls.Vehicles;
using OOP_Lab1.EditCommands;
using OOP_Lab1.Models;
using System;
using System.Collections.Generic;

namespace OOP_Lab1.EditorFactories
{
    class CivilianVehicleEditorFactory : IVehicleEditorFactory
    {
        public string vehicleName => "Civilian Vehicle";

        public VehicleEditorControl CreateEditor(Vehicle vehicle, IList<Module> modules)
        {
            if (!IsValidVehicle(vehicle))
            {
                throw new ArgumentException("Invalid vehicle");
            }

            var editor = new CivilianVehicleEditor();

            editor.Modules = modules;

            CivilianVehicle targetCivilianVehicle = vehicle as CivilianVehicle;

            editor.CivilianVehicle = targetCivilianVehicle;
            editor.SaveCommand = new SaveEdittedVehicleCommand<CivilianVehicle>(targetCivilianVehicle, editor.ModifiedCivilianVehicle);

            return editor;
        }

        public VehicleEditorControl CreateNewEditor(IList<Vehicle> vehicles, IList<Module> modules)
        {
            var editor = new CivilianVehicleEditor();

            editor.Modules = modules;

            editor.SaveCommand = new AddNewVehicleCommand(vehicles, editor.ModifiedCivilianVehicle);

            return editor;
        }

        public bool IsValidVehicle(Vehicle vehicle)
        {
            return vehicle.GetType() == typeof(CivilianVehicle);
        }
    }
}
