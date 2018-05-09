﻿using System;
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

        protected EnergySource(float i_CurrentAmount, float i_MaxAmount)
        {
            this.m_CurrentAmount = i_CurrentAmount;
            this.m_MaxAmount = i_MaxAmount;
        }

        public void FillEnergy(float i_AmountOfEnergy)
        {
            if (i_AmountOfEnergy < 0 || i_AmountOfEnergy + m_CurrentAmount > m_MaxAmount)
            {
                throw new ValueOutOfRangeException(0, m_MaxAmount);
            }
            else
            {
                this.m_CurrentAmount += i_AmountOfEnergy;
            }
        }
    }
}
