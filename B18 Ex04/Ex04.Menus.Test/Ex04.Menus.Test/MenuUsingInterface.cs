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
            createMainMenu();
            m_MainMenu.Show();
        }

        private void createMainMenu()
        {
            List<MenuItem> showDataTimeMenuItems = new List<MenuItem>();
            List<MenuItem> VersionAndCapitalsMenuItems = new List<MenuItem>();

            MenuItem showTime = new LeafItem("Show Time", new TestMenuActions.ShowTime());
            MenuItem showDate = new LeafItem("Show Date", new TestMenuActions.ShowDate());


            MenuItem countCapitals = new LeafItem("Count Capitals", new TestMenuActions.CountCapitals());
            MenuItem showVersion = new LeafItem("Show Version", new TestMenuActions.ShowVersion());


            showDataTimeMenuItems.Add(showTime);
            showDataTimeMenuItems.Add(showDate);

            VersionAndCapitalsMenuItems.Add(countCapitals);
            VersionAndCapitalsMenuItems.Add(showVersion);

            MenuItem showDateOrTime = new NodeItem("Show Date/Time", showDataTimeMenuItems);
            MenuItem VersionAndCapitals = new NodeItem("Version and capitals", VersionAndCapitalsMenuItems);

            m_MainMenu.AddMenuItem(showDateOrTime);
            m_MainMenu.AddMenuItem(VersionAndCapitals);
        }
    }
}
