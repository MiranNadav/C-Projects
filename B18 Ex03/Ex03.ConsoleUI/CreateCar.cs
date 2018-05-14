using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace Ex03.ConsoleUI
{
    class CreateCar
    {
        public CreateCar()
        {
            Console.Clear();
        }

        private Car.eCarColor getColorFromUser()
        {
            Console.WriteLine("Please choose car color: ");
            Console.WriteLine(Messages.getEnumAsString(typeof(Car.eCarColor)));
            
        }

    }
}
