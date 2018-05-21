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

        internal static void menuBeginning(string i_MenuName)
        {
            Console.WriteLine(i_MenuName);
            Console.WriteLine(sr_Line);

        }

        internal static void dsiplayMenuItems(Menu i_Menu)
        {
            int numberOfCurrentItem = 1;

            foreach (MenuItem menuItem in i_Menu.MenuItems)
            {
                Console.WriteLine(numberOfCurrentItem + ". " + menuItem.ToString());
                numberOfCurrentItem++;
            }

            addBackMessage(i_Menu);
        }

        internal static void displayWhenNumbersIsSet(Menu i_Menu)
        {
            foreach (MenuItem menuItem in i_Menu.MenuItems)
            {
                Console.WriteLine(menuItem.ToString());
            }

            addBackMessage(i_Menu);
        }

        internal static void askUserForChoice(int i_MaxValueInRange, Menu i_Menu)
        {
            string backOrExit = i_Menu is MainMenu ? "Exit" : "Back";
            //TODO: Change to string format
            Console.WriteLine("Please enter your choice (1-" + i_MaxValueInRange + " or 0 to " + backOrExit + "):");
        }

        internal static void addBackMessage(Menu i_Menu)
        {
            string backOrExit = i_Menu is MainMenu ? "Exit" : "Back";
            Console.WriteLine("0. " + backOrExit);
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
    }
}
