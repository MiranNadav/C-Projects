using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    class GasMotorcycle : Motorcycle
    {
        private const Gas.FuelType k_FuelType = Gas.FuelType.Octan96;
        private const float k_MaximumFuelCapacity = 6.0f;

        public GasMotorcycle ()
        {
            base.EnergySource = new Gas(k_FuelType, k_MaximumFuelCapacity);
        }

        public void Refuel(Gas.FuelType i_FuelType, float i_AmountToRefuel)
        {
            ((Gas)EnergySource).FillGas(i_FuelType, i_AmountToRefuel);
            EnergyPercentge = (EnergySource.CurrentEnergyAmount / k_MaximumFuelCapacity) * 100;
        }
    }
}
