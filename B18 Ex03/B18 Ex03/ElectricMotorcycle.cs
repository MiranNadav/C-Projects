using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaximumChargeTimeOfBattery = 1.8f;

        public ElectricMotorcycle()
        {
            base.EnergySource = new Electric(k_MaximumChargeTimeOfBattery);
        }

        //public void ChargeBattery(float i_NumberOfHoursToAdd)
        //{
        //    try
        //    {
        //        base.EnergySource.FillEnergy(i_NumberOfHoursToAdd);
        //    }
        //    catch (ValueOutOfRangeException e)
        //    {
        //        throw new ValueOutOfRangeException(e.MinValue, e.MaxValue, "Amount to rechange is above battery capacity.");
        //    }

        //    base.EnergyPercentge = (EnergySource.CurrentEnergyAmount / k_MaximumChargeTimeOfBattery) * 100;
        //}
    }
}
