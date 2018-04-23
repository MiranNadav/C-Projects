using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    class Board
    {
        private int m_BoardSize;
        private string m_BoardPicture;
        private char [,] m_BoardArray;

        static void Main(string[] args)
        {
        }

        public Board(int i_BoardSize)
        {
            this.m_BoardSize = i_BoardSize;
            this.m_BoardArray = new char[i_BoardSize, 34];

        }

        private void buildEmptyBoard(int i_BoardSize)
        {
            this.m_BoardPicture = String.Format(
@" A   B   C   D   E   F   G   H
=================================
a|   | O |   | O |   | O |   | O |
=================================
b| O |   | O |   | O |   | O |   |
=================================
c|   | O |   | O |   | O |   | O |
=================================
d|   |   |   |   |   |   |   |   |
=================================
e|   |   |   |   |   |   |   |   |
=================================
f| X |   | X |   | X |   | X |   |
=================================
g|   | X |   | X |   | X |   | X |
=================================
h| X |   | X |   | X |   | X |   |
=================================");
        }
        
    }
}
