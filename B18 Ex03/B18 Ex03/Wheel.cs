using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    //TODO: should  be public?
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;
        //private eMaxAirPressure m_MaxAirPressure;
        //TODO: check what is the starter AirPressure


        public Wheel(float i_MaxAirPressure)
        {
            this.m_ManufacturerName = string.Empty;
            this.m_CurrentAirPressure = 0f;
            this.m_MaxAirPressure = i_MaxAirPressure;

            //if (!Enum.IsDefined(typeof(eMaxAirPressure), i_MaxAirPressure))
            //{
            //    throw new ArgumentException();
            //}

            //this.m_MaxAirPressure = (eMaxAirPressure)i_MaxAirPressure
        }

        //public Wheel(string i_ManufacturerName, int i_MaxAirPressure)
        //{
        //    this.m_ManufacturerName = i_ManufacturerName;
        //    this.m_CurrentAirPressure = 0F;
        //    if (!Enum.IsDefined(typeof(eMaxAirPressure), i_MaxAirPressure))
        //    {
        //        throw new ArgumentException();
        //    }

        //    this.m_MaxAirPressure = (eMaxAirPressure)i_MaxAirPressure;

        //}

        public string Manufacturer
        {
            get
            {
                return this.m_ManufacturerName;
            }
            set
            {
                this.m_ManufacturerName = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return this.m_CurrentAirPressure;
            }
            set
            {
                this.m_CurrentAirPressure = value;
            }
        }

        public float MaximumAirPressure
        {
            get
            {
                return this.m_MaxAirPressure;
            }
            set
            {
                this.m_MaxAirPressure = value;
            }
        }

        public void PumpAir(float i_AirToPump)
        {
            if (i_AirToPump + m_CurrentAirPressure > (int)m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, (int)m_MaxAirPressure, "Cannot fill air above maximum allowed.");
            }
            else
            {
                this.m_CurrentAirPressure += i_AirToPump;
            }
        }


        private enum eMaxAirPressure { LowPressure = 28, MediumPressure = 30, HighPressure = 32 };


    }
}
