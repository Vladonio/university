using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.Models
{
   public abstract class Module : INotifyPropertyChanged
    {
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

        private string vulnerability;
        public string Vulnerability
        {
            get { return vulnerability; }
            set
            {
                vulnerability = value;
                RaisePropertyChanged(nameof(Vulnerability));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void CopyTo(Module target)
        {
            target.Name = Name;
            target.Vulnerability = Vulnerability;
        }

        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
