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
            paintCar();
            Console.Clear();
            installDoors();
        }

        private void paintCar()
        {
            Console.WriteLine("Please choose car color: ");
            Console.WriteLine(Messages.getEnumAsString(typeof(Car.eCarColor)));
            m_NewCar.Color = (Car.eCarColor)ValidatUserInput.InputIsInRangeOfEnum(typeof(Car.eCarColor));
        }

        private void installDoors()
        {
            Console.WriteLine("Please choose the number of Doors: ");
            Console.WriteLine(Messages.getEnumAsString(typeof(Car.eNumberOfDoors)));
            m_NewCar.NumberOfDoors = (Car.eNumberOfDoors)ValidatUserInput.InputIsInRangeOfEnum(typeof(Car.eNumberOfDoors));
        }
    }
}
