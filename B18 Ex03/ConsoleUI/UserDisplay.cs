using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class UserDisplay
    {
        public void displayMessage(String msg)
        {
            Console.WriteLine(msg);
        }

        public void Clear ()
        {
            Console.Clear();
        }
        public void displayMessageWithClear(String msg)
        {
            displayMessage(msg);
            Clear();
        }
        public void clearAndDisplayMessage(String msg)
        {
            Clear();
            displayMessage(msg);
        }

        public void displayList<T>(List<T> list)
        {
            foreach (var item in list)
            {
                displayMessage(item.ToString());
            }
        }
  
        public void displayAccordingToSize<T>(List<T> list, String sizeZeroMessage, String aboveZeroMessage)
        {
            if (list.Count == 0)
            {
                displayMessage(sizeZeroMessage);
            }
            else
            {
                Console.WriteLine(aboveZeroMessage);
                displayList(list);
            }
        }

        public void displayEmpty()
        {
            displayMessage(string.Empty);
        }

        public void PressAnyKeyToContinue()
        {
            displayEmpty();
            displayMessage("press any key to continue");
            Console.ReadLine();
        }

        public void displayExceptionMessage(Exception exception)
        {
            clearAndDisplayMessage(exception.Message);
            displayEmpty();
            displayMessage("Please try again");
        }
    }
}
