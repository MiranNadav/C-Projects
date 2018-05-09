using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyPercentage = 0;
        private List<Wheel> m_Wheels;
        private EnergySource m_EnergySource;

        public Vehicle(string i_ModelName, string i_LicenseNumber, List<Wheel> i_Wheels, EnergySource i_EnergySouce)
        {
            this.m_ModelName = i_ModelName;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_EnergySource = i_EnergySouce;
            this.m_Wheels = i_Wheels;
        }

    }
}
