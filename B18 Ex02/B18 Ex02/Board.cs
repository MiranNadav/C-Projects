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
        private Coins m_FirstPlayerCoins;
        private Coins m_SecondPlayerCoins;
        private bool m_HasJump = false;


        public Board(int i_BoardSize, Coins i_FirstUserCoins, Coins i_SecondUserCoins)
        {
            this.m_BoardSize = i_BoardSize;
            this.m_FirstPlayerCoins = i_FirstUserCoins;
            this.m_SecondPlayerCoins = i_SecondUserCoins;
            //this.m_FirstUserCoins = new Coins('O', numOfCoins);
            //this.m_SecondUserCoins = new Coins('X', numOfCoins);
            this.m_Board = new Coin[i_BoardSize, i_BoardSize];
            buildBoard();
        }

        public Coin[,] currentBoard
        {
            get
            {
                return this.m_Board;
            }
        }

        public Coins GetUserCoins(char i_CoinType)
        {
            return i_CoinType == 'O' ? m_FirstPlayerCoins : m_SecondPlayerCoins;
        }

        public Coins GetOtherUserCoins(char i_CoinType)
        {
            return i_CoinType == 'O' ? m_SecondPlayerCoins : m_FirstPlayerCoins;
        }


        public int GetBoardSize()
        {
            return this.m_BoardSize;
        }

        private void buildBoard()
        {
            char coinType;
            int numOfCoins = this.m_FirstPlayerCoins.getNumOfCoins();
            this.m_Board = new Coin[this.m_BoardSize, this.m_BoardSize];
            //setUserCoins(this.m_FirstPlayerCoins, numOfCoins);
            //setUserCoins(this.m_SecondPlayerCoins, numOfCoins);

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (!(i == m_BoardSize / 2 || i == (m_BoardSize / 2) - 1))
                        if (i % 2 == 0 && j % 2 == 1)
                        {
                            setCoinInBoard(i, j);
                        }
                        else if (i % 2 == 1 && j % 2 == 0)
                        {
                            setCoinInBoard(i, j);
                        }
                }
            }
        }

        private void setCoinInBoard(int i_RowIndex, int i_ColumnIndex)
        {
            char coinType;
            if (i_RowIndex < m_BoardSize / 2)
            {
                coinType = 'O';
            }
            else
            {
                coinType = 'X';
            }
            m_Board[i_RowIndex, i_ColumnIndex] = new Coin(PlaceIndexConvertor.GetSmallCharByIndex(i_RowIndex),
                                                        PlaceIndexConvertor.GetCapitalCharByIndex(i_ColumnIndex), coinType);
        }

        private void setUserCoins(Coins i_UsersCoins, int i_NumOfCoins)
        {
            int row;
            int col;
            Coin currentCoin;

            for (int i = 0; i < i_NumOfCoins; i++)
            {
                currentCoin = i_UsersCoins.GetCoin(i);
                if (currentCoin != null)
                {
                    row = currentCoin.Row - 97;
                    col = currentCoin.Column - 65;
                    this.m_Board[row, col] = currentCoin;
                }
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
            //int numOfRows = m_Board.GetLength(0);
            //int numOfColumns = m_Board.GetLength(1);

            for (int i = 0; i < m_BoardSize; i++)
            {
                board.Append("   " + PlaceIndexConvertor.GetCapitalCharByIndex(i));
            }
            board.Append(newLine);
            board.Append(getStringBorder() + newLine);
            for (int row = 0; row < m_BoardSize; row++)
            {
                rowCharIndicator = PlaceIndexConvertor.GetSmallCharByIndex(row);
                board.Append(rowCharIndicator + "|");
                for (int column = 0; column < m_BoardSize; column++)
                {
                    if (m_Board[row, column] != null)
                    {
                        //if (m_Board[row, column].Square != "zz")
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
            StringBuilder border = new StringBuilder(" ");
            for (int i = 0; i < m_BoardSize; i++)
            {
                border.Append("====");
            }

            return border.ToString();
        }

        public void MoveCoinInBoard(string i_Movement, Player i_CurrentUser)
        {
            string squareBegin = i_Movement.Substring(0, 2);
            string squareEnd = i_Movement.Substring(3, 2);

            if (i_CurrentUser.CoinType == 'O')
            {
                this.m_FirstPlayerCoins.moveCoin(squareBegin, squareEnd);
            }
            else
            {
                this.m_SecondPlayerCoins.moveCoin(squareBegin, squareEnd);
            }

            buildBoard();
        }

        public bool gameStatus()
        {
            return false;
        }

    }
}
