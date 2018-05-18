using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace ConsoleUI
{
    class UserInterface
    {
        private Garage m_Garage;
        private AddVehicle m_VehicleAdder;
        private UserDisplay m_UserDisplay;
        private LicenseNumbersFilter m_LicenseNumberFilter;

        public UserInterface()
        {
            this.m_Garage = new Garage();
            this.m_VehicleAdder = new AddVehicle();
            this.m_UserDisplay = new UserDisplay();
            this.m_LicenseNumberFilter = new LicenseNumbersFilter();
        }

        public void ServeUser()
        {
            int userChoise = 0;
            Console.WriteLine(Messages.k_WelcomeUserMessage);
            Console.ReadLine();

            while (userChoise != (int)Messages.eMainMenuOptions.Exit)
            {
                Console.Clear();
                Console.WriteLine(Messages.k_Menu);
                userChoise = ValidateUserInput.getUserChoice();
                if (userChoise == 1)
                {
                    AddVehicleToGarage();
                }
                else if (userChoise == 2)
                    displayLicenseNumbersList();
                else if (userChoise == 3)
                {
                    ChangeStatus changeStatus = new ChangeStatus(this);
                }
                else if (userChoise == 4)
                {
                    Refuel refuel = new Refuel(this);
                }
                else if (userChoise == 5)
                {
                    ChargeElectricVehicle chargeElectricVehicle = new ChargeElectricVehicle(this);
                }
                else if (userChoise == 6)
                {
                    InflateTires inflateTires = new InflateTires(this);
                }
                else if (userChoise == 7)
                {
                    VehicleDetailsProvider vehicleDetailsProvider = new VehicleDetailsProvider(this.m_Garage);
                }
            }

            Messages.GoodByePrinter();
        }

        private void displayLicenseNumbersList()
        {
            Vehicle.eVehicleGarageStatus vehicleStatus = m_LicenseNumberFilter.GetFilter();
            List<string> licenseNumbers;

            if (vehicleStatus.Equals(Vehicle.eVehicleGarageStatus.Undefined))
            {
                licenseNumbers = m_Garage.GetLicenseNumberList();
            }
            else
            {
                licenseNumbers = m_Garage.GetLicenseNumberList(vehicleStatus);
            }
            m_UserDisplay.Clear();
            m_UserDisplay.displayAccordingToSize(licenseNumbers, "There are no vehicles for your choice in the garage", "The list of plates that you requested: ");
            Console.ReadLine();
        }

        private void AddVehicleToGarage()
        {
            try
            {
                Vehicle vehicle = this.m_VehicleAdder.getVitalDetailsFromUser();
                m_Garage.AddVehicleToGarage(vehicle);
                vehicle = this.m_VehicleAdder.populateVehicleWithDetails(vehicle);
                m_UserDisplay.clearAndDisplayMessage("Vehicle added to garage");
            }

            catch (Exception exception)
            {
                m_UserDisplay.clearAndDisplayMessage(exception.Message);
            }
            finally
            {
                m_UserDisplay.PressAnyKeyToContinue();
            }
        }

        public Garage Garage
        {
            get
            {
                return this.m_Garage;
            }
        }


    }
}
