using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class ValidateUserInputs
    {
        public static Messages.eMainMenuOptions ValidateMenuOption()
        {
            string userInputAsString = Console.ReadLine();
            int userInputAsInt;
            while (!(int.TryParse(userInputAsString, out userInputAsInt) && Enum.IsDefined(typeof(Messages.eMainMenuOptions), userInputAsInt)))
            {
                Console.Clear();
                Console.WriteLine(Messages.k_InvaidMenuOptionMessage);
                Console.WriteLine(Messages.k_Menu);
                userInputAsString = Console.ReadLine();
            }

            return (Messages.eMainMenuOptions)userInputAsInt;
        }

        public static string ValidateImputIsNotEmpty()
        {
            string UserInput = Console.ReadLine();
            while (UserInput.Length == 0)
            {
                Console.WriteLine("The input is empty. Please try again");
                UserInput = Console.ReadLine();
            }

            return UserInput;

        }

        public static int ParseUserInputToInt()
        {
            string userInputAsString = Console.ReadLine();
            int userInoutAsInt;

            while (!int.TryParse(userInputAsString, out userInoutAsInt))
            {
                Console.WriteLine("Input is not of a number format. Please try again");
                userInputAsString = Console.ReadLine();
            }

            return userInoutAsInt;
        }

    }
}
