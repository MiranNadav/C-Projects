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
        private Coins m_FirstUserCoins;
        private Coins m_SecondUserCoins;
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


            buildBoard();
        }

        public Coins GetUserCoins(char i_CoinType)
        {
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

            if (i_CurrentUser.CoinType == 'O')
            {
                this.m_FirstUserCoins.moveCoin(squareBegin, squareEnd);
            }
            else
            {
                this.m_SecondUserCoins.moveCoin(squareBegin, squareEnd);
            }

            buildBoard();
        }

        public bool gameStatus()
        {
            return false;
        }




    }
}
