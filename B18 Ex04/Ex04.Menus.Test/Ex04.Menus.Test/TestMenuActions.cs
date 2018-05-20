using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    class TestMenuActions
    {
        public class ShowTime : Interfaces.IExecutable
        {
            public void ExecuteChoice()
            {
                Console.WriteLine(DateTime.Now);
            }
        }

        public class ShowDate : Interfaces.IExecutable
        {
            public void ExecuteChoice()
            {
                Console.WriteLine(DateTime.Today);
            }
        }
    }
}
