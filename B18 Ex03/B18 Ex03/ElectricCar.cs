using System;
using System.Collections.Generic;

namespace B18_Ex03
{
    class ElectricCar : Car
    {
        private float m_TimeLeftOnBattary;
        private const float k_MaximumChargeTimeOfBattery = 3.2f;

        public ElectricCar()
        {
            this.m_TimeLeftOnBattary = 100f;
            base.EnergySource = new Electric(k_MaximumChargeTimeOfBattery);
        }
    }
}
