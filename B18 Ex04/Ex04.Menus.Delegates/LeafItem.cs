using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public delegate void ActionsToExecuteDelegate();

    public class LeafItem : MenuItem
    {
        public event ActionsToExecuteDelegate ActionExecutor;
        
        public LeafItem(string i_Title, ActionsToExecuteDelegate i_ActionToAdd)
        {
            ItemName = i_Title;
            ActionExecutor += i_ActionToAdd;
        }

        public override void ActionWhenChoose()
        {
            Console.Clear();
            if (ActionExecutor != null)
            {
                ActionExecutor.Invoke();
                Messages.pressAnyKey();
                Console.Clear();
                MenuThatItemBelongsTo.Show();
            }
        }
    }
}
