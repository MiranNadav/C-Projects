using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace Ex03.ConsoleUI
{
    class UsertInterface
    {
        private Garage m_Garage;

        public UsertInterface()
        {
            this.m_Garage = new Garage();
        }

        public void ServeUser()
        {
            int userChoise = 0;

            while (userChoise != (int)Messages.eMainMenuOptions.Exit)
            {
                Console.Clear();
                Console.WriteLine(Messages.k_Menu);
                userChoise = ValidatUserInput.getUserChoise();
                if (userChoise == 1)
                {
                    AddVehicle addVehicle = new AddVehicle(this);
                }
                else if (userChoise == 2)
                {
                    DisplatLicenseNumbers displatLicenseNumbers = new DisplatLicenseNumbers(this);
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
                    //should be vehicle details
                }
            }

            Console.WriteLine("Good bye! Please come again");
            Console.WriteLine("Press any key to close the terminal");
            Console.ReadLine();
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
