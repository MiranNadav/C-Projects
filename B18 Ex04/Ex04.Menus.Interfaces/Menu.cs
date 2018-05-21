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

        public string MenuName
        {
            get
            {
                return m_MenuName;
            } 
            set
            {
                m_MenuName = value;
            }
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            m_MenuItemList.Add(i_MenuItem);
        }

        public virtual void Show()
        {
            Messages.dsiplayMenu(this);
            string userChoice = Console.ReadLine();

            if (!(int.TryParse(userChoice, out int userChoiceAsInt) && ValidateUserInput.IsInputInRange(userChoiceAsInt, m_MenuItemList.Count)))
            {

                Messages.displayMessageAndContinue("The input is not one of the available option(s). Please try again");
                Show();
            }
            else if (userChoiceAsInt == 0)
            {
                if (this is SubMenu)
                {
                    m_ParentMenu.Show();
                }
                else if (this is MainMenu)
                {
                    Messages.endSequence();
                }
            }
            else
            {
                m_MenuItemList[userChoiceAsInt - 1].MenuThatItemBelongsTo = this;
                m_MenuItemList[userChoiceAsInt - 1].ActionWhenChoose();
            }
        }
    }
}