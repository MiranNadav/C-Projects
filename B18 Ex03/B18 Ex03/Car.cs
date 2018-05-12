using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    public abstract class Car : Vehicle
    {

        //private eCarColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;
        protected List<string> listOfColors = new List<string>();
        private string m_Color;

        public Car()
        {
            listOfColors.Add("Gray");
            listOfColors.Add("Blue");
            listOfColors.Add("White");
            listOfColors.Add("Black");
            this.m_Color = String.Empty;
            this.m_NumberOfDoors = 0;
        }

        //public enum eCarColor
        //{
        //    Undefined,
        //    Yellow = 1,
        //    White = 2,
        //    Black = 3,
        //    Blue = 4
        //}


        public enum eNumberOfDoors
        {
            Undefined,
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4
        }



        public string Color
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
    }
}
