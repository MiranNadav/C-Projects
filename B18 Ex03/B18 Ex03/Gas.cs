using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    public class Gas : EnergySource
    {
        private FuelType m_GasType;

        public enum FuelType { Soler = 1, Octan95 = 2, Octan96 = 3, Octan98 = 4 };

        public Gas(FuelType i_GasType, float i_MaxAmountOfGas) : base(i_MaxAmountOfGas)
        {
            m_GasType = i_GasType;
        }

        public void FillGas(FuelType i_FuelType, float i_AmountOfGas)
        {
            if (i_FuelType != m_GasType)
            {
                throw new ArgumentException();
            }
            base.FillEnergy(i_AmountOfGas);
        }
    }
}
