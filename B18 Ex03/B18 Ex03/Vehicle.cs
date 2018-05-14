﻿using System;
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
            BeingFixed,
            Fixed,
            Paid
        }
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
            StringBuilder carFormat = new StringBuilder();
            carFormat.Append("License number is: " + this.m_LicenseNumber + Environment.NewLine);
            carFormat.Append("Model name is: " + this.m_ModelName+ Environment.NewLine);
            carFormat.Append("Owner name is: " + this.m_OwnerName + Environment.NewLine);
            carFormat.Append("Car Status is: " + this.m_VehicleGarageStatus + Environment.NewLine);
            carFormat.Append("Wheels Status is: " + Environment.NewLine + this.m_Wheels[0].ToString() + Environment.NewLine);
            
            return carFormat.ToString();
        }
    }
}
