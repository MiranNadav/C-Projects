using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace Ex03.ConsoleUI
{
    class AddVehicle
    {
        private UsertInterface m_UsertInterface;
        private string m_LicensePlate;
        private int m_VehcileType;

        public AddVehicle(UsertInterface i_UserInterface)
        {
            Console.Clear();
            Console.WriteLine("You have chosen to add a new vehicle");
            this.m_UsertInterface = i_UserInterface;
            getLicensePlateNumber();
            getVehicleType();
            addVehicleToGarage();
        }


        private void getLicensePlateNumber()
        {
            Console.WriteLine(Messages.k_EnterLicenseNumberMessage);
            string LicenseNumber = ValidatUserInput.ValidateInputInNotEmpty();
            this.m_LicensePlate = LicenseNumber;
        }

        private void getVehicleType()
        {
            Console.WriteLine("Please chose one of the following vehicle types:");
            Console.WriteLine(Messages.getEnumAsString(typeof(VehicleFactory.eVehicleTypes)));
            int userTypeChoiseAsInt = ValidatUserInput.ParseInputToInt();
            this.m_VehcileType = userTypeChoiseAsInt;
        }

        private void addVehicleToGarage()
        {
            Vehicle newVehicle;
            try
            {
                newVehicle = VehicleFactory.CreateVehicle(this.m_VehcileType);
                newVehicle.LicenseNumber = this.m_LicensePlate;
                m_UsertInterface.Garage.AddVehicleToGarage(newVehicle);
                Console.WriteLine("Vehicle added to garage");
                Messages.PressAnyKeyToContinue();
            }

            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
                if (exeption is ArgumentException)
                {
                    getVehicleType();
                }
                else
                {
                    Messages.PressAnyKeyToContinue();
                }
            }

        }
    }
}
