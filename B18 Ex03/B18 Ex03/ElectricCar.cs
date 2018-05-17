using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex03
{
    class ElectricCar : Car
    {
        private float m_TimeLeftOnBattary;
        private const float k_MaximumChargeTimeOfBattery = 3.2f;

        public ElectricCar()
        {
            this.m_TimeLeftOnBattary = 0f;
            base.EnergySource = new Electric(k_MaximumChargeTimeOfBattery);
        }
<<<<<<< HEAD
=======

        //public void ChargeBattery(float i_NumberOfHoursToAdd)
        //{
        //    try
        //    {
        //        base.EnergySource.FillEnergy(i_NumberOfHoursToAdd);
        //    }
        //    catch (ValueOutOfRangeException e)
        //    {
        //        throw new ValueOutOfRangeException(e.MinValue, e.MaxValue, "Amount to charge is above battery capacity.");
        //    }

        //    base.EnergyPercentge = (EnergySource.CurrentEnergyAmount / k_MaximumChargeTimeOfBattery) * 100;
        //}
        public override string ToString()
        {
            return string.Format(
@"Vehicle type is: Electric Car
{0}",
base.ToString());
        }
>>>>>>> 09289497c9878e8744405a802a553e759c1cfea2
    }
}
