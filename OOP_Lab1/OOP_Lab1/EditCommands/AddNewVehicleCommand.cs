using OOP_Lab1.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace OOP_Lab1.EditCommands
{
    public class AddNewVehicleCommand : ICommand
    {
        private IList<Vehicle> vehicles;
        private Vehicle newVehicle;

        public event EventHandler CanExecuteChanged;

        public AddNewVehicleCommand(IList<Vehicle> vehicles, Vehicle vehicle)
        {
            newVehicle = vehicle;
            this.vehicles = vehicles;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vehicles.Add(newVehicle);
        }
    }
}
