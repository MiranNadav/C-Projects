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
            List<MenuItem> showDataTime = new List<MenuItem>();
            List<MenuItem> VersionAndCapitals = new List<MenuItem>();

            MenuItem showTime = new LeafItem("Show Time", new TestMenuActions.ShowTime());
            MenuItem showDate = new LeafItem("Show Date", new TestMenuActions.ShowDate());

            MenuItem countCapitals = new LeafItem("Count Capitals", new TestMenuActions.CountCapitals());
            MenuItem showVersion = new LeafItem("Show Version", new TestMenuActions.ShowVersion());

            showDataTime.Add(showTime);
            showDataTime.Add(showDate);

            VersionAndCapitals.Add(countCapitals);
            VersionAndCapitals.Add(showVersion);

            MenuItem showDateOrTime_Item = new NodeItem("Show Date/Time", showDataTime);
            MenuItem VersionAndCapitals_Item = new NodeItem("Version and capitals", VersionAndCapitals);

            m_MainMenu.AddMenuItem(showDateOrTime_Item);
            m_MainMenu.AddMenuItem(VersionAndCapitals_Item);
        }
    }
}
