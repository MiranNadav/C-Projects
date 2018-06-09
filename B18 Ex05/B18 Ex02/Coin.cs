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
        private coinType? m_CoinType;

        public enum coinType
        {
            X = 'X',
            O = 'O',
            K = 'K',
            U = 'U'

        }

        public Coin(char i_Row, char i_Column, char i_Type)
        {
            this.currentSquare = new Square(i_Column, i_Row);
            this.m_Type = i_Type;

            if (i_Type.Equals('O'))
            {
                m_CoinType = coinType.O;
            }
            else if (i_Type.Equals('X'))
            {
                m_CoinType = coinType.X;
            }
            else
            {
                m_CoinType = null;
            }

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

        public coinType? CoinType
        {
            get
            {
                return m_CoinType;
            }
            set
            {
                m_CoinType = value;
            }
        }
    }
}
