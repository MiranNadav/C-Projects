using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace ConsoleUI
{
    class LicenseNumbersFilter
    {
        //private UserInterface m_userInterface;
        private UserDisplay m_UserDisplay;

        public LicenseNumbersFilter()
        {
            m_UserDisplay = new UserDisplay();

            //m_userInterface = i_UserInterface;

            //Console.Clear();
            //Console.WriteLine("You have chosen to Display the license numbers of the vehicles whom are currently in the garage");
            //Console.WriteLine("Would you like to filter according to the status of each vehicle? Press Y for 'Yes' or N For 'No'");
            //bool userWantsToFilter = ValidateUserInput.validateYesOrNo();


        }

        public Vehicle.eVehicleGarageStatus GetFilter()
        {
            m_UserDisplay.clearAndDisplayMessage("You have chosen to Display the license numbers of the vehicles whom are currently in the garage");
            m_UserDisplay.displayMessage("Would you like to filter according to the status of each vehicle? Press Y for 'Yes' or N For 'No'");
            bool userWantsToFilter = ValidateUserInput.validateYesOrNo();
            Vehicle.eVehicleGarageStatus vehicleStatus;

            if (userWantsToFilter)
            {
                vehicleStatus = ValidateUserInput.GetStateFromUser();
            }
            else
            {
                vehicleStatus = Vehicle.eVehicleGarageStatus.Undefined;
            }

            return vehicleStatus;
        }

        //private void displayAllLicensesPlates()
        //{
        //    //List<string> licenseNumbers = m_userInterface.Garage.GetLicenseNumberList();
        //    Console.Clear();
        //    displayAccordingToSize(licenseNumbers);

        //}

        //private void displayFilterdLicensesPlates()
        //{
        //    Vehicle.eVehicleGarageStatus typeToFilterBy = ValidateUserInput.GetStateFromUser();
        //    //List<string> licenseNumbersFilterd = m_userInterface.Garage.GetLicenseNumberList(typeToFilterBy);
        //    Console.Clear();
        //    displayAccordingToSize(licenseNumbersFilterd);
        //}

        private void printList<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private void displayAccordingToSize<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("There are no vehicles for your choice in the garage");
            }
            else
            {
                Console.WriteLine("The list of plates that you requested: ");
                printList(list);
            }
        }
    }
}

