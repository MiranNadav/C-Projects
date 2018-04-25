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
        //private string m_BoardPicture;
        //private char [,] m_BoardArray;
        private Coin [,] m_Board;

        //static void Main(string[] args)
        //{
        //}

        public Board(int i_BoardSize)
        {
            this.m_BoardSize = i_BoardSize;
            //this.m_BoardArray = new char[i_BoardSize, 8];
            this.m_Board = new Coin[i_BoardSize, 8];
            buildCleanBoard();
            
        }

        private void buildCleanBoard ()
        {

            this.m_Board[0, 1] = new Coin('a', 'B', 'O');
            this.m_Board[0, 3] = new Coin('a', 'D', 'O');
            this.m_Board[0, 5] = new Coin('a', 'F', 'O');
            this.m_Board[0, 7] = new Coin('a', 'H', 'O');

            this.m_Board[1, 0] = new Coin('b', 'A', 'O');
            this.m_Board[1, 2] = new Coin('b', 'C', 'O');
            this.m_Board[1, 4] = new Coin('b', 'E', 'O');
            this.m_Board[1, 6] = new Coin('b', 'G', 'O');

            this.m_Board[2, 1] = new Coin('c', 'B', 'O');
            this.m_Board[2, 3] = new Coin('c', 'D', 'O');
            this.m_Board[2, 5] = new Coin('c', 'F', 'O');
            this.m_Board[2, 7] = new Coin('c', 'H', 'O');

            char rowChar = (char)(m_BoardSize - 3 + 97);
            this.m_Board[m_BoardSize - 3, 0] = new Coin(rowChar, 'A', 'X');
            this.m_Board[m_BoardSize - 3, 2] = new Coin(rowChar, 'C', 'X');
            this.m_Board[m_BoardSize - 3, 4] = new Coin(rowChar, 'E', 'X');
            this.m_Board[m_BoardSize - 3, 6] = new Coin(rowChar, 'G', 'X');

            rowChar++;
            this.m_Board[m_BoardSize - 2, 1] = new Coin(rowChar, 'B', 'X');
            this.m_Board[m_BoardSize - 2, 3] = new Coin(rowChar, 'D', 'X');
            this.m_Board[m_BoardSize - 2, 5] = new Coin(rowChar, 'F', 'X');
            this.m_Board[m_BoardSize - 2, 7] = new Coin(rowChar, 'H', 'X');

            rowChar++;
            this.m_Board[m_BoardSize - 1, 0] = new Coin(rowChar, 'A', 'X');
            this.m_Board[m_BoardSize - 1, 2] = new Coin(rowChar, 'C', 'X');
            this.m_Board[m_BoardSize - 1, 4] = new Coin(rowChar, 'E', 'X');
            this.m_Board[m_BoardSize - 1, 6] = new Coin(rowChar, 'G', 'X');
            //Coin[] oneCoinRow = new Coin[8];
            //for (int i = 0; i < 3; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        oneCoinRow[1] = new Coin('a', 'B', 'O');
            //        oneCoinRow[3] = new Coin('a', 'B', 'O');
            //        oneCoinRow[5] = new Coin('a', 'B', 'O');
            //        oneCoinRow[7] = new Coin('a', 'B', 'O');
            //    }
            //}
            //for (int i = 0; i < m_Board.GetLength(1); i++)
            //{
            //    if (i % 2 == 1)
            //    {
            //        m_Board[0, i] = new Coin();
            //    }

            //}
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

        public void printBoard()
        {
            Console.WriteLine(" A   B   C   D   E   F   G   H ");
            printBorder();
            for (int i = 0; i < m_Board.GetLength(0); i++)
            {
                Console.Write((char)(i + 97) + "|");
                for (int j = 0; j < m_Board.GetLength(1); j++)
                {
                    if (m_Board[i,j] != null)
                    {
                        Console.Write(" " + m_Board[i, j].Type +" |");
                    }
                    else
                    {
                        Console.Write("   |");
                    }
                }
                Console.WriteLine();
                printBorder();
            }
        }
        private void printBorder()
        {
            Console.WriteLine("=================================");
        }

        public void moveCoin (string i_Movement, char i_CoinType)
        {

        }
        
    }
}
