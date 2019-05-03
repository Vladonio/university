using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.Models
{
    public class TowerTank : BattleVehicle, ICopied<TowerTank>
    {
        private Tower tower;
        public Tower Tower
        {
            get
            {
                return tower;
            }
            set
            {
                tower = value;

                RaisePropertyChanged(nameof(Tower));
                tower.PropertyChanged += Tower_PropertyChanged;
            }
        }

        private void Tower_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(Description));
        }

        public void CopyTo(TowerTank target)
        {
            base.CopyTo(target);

            target.Tower = Tower;

        }

        public override string ToString()
        {
            return base.ToString() + $"tower: {Tower?.Name}";
        }
    }
}
