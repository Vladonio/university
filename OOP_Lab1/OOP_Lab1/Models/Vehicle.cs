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

        public Engine Engine
        {
            get { return engine; }
            set
            {
                engine = value;

                RaisePropertyChanged(nameof(Engine));
            }
        }

        private Tracks tracks;
        public Tracks Tracks
        {
            get { return tracks; }
            set
            {
                tracks = value;
                RaisePropertyChanged(nameof(Tracks));
            }
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
    }
}
