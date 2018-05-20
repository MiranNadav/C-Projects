using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class NodeItem : MenuItem
    {
        private SubMenu m_SubMenuToShowWhenChoose;

        public NodeItem(string i_ItemName, SubMenu i_SubMenu)
        {
            ItemName = i_ItemName;
            m_SubMenuToShowWhenChoose = i_SubMenu;
        }

        public override void ActionWhenChoose()
        {
            m_SubMenuToShowWhenChoose.Show();
        }
    }
}
