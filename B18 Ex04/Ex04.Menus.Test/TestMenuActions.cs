using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class TestMenuActions
    {
        public class ShowTime : IExecutable
        {
            public void ExecuteChoice()
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            }
        }

        public class ShowDate : IExecutable
        {
            public void ExecuteChoice()
            {
                Console.WriteLine(DateTime.Today.ToString("dd-MM-yyyy"));
            }
        }

        public class CountCapitals : IExecutable
        {
            public void ExecuteChoice()
            {
                Console.WriteLine("Please enter a sentence and we will count the number of capitals in your sentence!");
                string userSentence = Console.ReadLine();
                int numberOfCapitals = 0;

                for (int i = 0; i < userSentence.Length; i++)
                {
                    if (char.IsUpper(userSentence[i]))
                    {
                        numberOfCapitals++;
                    }
                }

                Console.WriteLine("The number of capitals in your sentence is: {0}", numberOfCapitals);
            }
        }

        public class ShowVersion : IExecutable
        {
            private string k_CurrentVersion = "App Version: 18.2.4.0";

            public void ExecuteChoice()
            {
                Console.WriteLine(k_CurrentVersion);
            }
        }
    }
}
