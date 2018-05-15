using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace Ex03.ConsoleUI
{
    class DisplatLicenseNumbers
    {
        private UsertInterface m_userInterface;

        public DisplatLicenseNumbers(UsertInterface i_UserInterface)
        {
            Console.Clear();
            Console.WriteLine("You have chosen to Display the license numbers of the vehicles whom are currently in the garage");
            Console.WriteLine("Would you like to filter according to the status of each vehicle? Press Y for 'Yes' or 'N' For 'No'");
            this.m_userInterface = i_UserInterface;
            bool userWantsToFilter = ValidatUserInput.validateYesOrNo();
            if (userWantsToFilter)
            {
                displayFilterdLicsensePlates();
            }
            else
            {
                displayAllLicsensePlates();
            }

            Console.ReadLine();
        }

        private void displayAllLicsensePlates()
        {
            List<string> licenseNumbers = m_userInterface.Garage.GetLicenseNumberList();
            //TODO: better with string builder?
            printList(licenseNumbers);

        }

        private void displayFilterdLicsensePlates()
        {
            Vehicle.eVehicleGarageStatus typeToFilterBy = ValidatUserInput.GetStateFromUser();
            List<string> licenseNumbersFilterd = m_userInterface.Garage.GetLicenseNumberList(typeToFilterBy);

            if (licenseNumbersFilterd.Count == 0)
            {
                Console.WriteLine("There are no vehicles with the current status in the garage");
            }
            else
            {
                printList(licenseNumbersFilterd);
            }

        }

        public void printList<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}

