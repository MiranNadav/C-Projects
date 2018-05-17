﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    public abstract class Car : Vehicle
    {

        private eNumberOfDoors m_NumberOfDoors;
        private eCarColor m_Color;
        private const int k_NumberOfWheels = 4;
        private const int k_MaximumWheelPressure = 32;

        public Car()
        {
            base.Wheels = new List<Wheel>(k_NumberOfWheels);
            //this.m_NumberOfDoors = 0;
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                base.Wheels.Add(new Wheel(k_MaximumWheelPressure));
            }
        }

        public enum eCarColor
        {
            Grey = 1,
            Blue = 2,
            White = 3,
            Black = 4
        }


        public enum eNumberOfDoors
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4
        }


        public eCarColor Color
        {
            get
            {
                return this.m_Color;
            }
            set
            {
                this.m_Color = value;
            }
        }


        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return this.m_NumberOfDoors;
            }
            set
            {
                this.m_NumberOfDoors = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
Number of doors is: {1}
Car color is: {2}", base.ToString(), this.m_NumberOfDoors, this.m_Color);
        }
    }
}
