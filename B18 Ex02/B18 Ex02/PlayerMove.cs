using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    internal class PlayerMove
    {
        private Square m_CurrentSquare;
        private Square m_NextSquare;

        public PlayerMove(string i_CurrentMove)
        {
            m_CurrentSquare = new Square(i_CurrentMove[0], i_CurrentMove[1]);
            m_NextSquare = new Square(i_CurrentMove[3], i_CurrentMove[4]);
        }

        public PlayerMove(Square i_CurrentSquare, Square i_NextSquare)
        {
            m_CurrentSquare = i_CurrentSquare;
            m_NextSquare = i_NextSquare;
        }

        public int CurrentRowIndex
        {
            get
            {
                return this.m_CurrentSquare.RowIndex;
            }
        }

        public int CurrentColIndex
        {
            get
            {
                return this.m_CurrentSquare.ColumnIndex;
            }
        }

        public int NextRowIndex
        {
            get
            {
                return this.m_NextSquare.RowIndex;
            }
        }

        public int NextColIndex
        {
            get
            {
                return this.m_NextSquare.ColumnIndex;
            }
        }

        public Square CurrentSquare
        {
            get
            {
                return this.m_CurrentSquare;
            }
        }

        public Square NextSquare
        {
            get
            {
                return this.m_NextSquare;
            }
        }

        public Square calculateMiddleSquare()
        {
            int middleSquareCol = (this.CurrentColIndex + this.NextColIndex) / 2;
            int middleSquareRow = (this.CurrentRowIndex + this.NextRowIndex) / 2;
            return new Square(middleSquareCol, middleSquareRow);
        }

        public string GetFullMove()
        {
            return m_CurrentSquare.getSquare() + ">" + m_NextSquare.getSquare();
        }

        public override bool Equals(object i_Object)
        {
            PlayerMove otherMove = (PlayerMove)i_Object;
            return this.CurrentSquare.Equals(otherMove.CurrentSquare) && this.NextSquare.Equals(otherMove.NextSquare);
        }
    }
}
