using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace ConsoleUI
{
    class CreateCar
    {
        private UserDisplay userDisplay;
        public CreateCar()
        {
            userDisplay = new UserDisplay();
        }

        public Car populateCarWithDetails(Vehicle i_NewVehicle)
        {
            Car car = (Car)i_NewVehicle;
            car.Color = paintCar();
            car.NumberOfDoors = installDoors();
            return car;
        }

        private Car.eCarColor paintCar()
        {
           userDisplay.clearAndDisplayMessage("Please choose car color: ");
           return (Car.eCarColor)ValidateUserInput.InputIsInRangeOfEnum(typeof(Car.eCarColor));
        }

        private Car.eNumberOfDoors installDoors()
        {
            userDisplay.clearAndDisplayMessage("Please choose the number of Doors: ");
            return (Car.eNumberOfDoors)ValidateUserInput.InputIsInRangeOfEnum(typeof(Car.eNumberOfDoors));
        }
    }
}
