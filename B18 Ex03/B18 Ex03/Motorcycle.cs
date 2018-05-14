﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    public abstract class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineSize;
        private const int k_NumberOfWheels = 2;
        private const int k_MaximumWheelPressure = 30;

        public enum eLicenseType
        {
            A, A1, B1, B2
        }

        public Motorcycle ()
        {
            base.Wheels = new List<Wheel>(k_NumberOfWheels);
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                base.Wheels.Add(new Wheel(k_MaximumWheelPressure));
            }
        }

        public int EngineSize
        {
            get
            {
                return m_EngineSize;
            }
            set
            {
                this.m_EngineSize = value;
            }
        }
        public eLicenseType LicenseType
        {
            get
            {
                return this.m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }
    }
}
