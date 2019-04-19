using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.Models
{
    public class TowerTank : BattleVehicle, ICopied<TowerTank>
    {
        public Tower Tower { get; set; }

        public void CopyTo(TowerTank target)
        {
            base.CopyTo(target);

            target.Tower = Tower;

        }
    }
}
