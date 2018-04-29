using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{

    class PlayerMove
    {
        private char m_CurrentColumn;
        private char m_CurrentRow;
        private char m_NextColumn;
        private char m_NextRow;
        private string m_CurrentSquare;
        private string m_NextSquare;
        //TODO: is this a good name?
        private string m_FullMove;

        public PlayerMove(string i_CurrentMove)
        {
            this.m_CurrentColumn = i_CurrentMove[0];
            this.m_CurrentRow = i_CurrentMove[1];
            this.m_NextColumn = i_CurrentMove[3];
            this.m_NextRow = i_CurrentMove[4];
            this.m_CurrentSquare = String.Empty + m_CurrentColumn + m_CurrentRow;
            this.m_NextSquare = String.Empty + m_NextColumn + m_NextRow;
            this.m_FullMove = i_CurrentMove;
        }

        public char CurrentRow
        {
            get
            {
                return this.m_CurrentRow;
            }
        }

        public char CurrentColumn
        {
            get
            {
                return this.m_CurrentColumn;
            }
        }

        public char NextRow
        {
            get
            {
                return this.m_NextRow;
            }
        }


        public char NextColumn
        {
            get
            {
                return this.m_NextColumn;
            }
        }


        public string CurrentSquare
        {
            get
            {
                return this.m_CurrentSquare;
            }
        }

        public string NextSquare
        {
            get
            {
                return this.m_NextSquare;
            }
        }

        public string FullMove
        {
            get
            {
                return this.m_FullMove;
            }
        }
    }
}
