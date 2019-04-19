using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Lab1.ViewModels;

namespace OOP_Lab1.Models
{
    public class Engine : Module, ICopied<Engine>
    {
        private int power;
        public int Power
        {
            get { return power; }
            set
            {
                power = value;
                RaisePropertyChanged(nameof(Power));
            }
        }

        public void CopyTo(Engine target)
        {
            base.CopyTo(target);

            target.Power = Power;          
            
        }
    }
}
