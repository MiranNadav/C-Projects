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
            string licenseNumber = ValidatUserInput.GetLicensePlateFromUser();

            Vehicle vehicleToRefuel = 


        }
    }
}
