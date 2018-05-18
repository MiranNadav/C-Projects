using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace ConsoleUI
{
    class ChargeElectricVehicle
    {
        private UserInterface m_UserInterface;
        public ChargeElectricVehicle(UserInterface i_UserInterface)
        {
            this.m_UserInterface = i_UserInterface;
            Console.Clear();
            Console.WriteLine("You have chosen to recharge an Electric type vehicle");
            getDetailsAndChargeVehicle();
        }

        private void getDetailsAndChargeVehicle()
        {
            Console.WriteLine("Please enter the license number of the vehicle you would like to recharge");
            string licenseNumber = ValidateUserInput.ValidateInputInNotEmpty();
            Console.Clear();
            Console.WriteLine("Please enter the number of minutes to charge");
            float amountOfTimeToCharge = ValidateUserInput.ParseInputToFloat();

            try
            {
                m_UserInterface.Garage.RechargeElectricVehicle(licenseNumber, amountOfTimeToCharge);
                Console.Clear();
                Console.WriteLine(String.Format("Vehicle with license number: {0}, with amount: {1} successfuly!", licenseNumber, amountOfTimeToCharge));
                Messages.PressAnyKeyToContinue();

            }

            catch (Exception exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);

                if (exception is ValueOutOfRangeException)
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
