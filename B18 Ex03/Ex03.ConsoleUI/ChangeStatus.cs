using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace Ex03.ConsoleUI
{
    class ChangeStatus
    {
        private UsertInterface m_UsertInterface;

        public ChangeStatus(UsertInterface i_UserInterface)
        {
            this.m_UsertInterface = i_UserInterface;

            Console.Clear();
            Console.WriteLine("You have chosen to change the status of a vehicle who is in the garage");
            string licenseNumber = ValidatUserInput.GetLicensePlateFromUser();
            Vehicle.eVehicleGarageStatus statusToChangeTo = ValidatUserInput.GetStateFromUser();

            try
            {
                m_UsertInterface.Garage.ChangeVehicleStatus(licenseNumber, statusToChangeTo);
                Console.Clear();
                Console.WriteLine("Vehicle status changed!");
                Messages.PressAnyKeyToContinue();
            }
            catch (Exception exeption)
            {
                Console.Clear();
                Console.WriteLine(exeption.Message);
                Messages.PressAnyKeyToContinue();
            }
        }
    }
}
