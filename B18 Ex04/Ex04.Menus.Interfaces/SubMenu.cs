using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class SubMenu : Menu
    {
        private const string k_BackMessage = "Back";

        public SubMenu(string i_SubMenuName, List<MenuItem> i_MenuItems)
        {
            MenuName = i_SubMenuName;
            MenuItems = i_MenuItems;
        }

        //public override void Show()
        //{
        //    Show();
        //}
    }
}
