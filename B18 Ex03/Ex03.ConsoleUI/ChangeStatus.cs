using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace ConsoleUI
{
    class ChangeStatus
    {
        private UserDisplay m_UserDisplay;

        public ChangeStatus()
        {
            m_UserDisplay = new UserDisplay();
        }

        public string GetLicenseNumberForChangingStatus()
        {
            m_UserDisplay.DisplayMessage("Please enter the license number of the vehicle whose status you would like to change");
            return ValidateUserInput.GetLicensePlateFromUser();
        }

        public Vehicle.eVehicleGarageStatus GetGarageStatus()
        {
            return ValidateUserInput.GetStateFromUser();
        }
    }
}
