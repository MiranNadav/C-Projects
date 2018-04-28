using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace B18_Ex02
{
    class Board
    {
        private int m_BoardSize;
        private Coin[,] m_Board;
        User firstUser;
        User secondtUser;
        private string m_BoardPicture;
        private bool m_HasJump = false;


        public Board(int i_BoardSize, User i_FirstUser, User i_SecondUser)
        {
            this.m_BoardSize = i_BoardSize;
            this.firstUser = i_FirstUser;
            this.secondtUser = i_SecondUser;
            this.m_Board = new Coin[i_BoardSize, i_BoardSize];

            //buildCleanBoard();

        }

        private void buildEmptyBoard()
        {

            Coins firstUserCoins = this.firstUser.GetCoins();
            Coins secondUserCoins = this.secondtUser.GetCoins();
            int numOfCoins = firstUserCoins.getNumOfCoins();
            //TODO: OK to call it twice?
            setUserCoins(firstUserCoins, numOfCoins);
            setUserCoins(secondUserCoins, numOfCoins);
        }

        private void setUserCoins(Coins i_UsersCoins, int i_NumOfCoins)
        {
            int row;
            int col;
            Coin currentCoin;

            for (int i = 0; i < i_NumOfCoins; i++)
            {
                currentCoin = i_UsersCoins.GetCoin(i);
                row = currentCoin.Row - 97;
                col = currentCoin.Column - 65;
                this.m_Board[row, col] = currentCoin;
            }

        }

        private void hasJump()
        {
            bool hasJump = false;
            Coin currentCoin;
            Coin firstCandidateForJump;
            Coin secondCandidateForJump;
            Coin firstPossiboleBlock;
            Coin secondPossiboleBlock;

            for (int row = 0; row < this.m_BoardSize; row++)
            {
                for (int col = 0; col < this.m_BoardSize; col++)
                {
                    currentCoin = m_Board[row, col];

                    if (currentCoin != null)
                    {
                        // Jumps for 'X'
                        firstCandidateForJump = m_Board[row - 1, col + 1];
                        secondCandidateForJump = m_Board[row - 1, col - 1];
                        if ((firstCandidateForJump != null && firstCandidateForJump.Type != currentCoin.Type))
                        {
                            firstPossiboleBlock = m_Board[row - 2, col + 2];
                            if (firstPossiboleBlock == null)
                            {
                                hasJump = true;
                            }
                        }
                        else if ((secondCandidateForJump != null && secondCandidateForJump.Type != currentCoin.Type))
                        {
                            secondPossiboleBlock = m_Board[row - 2, col - 2];
                            if (secondPossiboleBlock == null)
                            {
                                hasJump = true;
                            }
                        }
                    }
                }

                this.m_HasJump = hasJump;
            }
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
                    if (m_Board[i, j] != null)
                    {
                        Console.Write(" " + m_Board[i, j].Type + " |");
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

        public void moveCoin(string i_Movement, char i_CoinType)
        {

        }

        public bool gameStatus()
        {
            return true;
        }



        //private void buildCleanBoard()
        //{

        //    this.m_Board[0, 1] = new Coin('a', 'B', 'O');
        //    this.m_Board[0, 3] = new Coin('a', 'D', 'O');
        //    this.m_Board[0, 5] = new Coin('a', 'F', 'O');
        //    this.m_Board[0, 7] = new Coin('a', 'H', 'O');

        //    this.m_Board[1, 0] = new Coin('b', 'A', 'O');
        //    this.m_Board[1, 2] = new Coin('b', 'C', 'O');
        //    this.m_Board[1, 4] = new Coin('b', 'E', 'O');
        //    this.m_Board[1, 6] = new Coin('b', 'G', 'O');

        //    this.m_Board[2, 1] = new Coin('c', 'B', 'O');
        //    this.m_Board[2, 3] = new Coin('c', 'D', 'O');
        //    this.m_Board[2, 5] = new Coin('c', 'F', 'O');
        //    this.m_Board[2, 7] = new Coin('c', 'H', 'O');

        //    char rowChar = (char)(m_BoardSize - 3 + 97);
        //    this.m_Board[m_BoardSize - 3, 0] = new Coin(rowChar, 'A', 'X');
        //    this.m_Board[m_BoardSize - 3, 2] = new Coin(rowChar, 'C', 'X');
        //    this.m_Board[m_BoardSize - 3, 4] = new Coin(rowChar, 'E', 'X');
        //    this.m_Board[m_BoardSize - 3, 6] = new Coin(rowChar, 'G', 'X');

        //    rowChar++;
        //    this.m_Board[m_BoardSize - 2, 1] = new Coin(rowChar, 'B', 'X');
        //    this.m_Board[m_BoardSize - 2, 3] = new Coin(rowChar, 'D', 'X');
        //    this.m_Board[m_BoardSize - 2, 5] = new Coin(rowChar, 'F', 'X');
        //    this.m_Board[m_BoardSize - 2, 7] = new Coin(rowChar, 'H', 'X');

        //    rowChar++;
        //    this.m_Board[m_BoardSize - 1, 0] = new Coin(rowChar, 'A', 'X');
        //    this.m_Board[m_BoardSize - 1, 2] = new Coin(rowChar, 'C', 'X');
        //    this.m_Board[m_BoardSize - 1, 4] = new Coin(rowChar, 'E', 'X');
        //    this.m_Board[m_BoardSize - 1, 6] = new Coin(rowChar, 'G', 'X');
        //    //Coin[] oneCoinRow = new Coin[8];
        //    //for (int i = 0; i < 3; i++)
        //    //{
        //    //    if (i % 2 == 0)
        //    //    {
        //    //        oneCoinRow[1] = new Coin('a', 'B', 'O');
        //    //        oneCoinRow[3] = new Coin('a', 'B', 'O');
        //    //        oneCoinRow[5] = new Coin('a', 'B', 'O');
        //    //        oneCoinRow[7] = new Coin('a', 'B', 'O');
        //    //    }
        //    //}
        //    //for (int i = 0; i < m_Board.GetLength(1); i++)
        //    //{
        //    //    if (i % 2 == 1)
        //    //    {
        //    //        m_Board[0, i] = new Coin();
        //    //    }

        //    //}
        //}


    }
}
