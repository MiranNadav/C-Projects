using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    class Electric : EnergySource
    {

        public Electric(float i_MaxAmountOfHours) : base(i_MaxAmountOfHours)
        {
            base.EnergyType = eEnergyTypes.Electric;
        }

        public void Charge(float i_AmountOfHoursToAdd)
        {
            base.FillEnergy(i_AmountOfHoursToAdd);
        }
    }
}
