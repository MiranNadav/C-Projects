using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyPercentage = 0;
        private List<Wheel> m_Wheels;
        private EnergySource m_EnergySource;

        public Vehicle()
        {
            m_ModelName = String.Empty;
            m_LicenseNumber = String.Empty;
            m_EnergyPercentage = 0;
            m_Wheels = new List<Wheel>();
            m_EnergySource = null;
        }

        public string ModelName
        {
            get
            {
                return this.m_ModelName;
            }
            set
            {
                this.m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.m_LicenseNumber;
            }
            set
            {
                this.m_LicenseNumber = value;
            }
        }

        public float EnergyPercentge
        {
            get
            {
                return this.m_EnergyPercentage;
            }
            set
            {
                this.m_EnergyPercentage = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return this.m_Wheels;
            }
            set
            {
                this.m_Wheels = value;
            }
        }

        public EnergySource EnergySource
        {
            get
            {
                return this.m_EnergySource;
            }
            set
            {
                this.m_EnergySource = value;
            }
        }
    }
}
