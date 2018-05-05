﻿using System;
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

        public char CurrentRow
        {
            get
            {
                return this.m_CurrentSquare.Row;
            }
        }

        public char CurrentCol
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


        public char NextCol
        {
            get
            {
                return this.m_NextSquare.Column;
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
        public string GetFullMove ()
        {
            return m_CurrentSquare.getSquare() + ">" + m_NextSquare.getSquare();
        }
    }
}