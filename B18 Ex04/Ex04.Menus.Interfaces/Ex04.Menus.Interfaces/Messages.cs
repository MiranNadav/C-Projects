using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    class Messages
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
    }
}
