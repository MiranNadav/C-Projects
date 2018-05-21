using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem
    {
        private string m_ItemName;
        private Menu m_MenuThatItemBelongsTo;

        public abstract void ActionWhenChoose();

        public string ItemName
        {
            get
            {
                return m_ItemName;
            }

            set
            {
                m_ItemName = value;
            }
        }

        public override string ToString()
        {
            return m_ItemName;
        }

        public Menu MenuThatItemBelongsTo
        {
            get
            {
                return m_MenuThatItemBelongsTo;
            }

            set
            {
                m_MenuThatItemBelongsTo = value;
            }
        }
    }
}
