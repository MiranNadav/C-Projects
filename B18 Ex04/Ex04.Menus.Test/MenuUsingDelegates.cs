using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    internal class MenuUsingDelegates
    {
        private Menu m_MainMenu;

        public void StartDelegatesUserMenu()
        {
            m_MainMenu = new MainMenu("Delegates Menu");
            createMainMenu();
            m_MainMenu.Show();
        }

        private void createMainMenu()
        {
            List<MenuItem> showDataTime = new List<MenuItem>();
            List<MenuItem> VersionAndCapitals = new List<MenuItem>();

            MenuItem showVersion = new LeafItem("Show Version", new TestMenuActions.ShowVersion().ExecuteChoice);
            MenuItem countCapitals = new LeafItem("Count Capitals", new TestMenuActions.CountCapitals().ExecuteChoice);
            MenuItem showTime = new LeafItem("Show Time", new TestMenuActions.ShowTime().ExecuteChoice);
            MenuItem showDate = new LeafItem("Show Date", new TestMenuActions.ShowDate().ExecuteChoice);

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
