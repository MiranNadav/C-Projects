using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace ConsoleUI
{
    class ValidateUserInput
    {
        public static int getUserChoice()
        {
            int userChoise = ParseInputToInt();

            while (!(Enum.IsDefined(typeof(Messages.eMainMenuOptions), userChoise)))
            {
                Console.Clear();
                Console.WriteLine("Input is not a valid options. Please enter a valid option");
                Console.WriteLine();
                Console.WriteLine(Messages.k_Menu);
                userChoise = ParseInputToInt();
            }

            return userChoise;
        }

        public static string ValidateInputInNotEmpty()
        {
            string userInput = Console.ReadLine();

            while (userInput.Length == 0)
            {
                Console.WriteLine(Messages.k_EmptyInputMessage);
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        public static int ParseInputToInt()
        {
            string userInput = Console.ReadLine();
            int userInputToInt;

            while (!int.TryParse(userInput, out userInputToInt))
            {
                Console.WriteLine("Input is not a of valid type. Please try again");
                userInput = Console.ReadLine();
            }

            return userInputToInt;
        }

        //TODO: change this!
        public static float ParseInputToFloat()
        {
            string userInput = Console.ReadLine();
            float userInputTofloat;

            while (!float.TryParse(userInput, out userInputTofloat))
            {
                Console.WriteLine("Input is not a of valid type. Please try again");
                userInput = Console.ReadLine();
            }

            return userInputTofloat;
        }

        public static bool validateYesOrNo()
        {
            string userInput = Console.ReadLine();

            while (!userInput.Equals("Y") && !userInput.Equals("N"))
            {
                Console.WriteLine("The answer is invalid. Please answer With Y or N");
                userInput = Console.ReadLine();
            }

            return userInput.Equals("Y") ? true : false;
        }

        public static Vehicle.eVehicleGarageStatus GetStateFromUser()
        {
            Console.WriteLine("Please chose one of the following vehicle statuses:");
            Vehicle.eVehicleGarageStatus vehicleStatus = (Vehicle.eVehicleGarageStatus)InputIsInRangeOfEnum(typeof(Vehicle.eVehicleGarageStatus));

            return vehicleStatus;
        }

        public static string GetLicensePlateFromUser()
        {
            string licenseNumber = ValidateUserInput.ValidateInputInNotEmpty();
            return licenseNumber;
        }

        public static int InputIsInRangeOfEnum(Type i_EnumType)
        {
            Console.WriteLine(Messages.getEnumAsString(i_EnumType));
            int userInput = ParseInputToInt();

            while (!Enum.IsDefined(i_EnumType, userInput))
            {
                Console.Clear();
                Console.WriteLine("Input is not in the valid range. Please enter a option in the valid range");
                Console.WriteLine(Messages.getEnumAsString(i_EnumType));
                userInput = ParseInputToInt();
            }

            return userInput;
        }
    }
}
