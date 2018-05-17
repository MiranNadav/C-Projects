using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace Ex03.ConsoleUI
{
    class UserInterface
    {
        private Garage m_Garage;

        public UserInterface()
        {
            this.m_Garage = new Garage();
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
                    AddVehicle addVehicle = new AddVehicle(this);
                }
                else if (userChoise == 2)
                {
                    DisplayLicenseNumbers displayLicenseNumbers = new DisplayLicenseNumbers(this);
                }
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

        public Garage Garage
        {
            get
            {
                return this.m_Garage;
            }
        }


    }
}
