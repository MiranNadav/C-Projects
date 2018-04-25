using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace B18_Ex02
{
    class Coin
    {
        private char m_Row;
        private char m_Column;
        private char m_Type;
        private enum coinType
        {
            X,O
        }
        

        public Coin (char i_Row, char i_Column, char i_Type)
        {
            this.m_Row = i_Row;
            this.m_Column = i_Column;
            this.m_Type = i_Type;
        }

        public Coin(int i_Row, int i_Column, char i_Type)
        {
            parseRowLocation(i_Row);
            parseColumnLocation(i_Column);
            this.m_Type = i_Type;
        }

        
        private void parseRowLocation (int i_indexOfRow)
        {
            this.m_Row = (char)(i_indexOfRow + 49);
            //switch (i_indexOfRow)
            //{
            //    case 0:
            //        this.Row = 'a';
            //        break;
            //    case 1:
            //        this.Row = 'b';
            //        break;
            //    case 2:
            //        this.Row = 'c';
            //        break;
            //    case 3:
            //        this.Row = 'd';
            //        break;
            //    case 4:
            //        this.Row = 'e';
            //        break;
            //    case 5:
            //        this.Row = 'f';
            //        break;
            //    case 6:
            //        this.Row = 'g';
            //        break;
            //    case 7:
            //        this.Row = 'h';
            //        break;
        }
        private void parseColumnLocation(int i_indexOfColumn)
        {
            this.m_Column = (char)(i_indexOfColumn + 17);
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

        public char Type
        {
            get
            {
                return this.m_Type;
            }
            set
            {
                this.m_Type = value;
            }
        }

    }

}
