using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    class MenuUsingInterface
    {

        private Menu m_MainMenu;

        public void StartInterfaceUserMenu()
        {
            m_MainMenu = new MainMenu("Interface Menu");
            createMenu();
            m_MainMenu.Show();
        }

        private void createMenu()
        {
            SubMenu showDateOrTime_Menu = new SubMenu("Show Date / Time");
            MenuItem showTime = new LeafItem("Show Time", new TestMenuActions.ShowTime());
            MenuItem showDate = new LeafItem("Show Date", new TestMenuActions.ShowDate());
            MenuItem showDateOrTime_Item = new NodeItem("Show Date / Time", showDateOrTime_Menu);
            showDateOrTime_Menu.AddMenuItem(showTime);
            showDateOrTime_Menu.AddMenuItem(showDate);
            m_MainMenu.AddMenuItem(showDateOrTime_Item);
        }
    }
}
