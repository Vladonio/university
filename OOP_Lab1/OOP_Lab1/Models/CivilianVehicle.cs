using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.Models
{
    public class CivilianVehicle : Vehicle, ICopied<CivilianVehicle>
    {
        private int seatsCount;


        public int SeatsCount
        {
            get { return seatsCount; }
            set
            {
                seatsCount = value;
                RaisePropertyChanged(nameof(SeatsCount));
            }
        }

        public void CopyTo(CivilianVehicle target)
        {
            base.CopyTo(target);

            target.SeatsCount = SeatsCount;
        }

        public override string ToString()
        {
            return base.ToString() + $"seatsCount: {seatsCount}";
        }
    }
}
