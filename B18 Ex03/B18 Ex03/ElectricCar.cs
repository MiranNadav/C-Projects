using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex03
{
    class ElectricCar : Car
    {
        private const float k_MaximumChargeTimeOfBattery = 3.2f;

        public ElectricCar()
        {
            base.EnergySource = new Electric(k_MaximumChargeTimeOfBattery);
        }
        public override string ToString()
        {
            return string.Format(
@"Vehicle type is: Electric Car
{0}",
base.ToString());
        }
    }
}
