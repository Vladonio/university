using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.Models
{
    [Serializable]
    public class Tower : Module, ICopied<Tower>
    {
        private int turningSpeed;
        public int TurningSpeed
        {
            get { return turningSpeed; }
            set
            {
                turningSpeed = value;
                RaisePropertyChanged(nameof(TurningSpeed));
            }
        }

        public void CopyTo(Tower target)
        {
            base.CopyTo(target);

            target.TurningSpeed = TurningSpeed;

        }

        public override string ToString()
        {
            return "Tower" + base.ToString() + $"tunringSpeed: {TurningSpeed}";
        }
    }

}
