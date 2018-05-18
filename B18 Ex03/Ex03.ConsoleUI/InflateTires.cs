using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace ConsoleUI
{
    class InflateTires
    {
        private UserInterface m_UserInterface;

        public InflateTires(UserInterface i_UserInterface)
        {
            m_UserInterface = i_UserInterface;
            Console.Clear();
            Console.WriteLine("You have chosen to Inflate a vehicle tires to maximum");
            Console.WriteLine("Please enter the license number of the vehicle you want to inflate air to");
            string licensePlate = ValidateUserInput.GetLicensePlateFromUser();

            try
            {
                m_UserInterface.Garage.FillAirToMaximum(licensePlate);
                Console.Clear();
                Console.WriteLine(String.Format("{0} Wheels pumped to Maximum!", licensePlate));
                Messages.PressAnyKeyToContinue();
            }
            catch (Exception exepetion)
            {
                Console.Clear();
                Console.WriteLine(exepetion.Message);
                Messages.PressAnyKeyToContinue();
            }
        }
    }
}
