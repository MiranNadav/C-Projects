using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    public abstract class EnergySource
    {
        private float m_CurrentAmount;
        private float m_MaxAmount;
        private eEnergyTypes m_EnergyType;

        public float CurrentEnergyAmount
        {
            get
            {
                return this.m_CurrentAmount;
            }
            set
            {
                this.m_CurrentAmount += value;
            }
        }

        public float MaxEnergyAmount
        {
            get
            {
                return this.m_MaxAmount;
            }
        }

        protected EnergySource(float i_MaxAmount)
        {
            this.m_CurrentAmount = 0;
            this.m_MaxAmount = i_MaxAmount;
        }

        public void FillEnergy(float i_AmountOfEnergy)
        {
            if (i_AmountOfEnergy < 0 || i_AmountOfEnergy + m_CurrentAmount > m_MaxAmount)
            {
                throw new ValueOutOfRangeException(0, m_MaxAmount - m_CurrentAmount);
            }
            else
            {
                this.m_CurrentAmount += i_AmountOfEnergy;
            }
        }

        public eEnergyTypes EnergyType
        {
            get
            {
                return this.m_EnergyType;
            }
            set
            {
                this.m_EnergyType = value;
            }
        }

        public enum eEnergyTypes
        {
            Gas,
            Electric
        }

        public override string ToString()
        {
            return string.Format(
@"Engine type is: {0}
Current amount of energy: {1}
Maximum amount of energy: {2}", this.m_EnergyType, this.m_CurrentAmount, this.m_MaxAmount);
        }
    }
}
