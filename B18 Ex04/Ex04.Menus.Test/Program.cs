using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MenuUsingInterface menuUsingInterface = new MenuUsingInterface();
            menuUsingInterface.StartInterfaceUserMenu();
            MenuUsingDelegates menuUsingDelegates = new MenuUsingDelegates();
            menuUsingDelegates.StartDelegatesUserMenu();
        }
    }
}
