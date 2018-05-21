using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class LeafItem : MenuItem
    {
        private IExecutable m_ExecutableAction;

        public LeafItem(string i_ItemName, IExecutable i_ExecutableAction)
        {
            ItemName = i_ItemName;
            m_ExecutableAction = i_ExecutableAction;
        }

        public override string ToString()
        {
            return ItemName;
        }

        public override void ActionWhenChoose()
        {
            Console.Clear();
            m_ExecutableAction.ExecuteChoice();
            Messages.pressAnyKey();
            Console.Clear();
            MenuThatItemBelongsTo.Show();
        }
    }
}
