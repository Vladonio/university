using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.Models
{
    public class Gun : Module, ICopied<Gun>
    {
        private double caliber;
        public double Caliber
        {
            get { return caliber; }
            set
            {
                caliber = value;
                RaisePropertyChanged(nameof(Caliber));
            }
        }

        private double rapidity;
        public double Rapidity
        {
            get { return rapidity; }
            set
            {
                rapidity = value;
                RaisePropertyChanged(nameof(Rapidity));
            }
        }

        public void CopyTo(Gun target)
        {
            base.CopyTo(target);

            target.Caliber = Caliber;
            target.Rapidity = Rapidity;

        }
    }
}
