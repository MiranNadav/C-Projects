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
        private Menu m_ParentMenu = null;
        private string m_MenuName;

        public Menu(string i_MenuName)
        {
            m_MenuName = i_MenuName;
        }

        public Menu(string i_MenuName, List<MenuItem> i_MenuItems)
        {
            m_MenuName = i_MenuName;
            m_MenuItemList = i_MenuItems;
        }

        public Menu ParentMenu
        {
            get
            {
                return m_ParentMenu;
            }
            set
            {
                m_ParentMenu = value;
            }
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

        public void Show()
        {
            Console.Clear();
            Messages.menuBeginning(m_MenuName);
            Messages.dsiplayMenuItems(this);
            Messages.askUserForChoice(m_MenuItemList.Count, this);
            string userChoice = Console.ReadLine();
            bool userWantsToGoBack = false;

            while (!userWantsToGoBack)
            {
                if (!(int.TryParse(userChoice, out int userChoiceAsInt) && ValidateUserInput.IsInputInRange(userChoiceAsInt, m_MenuItemList.Count)))
                {
                    Console.WriteLine("The input is not one of the available option(s). Please try again");
                    Messages.pressAnyKey();
                    Show();
                }

                if (userChoiceAsInt == 0)
                {
                    userWantsToGoBack = true;
                }
                else
                {
                    m_MenuItemList[userChoiceAsInt - 1].MenuThatItemBelongsTo = this;
                    m_MenuItemList[userChoiceAsInt - 1].ActionWhenChoose();
                    Console.ReadLine();
                }
            }

            if (this is SubMenu)
            {

                m_ParentMenu.Show();
            }
            else
            {
                Messages.endSequence();
            }
        }
    }
}