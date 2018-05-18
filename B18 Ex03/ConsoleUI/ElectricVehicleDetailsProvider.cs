using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace ConsoleUI
{
    public class ElectricVehicleDetailsProvider
    {
        private UserDisplay m_UserDisplay;

        public ElectricVehicleDetailsProvider()
        {
            m_UserDisplay = new UserDisplay();
        }

        public float GetAmountOfMinutesToCharge()
        {
            m_UserDisplay.ClearAndDisplayMessage("Please enter the number of minutes to charge");
            return ValidateUserInput.ParseInputToFloat();
        }

        public string GetLicenseNumberForCharging()
        {
            m_UserDisplay.DisplayMessage("Please enter the license number of the vehicle you would like to recharge");
            return ValidateUserInput.ValidateInputInNotEmpty();
        }
    }
}
