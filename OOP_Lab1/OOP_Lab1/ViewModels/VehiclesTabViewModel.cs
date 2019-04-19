using OOP_Lab1.Controls.Vehicles;
using OOP_Lab1.EditorFactories;
using OOP_Lab1.Models;
using OOP_Lab1.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace OOP_Lab1.ViewModels
{
    internal class VehiclesTabViewModel
    {
        public ObservableCollection<Vehicle> Vehicles { get; }


        public IVehicleEditorFactory SelectedFactory { get; set; }

        public List<IVehicleEditorFactory> VehicleEditorFactories { get; }

        public ICommand OpenNewVehicleEditor { get; }


        public Vehicle SelectedVehicle { get; set; }

        public ICommand OpenVehicleEditor { get; }

        public ICommand DeleteVehicle { get; }
        
        public IList<Module> Modules { get; }

        public VehiclesTabViewModel(IList<Module> modules)
        {
            Vehicles = new ObservableCollection<Vehicle>();

            Modules = modules;
            OpenNewVehicleEditor = new OpenNewVehicleEditorCommand(this);
            OpenVehicleEditor = new OpenEditorCommand(this);
            DeleteVehicle = new DeleteVehicleCommand(this);

            VehicleEditorFactories = new List<IVehicleEditorFactory>()
            {
                new CivilianVehicleEditorFactory(),
                new TankDestroyerEditorFactory(),
                new TowerTankEditorFactory(),
            };
        }

        private class OpenNewVehicleEditorCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private VehiclesTabViewModel vehiclesTab;

            public OpenNewVehicleEditorCommand(VehiclesTabViewModel vehiclesTab)
            {
                this.vehiclesTab = vehiclesTab;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                VehicleEditorControl editor = vehiclesTab.SelectedFactory.CreateNewEditor(vehiclesTab.Vehicles, vehiclesTab.Modules);

                VehiclesEditor editorWindow = new VehiclesEditor(editor);

                editor.AddOnSaveAction(() => editorWindow.Close());

                editorWindow.ShowDialog();
            }
        }

        private class OpenEditorCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private VehiclesTabViewModel vehiclesTab;

            public OpenEditorCommand(VehiclesTabViewModel vehiclesTab)
            {
                this.vehiclesTab = vehiclesTab;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                try
                {
                    VehicleEditorControl editor = vehiclesTab.VehicleEditorFactories.First(f => f.IsValidVehicle(vehiclesTab.SelectedVehicle))
                        .CreateEditor(vehiclesTab.SelectedVehicle, vehiclesTab.Modules);

                    VehiclesEditor editorWindow = new VehiclesEditor(editor);

                    editor.AddOnSaveAction(() => editorWindow.Close());

                    editorWindow.ShowDialog();
                }
                catch { }
            }
        }

        private class DeleteVehicleCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private VehiclesTabViewModel vehiclesTab;

            public DeleteVehicleCommand(VehiclesTabViewModel vehiclesTab)
            {
                this.vehiclesTab = vehiclesTab;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                vehiclesTab.Vehicles.Remove(vehiclesTab.SelectedVehicle);
            }
        }
    }
}
