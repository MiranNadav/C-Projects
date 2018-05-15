using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace Ex03.ConsoleUI
{

    class Refuel
    {

        private UsertInterface m_UsertInterface;
        public Refuel(UsertInterface i_UserInterface)
        {
            this.m_UsertInterface = i_UserInterface;
            Console.Clear();
            Console.WriteLine("You have chosen to refuel a gas type car");
            Console.WriteLine("Please enter the license number of the car you would like to refuel");
            string LicenseNumber = ValidatUserInput.ValidateInputInNotEmpty();
            Console.WriteLine("Please enter the type of fuel of the car you would like to refuel");
            Console.WriteLine(Messages.getEnumAsString(typeof(Gas.FuelType)));
            Gas.FuelType fuelType = (Gas.FuelType)ValidatUserInput.InputIsInRangeOfEnum(typeof(Gas.FuelType));
            Console.WriteLine("Please enter the amount of fuel you would like to refuel");
            float amountOfFuel = ValidatUserInput.ParseInputToFloat();

            try
            {
                m_UsertInterface.Garage.RefuelGasVehicle(LicenseNumber, fuelType, amountOfFuel);
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
                Messages.PressAnyKeyToContinue();
            }
        }
    }
}
