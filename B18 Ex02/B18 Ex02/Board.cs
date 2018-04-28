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
<<<<<<< HEAD
        private Coins m_FirstUserCoins;
        private Coins m_SecondUserCoins;
=======
        User firstUser;
        User secondtUser;
        private string m_BoardPicture;
>>>>>>> cd205ade1e9955260d5e72297b636838ea8a8ed6
        private bool m_HasJump = false;


        public Board(int i_BoardSize)
        {
            int numOfCoins = 0;
            if (i_BoardSize == 6)
            {
                numOfCoins = 6;
            }
            else if (i_BoardSize == 8)
            {
                numOfCoins = 12;
            }
            else
            {
                numOfCoins = 20;
            }

            this.m_BoardSize = i_BoardSize;
            this.m_FirstUserCoins = new Coins('O',numOfCoins);
            this.m_SecondUserCoins = new Coins('X', numOfCoins);
            this.m_Board = new Coin[i_BoardSize, i_BoardSize];

<<<<<<< HEAD
=======
            //buildCleanBoard();
>>>>>>> cd205ade1e9955260d5e72297b636838ea8a8ed6

            buildBoard();
        }

        public Coins GetUserCoins(char i_CoinType)
        {
<<<<<<< HEAD
            return i_CoinType == 'O' ? m_FirstUserCoins : m_SecondUserCoins;
        }

        public Coins GetOtherUserCoins(char i_CoinType)
        {
            return i_CoinType == 'O' ? m_SecondUserCoins : m_FirstUserCoins;
        }


        public int GetBoardSize()
        {
            return this.m_BoardSize;
        }

        private void buildBoard()
        {
            int numOfCoins = this.m_FirstUserCoins.getNumOfCoins();
            //TODO: OK to call it twice?
            //Console.WriteLine("Coins After Upadte:");
            //printCoins(this.m_FirstUserCoins);
            this.m_Board = new Coin[this.m_BoardSize, this.m_BoardSize];
            setUserCoins(this.m_FirstUserCoins, numOfCoins);
            setUserCoins(this.m_SecondUserCoins, numOfCoins);
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

=======

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
>>>>>>> cd205ade1e9955260d5e72297b636838ea8a8ed6
        }

        private void hasJump()
        {
<<<<<<< HEAD
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
=======
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
>>>>>>> cd205ade1e9955260d5e72297b636838ea8a8ed6
        }

        public void printBoard()
        {
            string newLine = Environment.NewLine;
            char rowCharIndicator;
            char coinType;
            StringBuilder board = new StringBuilder();
            int numOfRows = m_Board.GetLength(0);
            int numOfColumns = m_Board.GetLength(1);

            board.Append("   A   B   C   D   E   F   G   H " + newLine);
            board.Append(getStringBorder() + newLine);
            for (int row = 0; row < numOfRows; row++)
            {
                rowCharIndicator = (char)(row + 97);
                board.Append(rowCharIndicator + "|");
                for (int column = 0; column < numOfColumns; column++)
                {
                    if (m_Board[row, column] != null)
                    {
                        coinType = m_Board[row, column].Type;
                        board.Append(" " + coinType + " |");
                    }
                    else
                    {
                        board.Append("   |");
                    }
                }

                board.Append(newLine);
                board.Append(getStringBorder());
                board.Append(newLine);

            }

            Console.WriteLine(board.ToString());
        }

        private string getStringBorder()
        {
            return " =================================";
        }

        public void MoveCoinInBoard(string i_Movement, User i_CurrentUser)
        {
            string squareBegin = i_Movement.Substring(0, 2);
            string squareEnd = i_Movement.Substring(3, 2);

<<<<<<< HEAD
            if (i_CurrentUser.CoinType == 'O')
            {
                this.m_FirstUserCoins.moveCoin(squareBegin, squareEnd);
            }
            else
            {
                this.m_SecondUserCoins.moveCoin(squareBegin, squareEnd);
            }

            buildBoard();
=======
>>>>>>> cd205ade1e9955260d5e72297b636838ea8a8ed6
        }

        public bool gameStatus()
        {
            return true;
        }



<<<<<<< HEAD
=======
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

>>>>>>> cd205ade1e9955260d5e72297b636838ea8a8ed6

    }
}
