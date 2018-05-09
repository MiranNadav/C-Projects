using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    public class Gas : EnergySource
    {
        public enum FuelType { Soler, Octan95, Octan96, Octan98 };
        private FuelType m_GasType;

        public Gas(FuelType i_GasType, float i_CurrentAmountOfGas, float i_MaxAmountOfGas) : base(i_CurrentAmountOfGas, i_MaxAmountOfGas)
        {
            m_GasType= i_GasType;
        }

        public void FillGas(float i_AmountOfGas)
        {
            base.FillEnergy(i_AmountOfGas);
        }
    }
}
