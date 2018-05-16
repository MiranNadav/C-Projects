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

        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleGarageStatus m_VehicleGarageStatus;

        public enum eVehicleGarageStatus
        {
            InRepair = 1,
            Repaired = 2,
            PayedFor = 3
        }
        public Vehicle()
        {
            m_ModelName = String.Empty;
            m_LicenseNumber = String.Empty;
            m_EnergyPercentage = 0;
            m_Wheels = new List<Wheel>();
            m_EnergySource = null;
            m_VehicleGarageStatus = eVehicleGarageStatus.InRepair;
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
        }

        public void SetEnergyPercentge()
        {
            m_EnergyPercentage = m_EnergySource.CurrentEnergyAmount / m_EnergySource.CurrentEnergyAmount;
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

        public string OwnerName
        {
            get
            {
                return this.m_OwnerName;
            }
            set
            {
                this.m_OwnerName = value;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return this.m_OwnerPhoneNumber;
            }
            set
            {
                this.m_OwnerPhoneNumber = value;
            }
        }

        public eVehicleGarageStatus VehicleGarageStatus
        {
            get
            {
                return this.m_VehicleGarageStatus;
            }
            set
            {
                this.m_VehicleGarageStatus = value;
            }
        }

        public void PumpAllWheelsAirToMaximum()
        {
            foreach (Wheel wheel in this.m_Wheels)
            {
                wheel.PumpAirToMaximum();
            }
        }

        public override string ToString()
        {
            return string.Format(
@"License number is: {0}
Model name is: {1}
Owner name is: {2}
Current state in garage: {3}
{4}
{5}",
this.m_LicenseNumber, this.m_ModelName, this.OwnerName, this.m_VehicleGarageStatus, this.m_Wheels[0].ToString(), this.m_EnergySource.ToString());
        }
    }
}