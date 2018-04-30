using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    class Square
    {
        private char m_Column;
        private char m_Row;

        public Square(char i_Column, char i_Row)
        {
            this.m_Column = i_Column;
            this.m_Row = i_Row;
        }

        public char Row
        {
            get
            {
                return this.m_Row;
            }
            set
            {
                this.m_Row = value;
            }

        }

        public char Column
        {
            get
            {
                return this.m_Column;
            }
            set
            {
                this.m_Column = value;
            }

        }

        public string getSquare()
        {
            return string.Empty + m_Column + m_Row;
        }

    }
}
