using OOP_Lab1.Controls.Vehicles;
using OOP_Lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.EditorFactories
{
    public interface IVehicleEditorFactory
    {
        string vehicleName { get; }

        VehicleEditorControl CreateNewEditor(IList<Vehicle> vehicles, IList<Module> modules);

        VehicleEditorControl CreateEditor(Vehicle vehicle, IList<Module> modules);

        bool IsValidVehicle(Vehicle vehicle);
    }
}
