using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : Menu
    {

        private const string k_BackMessage = "Exit";

        public MainMenu(string i_SubMenuName)// : base(i_SubMenuName)
        {
            MenuName = i_SubMenuName;
        }
    }
}
