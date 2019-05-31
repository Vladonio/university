using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.Models
{
    [Serializable]
    public class TankDestroyer : BattleVehicle, ICopied<TankDestroyer>
    {
        private int gunArc;
        public int GunArc
        {
            get { return gunArc; }
            set
            {
                gunArc = value;
                RaisePropertyChanged(nameof(GunArc));
            }
        }

        public void CopyTo(TankDestroyer target)
        {
            base.CopyTo(target);

            target.GunArc = GunArc;

        }

        public override string ToString()
        {
            return base.ToString() + $"gunArc: {GunArc}";
        }
    }
}
