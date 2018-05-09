using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    class Electric : EnergySource
    {
        //private float m_CurrentAmountOfHoursLeft;
        //private float m_MaxAmountOfGas;

        public Electric(float i_CurrentAmountOfHours, float i_MaxAmountOfHours) : base(i_CurrentAmountOfHours, i_MaxAmountOfHours){ }
        

        public void Charge(float i_AmountOfHoursToAdd)
        {
            base.FillEnergy(i_AmountOfHoursToAdd);
        }
    }
}
