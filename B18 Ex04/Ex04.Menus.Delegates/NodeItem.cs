using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class NodeItem : MenuItem
    {
        private List<MenuItem> m_MenuItemsToShow;

        public NodeItem(string i_ItemName, List<MenuItem> i_MenuItems)
        {
            ItemName = i_ItemName;
            m_MenuItemsToShow = i_MenuItems;
        }

        public override void ActionWhenChoose()
        {
            Console.Clear();
            int indexOfItemInMenu = MenuThatItemBelongsTo.MenuItems.IndexOf(this);
            string SubMenuName = string.Format("{0}. {1}", indexOfItemInMenu + 1, ItemName);

            SubMenu subMenuToDisplayWhenChoose = new SubMenu(SubMenuName, m_MenuItemsToShow)
            {
                ParentMenu = MenuThatItemBelongsTo
            };

            subMenuToDisplayWhenChoose.Show();
        }
    }
}
