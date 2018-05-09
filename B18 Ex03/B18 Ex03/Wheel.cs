using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxlimalAirPressure;

        private enum AirPressure { LowPressure = 28, MediumPressure = 30, HighPressure = 32 };

        public void PumpAir(float i_AirToPump)
        {
            if (i_AirToPump + m_CurrentAirPressure > m_MaxlimalAirPressure)
            {
                throw new ValueOutOfRangeException(0, m_MaxlimalAirPressure);
            }
        }

        
    }
}
