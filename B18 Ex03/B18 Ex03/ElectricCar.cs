using System;
using System.Collections.Generic;

namespace B18_Ex03
{
    class ElectricCar : Car
    {
        private float m_TimeLeftOnBattary;
        private const float k_MaximumChargeTimeOfBattery = 3.2f;

        public ElectricCar(string i_ModleName, string i_LicenseNumber, List<Wheel> i_Wheels, EnergySource i_EnergySource, string i_Color, int i_NumberOfDoors)
           : base()
        {
            base.EnergySource = new Electric(k_MaximumChargeTimeOfBattery);


            base.ModelName = i_ModleName;
            base.LicenseNumber = i_LicenseNumber;
            base.Wheels = i_Wheels;
            //base.EnergySource = i_EnergySource;
            base.EnergyPercentge = 100.0F;
            //if (!Enum.IsDefined(typeof(eNumberOfDoors), i_NumberOfDoors) || !listOfColors.Contains(i_Color))
            //{
            //    throw new ArgumentException();
            //}

            //this.Color = i_Color;
            this.NumberOfDoors = (eNumberOfDoors)i_NumberOfDoors;
            this.m_TimeLeftOnBattary = k_MaximumChargeTimeOfBattery * (EnergyPercentge / 100);
        }

        public void ChargeBattery(float i_NumberOfHoursToAdd)
        {
            try
            {
                base.EnergySource.FillEnergy(i_NumberOfHoursToAdd);
            }
            catch (ValueOutOfRangeException e)
            {
                throw new ValueOutOfRangeException(e.MinValue, e.MaxValue, "Amount to rechange is above battery capacity. Please try again");
            }

            EnergyPercentge = (EnergySource.CurrentEnergyAmount / k_MaximumChargeTimeOfBattery) * 100;
        }
    }
}
