using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace B18_Ex02
{
    internal class Board
    {
        private int m_BoardSize;
        private Coin[,] m_Board;

        public Board(int i_BoardSize)
        {
            this.m_BoardSize = i_BoardSize;
            this.m_Board = new Coin[i_BoardSize, i_BoardSize];
            buildBoard();
        }

        public Coin[,] BoardArray
        {
            get
            {
                return this.m_Board;
            }
        }

        public int BoardSize
        {
            get
            {
                return this.m_BoardSize;
            }
        }

        public ArrayList GetUserCoins(char i_CoinType)
        {
            ArrayList coins = new ArrayList();
            Coin currentCoin;
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    currentCoin = m_Board[i, j];
                    if (currentCoin != null && currentCoin.Type.Equals(i_CoinType))
                    {
                        coins.Add(currentCoin);
                    }
                }
            }

            return coins;
        }

        private void buildBoard()
        {
            this.m_Board = new Coin[this.m_BoardSize, this.m_BoardSize];

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (!(i == m_BoardSize / 2 || i == (m_BoardSize / 2) - 1))
                    {
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
        }

        private void setCoinInBoard(int i_RowIndex, int i_ColumnIndex)
        {
            char coinType;
            if (i_RowIndex < m_BoardSize / 2)
            {
                coinType = Constants.k_FirstCoinType;
            }
            else
            {
                coinType = Constants.k_SecondCoinType;
            }

            m_Board[i_RowIndex, i_ColumnIndex] = new Coin(PlaceIndexConvertor.GetSmallCharByIndex(i_RowIndex), PlaceIndexConvertor.GetCapitalCharByIndex(i_ColumnIndex), coinType);
        }

        public bool IsEmptyAtSquare(Square i_Square)
        {
            // TODO: Array index out of bounds. probably because invalid number (generated to bad char in "PlaceConverter" class
            return m_Board[i_Square.RowIndex, i_Square.ColumnIndex] == null;
        }

        public bool IsSquareContainCoinByType(Square i_Square, char i_CoinType)
        {
            return !IsEmptyAtSquare(i_Square) && m_Board[i_Square.RowIndex, i_Square.ColumnIndex].Type.Equals(i_CoinType);
        }

        public void printBoard()
        {
            string newLine = Environment.NewLine;
            char rowCharIndicator;
            char coinType;
            StringBuilder board = new StringBuilder();
            Coin currentCoin;

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
                        currentCoin = m_Board[row, column];
                        if (currentCoin.IsKing)
                        {
                            coinType = m_Board[row, column].Type.Equals(Constants.k_FirstCoinType) ? 'U' : 'K';
                            board.Append(" " + coinType + " |");
                        }
                        else
                        {
                            coinType = m_Board[row, column].Type;
                            board.Append(" " + coinType + " |");
                        }
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

        public void MoveCoinInBoard(PlayerMove i_CurrentMove)
        {
            int currentRowToInt = i_CurrentMove.CurrentRowIndex;
            int currentcolumnToInt = i_CurrentMove.CurrentColIndex;
            int nextRowToInt = i_CurrentMove.NextRowIndex;
            int nextColumnToInt = i_CurrentMove.NextColIndex;
            Coin movingCoin;

            movingCoin = this.m_Board[currentRowToInt, currentcolumnToInt];
            this.m_Board[currentRowToInt, currentcolumnToInt] = null;
            this.m_Board[nextRowToInt, nextColumnToInt] = movingCoin;
        }

        public void EatCoin(PlayerMove i_CurrentMove)
        {
            Square squareToRemoveCoinFrom = i_CurrentMove.calculateMiddleSquare();
            m_Board[squareToRemoveCoinFrom.RowIndex, squareToRemoveCoinFrom.ColumnIndex] = null;
        }
    }
}
