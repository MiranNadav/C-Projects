using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class Messages
    {
        private static readonly string sr_Line = "==============";

        private static void menuBeginning(string i_MenuName)
        {
            Console.WriteLine(i_MenuName);
            Console.WriteLine(sr_Line);

        }

        internal static void dsiplayMenu(Menu i_Menu)
        {
            Console.Clear();

            string exitOrBack = i_Menu is MainMenu ? "Exit" : "Back";
            int maxValueInRange = i_Menu.MenuItems.Count;

            menuBeginning(i_Menu.MenuName);

            int numberOfCurrentItem = 1;

            foreach (MenuItem menuItem in i_Menu.MenuItems)
            {
                Console.WriteLine(numberOfCurrentItem + ". " + menuItem.ToString());
                numberOfCurrentItem++;
            }

            addBackMessage(exitOrBack);
            askUserForChoice(maxValueInRange, exitOrBack);
        }

        private static void askUserForChoice(int i_MaxValueInRange, string i_ExitOrBack)
        {

            Console.WriteLine(string.Format("Please enter your choice (1-{0} or 0 to {1}):", i_MaxValueInRange, i_ExitOrBack));
        }

        private static void addBackMessage(string i_ExitOrBack)
        {
            Console.WriteLine("0. " + i_ExitOrBack);
        }

        internal static void endSequence()
        {
            Console.Clear();
            Console.WriteLine("Thank you for using (APP NAME HERE)");
            Console.WriteLine("Press any key to close terminal");
            Console.ReadLine();
            Environment.Exit(0);
        }

        internal static void pressAnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        internal static void displayMessageAndContinue(string i_MessageToDisplay)
        {
            Console.WriteLine(i_MessageToDisplay);
            pressAnyKey();
        }
    }
}
