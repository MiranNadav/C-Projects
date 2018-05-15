using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace Ex03.ConsoleUI
{
    class ChargeElectricVehicle
    {
        private UsertInterface m_UsertInterface;
        public ChargeElectricVehicle(UsertInterface i_UserInterface)
        {
            this.m_UsertInterface = i_UserInterface;
            Console.Clear();
            Console.WriteLine("You have chosen to recharge an Electric type vehicle");
            getDetailsAndChargeVehicle();
        }

        private void getDetailsAndChargeVehicle()
        {
            Console.WriteLine("Please enter the license number of the vehicle you would like to refuel");
            string LicenseNumber = ValidatUserInput.ValidateInputInNotEmpty();
            Console.WriteLine("Please enter the number of minutes to charge");
            float amountOfTimeToCharge = ValidatUserInput.ParseInputToFloat();

            try
            {
                m_UsertInterface.Garage.RechargeElectricVehicle(LicenseNumber, amountOfTimeToCharge);
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);

                if (exeption is ValueOutOfRangeException)
                {
                    Console.WriteLine("Please try again");
                    getDetailsAndChargeVehicle();
                }
                else
                {
                    Messages.PressAnyKeyToContinue();
                }
            }
        }
    }
}
