using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.Models
{
    public abstract class BattleVehicle : Vehicle
    {
        private Gun gun;
        public Gun Gun
        {
            get { return gun; }
            set
            {
                gun = value;
                RaisePropertyChanged(nameof(Gun));
            }
        }

        public void CopyTo(BattleVehicle target)
        {
            base.CopyTo(target);

            target.Gun = Gun;

        }
    }
}
