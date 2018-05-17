using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace ConsoleUI
{

    class Refuel
    {
        private UserInterface m_UserInterface;
        public Refuel(UserInterface i_UserInterface)
        {
            this.m_UserInterface = i_UserInterface;
            Console.Clear();
            Console.WriteLine("You have chosen to refuel a gas type vehicle");
            getDetailsAndRefuel();
        }

        private void getDetailsAndRefuel()
        {
            Console.WriteLine("Please enter the license number of the vehicle you would like to refuel");
            string licenseNumber = ValidateUserInput.ValidateInputInNotEmpty();
            Console.Clear();
            Console.WriteLine("Please enter the type of fuel of the vehicle you would like to refuel");
            Gas.eFuelType fuelType = (Gas.eFuelType)ValidateUserInput.InputIsInRangeOfEnum(typeof(Gas.eFuelType));
            Console.Clear();
            Console.WriteLine("Please enter the amount of fuel you would like to refuel");
            float amountOfFuel = ValidateUserInput.ParseInputToFloat();

            try
            {
                m_UserInterface.Garage.RefuelGasVehicle(licenseNumber, fuelType, amountOfFuel);
                Console.Clear();
                Console.WriteLine(String.Format("Vehicle with license number: {0}, was refueled with gas type: {1}, and amount: {2} successfuly!", licenseNumber, fuelType, amountOfFuel));
                Messages.PressAnyKeyToContinue();
            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);

                if (exception is ValueOutOfRangeException)
                {
                    Console.WriteLine("Please try again");
                    getDetailsAndRefuel();
                }
                else
                {
                    Messages.PressAnyKeyToContinue();
                }
            }
        }
    }
}
