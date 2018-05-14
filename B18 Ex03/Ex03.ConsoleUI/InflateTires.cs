using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace Ex03.ConsoleUI
{
    class InflateTires
    {
        private UsertInterface m_UsertInterface;

        public InflateTires(UsertInterface i_UserInterface)
        {
            m_UsertInterface = i_UserInterface;
            Console.Clear();
            Console.WriteLine("You have chosen to Inflate a vehicle tires to maximum");
            string licensePlate = ValidatUserInput.GetLicensePlateFromUser();

            try
            {
                m_UsertInterface.Garage.FillAirToMaximum(licensePlate);
                Console.WriteLine(String.Format("{0} Wheels pumped to Maximum!", licensePlate));
                Messages.PressAnyKeyToContinue();
            }
            catch (Exception exepetion)
            {
                Console.WriteLine(exepetion.Message);
                Messages.PressAnyKeyToContinue();
            }
        }
    }
}
