using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.Models
{
    [Serializable]
    public class Tracks : Module, ICopied<Tracks>
    {
        private int weightCapacity;
        public int WeightCapacity
        {
            get { return weightCapacity; }
            set
            {
                weightCapacity = value;
                RaisePropertyChanged(nameof(WeightCapacity));
            }
        }

        public void CopyTo(Tracks target)
        {
            base.CopyTo(target);

            target.WeightCapacity = WeightCapacity;

        }

        public override string ToString()
        {
            return "Tracks" + base.ToString() + $"weightCapacity: {WeightCapacity}";
        }
    }
}
