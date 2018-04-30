using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{

    class PlayerMove
    {
        private Square m_CurrentSquare;
        private Square m_NextSquare;

        public PlayerMove(string i_CurrentMove)
        {
            m_CurrentSquare = new Square(i_CurrentMove[0], i_CurrentMove[1]);
            m_NextSquare = new Square(i_CurrentMove[3], i_CurrentMove[4]);
        }

        public char CurrentRow
        {
            get
            {
                return this.m_CurrentSquare.Row;
            }
        }

        public char CurrentColumn
        {
            get
            {
                return this.m_CurrentSquare.Column;
            }
        }

        public char NextRow
        {
            get
            {
                return this.m_NextSquare.Row;
            }
        }


        public char NextColumn
        {
            get
            {
                return this.m_NextSquare.Column;
            }
        }


        public string CurrentSquare
        {
            get
            {
                return this.m_CurrentSquare.getSquare();
            }
        }

        public string NextSquare
        {
            get
            {
                return this.m_NextSquare.getSquare();
            }
        }

        public string GetFullMove ()
        {
            return m_CurrentSquare.getSquare() + ">" + m_NextSquare.getSquare();
        }
    }
}
