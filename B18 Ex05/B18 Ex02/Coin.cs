using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace B18_Ex02
{
    public class Coin
    {
        private Square currentSquare;
        private char m_Type;
        private bool m_isKing;

        private enum coinType
        {
            X, O
        }

        public Coin(char i_Row, char i_Column, char i_Type)
        {
            this.currentSquare = new Square(i_Column, i_Row);
            this.m_Type = i_Type;
            this.m_isKing = false;
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

        public bool IsKing
        {
            get
            {
                return this.m_isKing;
            }

            set
            {
                this.m_isKing = value;
            }
        }
    }
}
