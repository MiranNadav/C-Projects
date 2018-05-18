using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    class GasMotorcycle : Motorcycle
    {
        private const Gas.eFuelType k_FuelType = Gas.eFuelType.Octan96;
        private const float k_MaximumFuelCapacity = 6.0f;

        public GasMotorcycle()
        {
            EnergySource = new Gas(k_FuelType, k_MaximumFuelCapacity);
        }

        public override string ToString()
        {
            return string.Format(
@"Vehicle type is: Gas Motorcycle 
{0}",
base.ToString());
        }
    }
}
