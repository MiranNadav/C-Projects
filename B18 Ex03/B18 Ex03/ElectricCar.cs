using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    class ElectricCar : Car
    {
        private float m_TimeLeftOnBattary;
        private const float k_MaximumChargeTimeOfBattary = 3.2F;

        public ElectricCar(string i_ModleName, string i_LicenseNumber, List<Wheel> i_Wheels, EnergySource i_EnergySource, string i_Color, int i_NumberOfDoors)
           : base()
        {
            base.ModelName = i_ModleName;
            base.LicenseNumber = i_LicenseNumber;
            base.Wheels = i_Wheels;
            base.EnergySource = i_EnergySource;
            base.EnergeyPercentge = 100.0F;
            if (!Enum.IsDefined(typeof(eNumberOfDoors), i_NumberOfDoors) || !listOfColors.Contains(i_Color))
            {
                throw new ArgumentException();
            }

            this.Color = i_Color;
            this.NumberOfDoors = (eNumberOfDoors)i_NumberOfDoors;
            this.m_TimeLeftOnBattary = k_MaximumChargeTimeOfBattary * (EnergeyPercentge / 100);
        }

        public void ChargeBattary(float i_NumberOfHouersTOAdd)
        {
            base.EnergySource.FillEnergy(i_NumberOfHouersTOAdd);
        }
    }
}
