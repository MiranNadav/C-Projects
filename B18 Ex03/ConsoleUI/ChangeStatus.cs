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
        private UserInterface m_UserInterface;

        public ChangeStatus(UserInterface i_UserInterface)
        {
            m_UserInterface = i_UserInterface;

            Console.Clear();
            Console.WriteLine("You have chosen to change the status of a vehicle who is in the garage");
            Console.WriteLine("Please enter the license number of the vehicle whose status you would like to change");
            string licenseNumber = ValidateUserInput.GetLicensePlateFromUser();
            Vehicle.eVehicleGarageStatus statusToChangeTo = ValidateUserInput.GetStateFromUser();

            try
            {
                m_UserInterface.Garage.ChangeVehicleStatus(licenseNumber, statusToChangeTo);
                Console.Clear();
                Console.WriteLine("Vehicle status changed!");
                Messages.PressAnyKeyToContinue();
            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                Messages.PressAnyKeyToContinue();
            }
        }
    }
}
