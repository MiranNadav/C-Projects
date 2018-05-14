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
            string userAnswer = ValidatUserInput.validateYesOrNo();
            if (userAnswer.Equals("N"))
            {
                displayAllLicsensePlates();
            }
            else
            {
                displayFilterdLicsensePlates();
            }

            Console.ReadLine();
        }

        private void displayAllLicsensePlates()
        {
            List<> = m_userInterface.Garage.GetAllLicenseNumberList();
            if (listOfPlates.Length == 0)
            {
                Console.WriteLine("There are no vehicles in the garage");
            }
            else
            {
                Console.WriteLine("The license plates of all the vehicles whom are currently in the garage: ");
                Console.WriteLine(m_userInterface.Garage.GetAllLicenseNumberList());
            }
        }

        private void displayFilterdLicsensePlates()
        {
            Vehicle.eVehicleGarageStatus typeToFilterBy = ValidatUserInput.GetStateFromUser();
            string listOfFilterdPlates = m_userInterface.Garage.GetFilterdLicenseNumberList(typeToFilterBy);

            if (listOfFilterdPlates.Length == 0)
            {
                Console.WriteLine("There are no vehicles with the current status in the garage");
            }
            else
            {
                Console.WriteLine("The license plates of the vehicles whom are currently in the garage with the chosen status: ");
                Console.WriteLine(listOfFilterdPlates);
            }
        }
    }
}
