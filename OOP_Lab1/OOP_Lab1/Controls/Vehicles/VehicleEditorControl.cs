using OOP_Lab1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

namespace OOP_Lab1.Controls.Vehicles
{
    public class VehicleEditorControl : UserControl, INotifyPropertyChanged
    {
        private IList<Module> modules;
        private IList<Engine> engines;
        private IList<Tracks> tracks;
        private IList<Gun> guns;
        private IList<Tower> towers;

        public IList<Tracks> Tracks
        {
            get { return tracks; }
            set
            {
                tracks = value;
                RaisePropertyChanged(nameof(Tracks));
            }
        }

        public IList<Engine> Engines
        {
            get { return engines; }
            set
            {
                engines = value;
                RaisePropertyChanged(nameof(Engines));
            }
        }

        public IList<Gun> Guns
        {
            get { return guns; }
            set
            {
                guns = value;
                RaisePropertyChanged(nameof(Guns));
            }
        }

        public IList<Tower> Towers
        {
            get { return towers; }
            set
            {
                towers = value;
                RaisePropertyChanged(nameof(Towers));
            }
        }

        public IList<Module> Modules
        {
            get { return modules; }
            set
            {
                modules = value;

                Engines = Modules.OfType<Engine>().ToList();
                Tracks = Modules.OfType<Tracks>().ToList();
                Guns = Modules.OfType<Gun>().ToList();
                Towers = Modules.OfType<Tower>().ToList();
            }
        }

        protected Action actions = () => { };

        public event PropertyChangedEventHandler PropertyChanged;

        public VehicleEditorControl()
        {
            Modules = new List<Module>();
        }

        public void AddOnSaveAction(Action action)
        {
            actions += action;
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
