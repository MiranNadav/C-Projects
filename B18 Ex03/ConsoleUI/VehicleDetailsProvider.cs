using B18_Ex03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class VehicleDetailsProvider
    {
        private Garage m_Garage;
        private string m_LicenseNumber;

        public VehicleDetailsProvider(Garage i_Garage)
        {
            this.m_Garage = i_Garage;
            Console.Clear();
            Console.WriteLine("You have chosen to get a vehicle details");
            Console.WriteLine("Please enter the license number of the vehicle to show its details");
            this.m_LicenseNumber = ValidateUserInput.GetLicensePlateFromUser();
            Console.Clear();
            getVehicleDetails();

        }

        private void getVehicleDetails()
        {
            try
            {
                m_Garage.IsVehicleInGarageException(m_LicenseNumber);
                Vehicle vehicle = m_Garage.GetVehicleByLicenseNumber(m_LicenseNumber);
                Console.WriteLine(vehicle.ToString());
                Messages.PressAnyKeyToContinue();

            }
            catch (ArgumentException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                Messages.PressAnyKeyToContinue();
            }
        }
    }
}
