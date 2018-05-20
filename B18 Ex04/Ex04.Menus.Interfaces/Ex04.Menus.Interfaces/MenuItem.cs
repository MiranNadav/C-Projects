using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    class MenuItem
    {
        private string m_ItemTitle;

        public string ItemTitle
        {
            get
            {
                return this.m_ItemTitle;
            }
            set
            {
                this.m_ItemTitle = value;
            }
        }
    }
}
