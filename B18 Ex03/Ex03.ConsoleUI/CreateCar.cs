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
        private Car m_NewCar;
        public CreateCar(Vehicle i_NewVehicle)
        {
            this.m_NewCar = (Car)i_NewVehicle;
            Console.Clear();
        }

        private Car.eCarColor getColorFromUser()
        {
            Console.WriteLine("Please choose car color: ");
            Console.WriteLine(Messages.getEnumAsString(typeof(Car.eCarColor)));
            int userColorAsInt = ValidatUserInput.ParseInputToInt();
            try
            {
                m_NewCar.Color = userColorAsInt;
            }
            catch
            {

            }
        }

    }

}
}
