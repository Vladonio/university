using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.Models
{
    public abstract class Vehicle : INotifyPropertyChanged
    {
        private Engine engine;

        public string Description => ToString();

        public Engine Engine
        {
            get { return engine; }
            set
            {
                engine = value;

                RaisePropertyChanged(nameof(Engine));

                engine.PropertyChanged += Engine_PropertyChanged;
            }
        }

        private void Engine_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(Description));
        }

        private Tracks tracks;
        public Tracks Tracks
        {
            get { return tracks; }
            set
            {
                tracks = value;
                RaisePropertyChanged(nameof(Tracks));

                tracks.PropertyChanged += Tracks_PropertyChanged;
            }
        }

        private void Tracks_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(Description));
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        private string weight;
        public string Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                RaisePropertyChanged(nameof(Weight));
            }
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                RaisePropertyChanged(nameof(Price));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Vehicle()
        {
            PropertyChanged += Vehicle_PropertyChanged;
        }

        private void Vehicle_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Description))
            {
                return;
            }

            RaisePropertyChanged(nameof(Description));
        }

        protected void CopyTo(Vehicle target)
        {
            target.Engine = Engine;
            target.Tracks = Tracks;
            target.Name = Name;
            target.Weight = Weight;
            target.Price = Price;
        }

        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public override string ToString()
        {
            return $"Name: {Name} Weight: {Weight} Price: {Price} Engine: {Engine?.Name} Tracks: {Tracks?.Name} ";
        }
    }
}
