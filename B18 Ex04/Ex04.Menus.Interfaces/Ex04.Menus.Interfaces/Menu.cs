using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public abstract class Menu
    {
        List<MenuItem> m_MenuItemList = new List<MenuItem>();

        private string m_MenuName;

        public Menu(string i_MenuName)
        {
            m_MenuName = i_MenuName;
        }

        public List<MenuItem> MenuItems
        {
            get
            {
                return m_MenuItemList;
            }

            set
            {
                m_MenuItemList = value;
            }
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            m_MenuItemList.Add(i_MenuItem);
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            try
            {
                m_MenuItemList.Remove(i_MenuItem);

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Show()
        {
            Messages.menuBeginning(m_MenuName);
            Messages.dsiplayMenuItems(this);
            Messages.askUserForChoice(m_MenuItemList.Count, this);
            string userChoice = Console.ReadLine();

            if (!(int.TryParse(userChoice, out int userChoiceAsInt) && ValidateUserInput.IsInputInRange(userChoiceAsInt, m_MenuItemList.Count)))
            {
                Console.WriteLine("The input is not one of the avaiable options. Please try again");
                Show();
            }
            else
            {
                m_MenuItemList[userChoiceAsInt - 1].ActionWhenChoose();
                Console.ReadLine();
            }
        }
    }
}
