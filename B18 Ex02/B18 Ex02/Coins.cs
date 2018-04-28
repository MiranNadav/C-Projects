using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace B18_Ex02
{
    class Coins
    {
        private Coin[] m_Coins;
        private int m_NumOfCoins = 0;

<<<<<<< HEAD
        public Coins(char i_coinType, int i_NumOfCoins)
=======
        public Coins(char i_coinType)
>>>>>>> cd205ade1e9955260d5e72297b636838ea8a8ed6
        {
            this.m_NumOfCoins = i_NumOfCoins;
            this.m_Coins = new Coin[i_NumOfCoins]; // TODO: Use boardSize
            createCoinsArray(i_coinType);
        }

        private void createCoinsArray(char i_CoinType)
        {
<<<<<<< HEAD
            if (i_CoinType.Equals('O'))
            {
                createCoinsArrayForO(i_CoinType);
            }
            else
            {
                createCoinsArrayForX(i_CoinType);
            }

        }

        private void createCoinsArrayForO(char i_CoinType)
        {
            char row = 'b';
            char column = 'A';
            // TODO: use board size
            for (int i = 0; i < m_Coins.Length - 1; i++)
            {

                if (column % 2 == 1)
                {
                    m_Coins[i] = new Coin(row, column, i_CoinType);
                    column++;
                }
                else
                {
                    row--;
                    m_Coins[i] = new Coin(row, column, i_CoinType);
                    row = (char)(row + 2);
                    i++;
                    m_Coins[i] = new Coin(row, column, i_CoinType);
                    column++;
                    row--;
=======
            char row;
            char colm;
            int currentColumn = 0;

            if (i_CoinType.Equals('O'))
            {
                row = 'b';
                colm = 'A';
                // TODO: use board size
                for (int i = 0; i < coins.Length - 1; i++)
                {

                    if (colm % 2 == 1)
                    {
                        coins[i] = new Coin(row, colm, i_CoinType);
                        colm++;
                    }
                    else
                    {
                        row--;
                        coins[i] = new Coin(row, colm, i_CoinType);
                        row = (char)(row + 2);
                        i++;
                        coins[i] = new Coin(row, colm, i_CoinType);
                        colm++;
                        row--;
                    }
>>>>>>> cd205ade1e9955260d5e72297b636838ea8a8ed6
                }
            }
        }
        private void createCoinsArrayForX(char i_CoinType)
        {
            char row = 'g';
            char column = 'H';
            for (int i = m_Coins.Length - 1; i >= 0; i--)
            {
<<<<<<< HEAD
                if (column % 2 == 1)
=======
                Console.WriteLine("Im here");

                row = 'g';
                colm = 'A';
                for (int i = 0; i < coins.Length; i++)
>>>>>>> cd205ade1e9955260d5e72297b636838ea8a8ed6
                {
                    row++;
                    m_Coins[i] = new Coin(row, column, i_CoinType);
                    row = (char)(row - 2);
                    i--;
                    m_Coins[i] = new Coin(row, column, i_CoinType);
                    column--;
                    row++;
                }
                else
                {
                    m_Coins[i] = new Coin(row, column, i_CoinType);
                    column--;
                }
            }
        }


        public Coin GetCoin(int i_CoinIndex)
        {
            return this.m_Coins[i_CoinIndex];
        }

        public int GetCoinIndex(String i_Square)
        {
            int index = -1;
            Coin currentCoin;

            for (int i = 0; i < this.m_NumOfCoins; i++)
            {
                currentCoin = this.GetCoin(i);
                if (currentCoin.Square.Equals(i_Square))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
        public void moveCoin(string i_MoveFrom, string i_MoveTo)
        {
            int currentCoinIndex = GetCoinIndex(i_MoveFrom);
            Coin currentCoin = GetCoin(currentCoinIndex);

            currentCoin.Column = i_MoveTo[0];
            currentCoin.Row = i_MoveTo[1];
            currentCoin.Square = i_MoveTo;
        }

        public int getNumOfCoins()
        {
            return this.m_Coins.Length;
        }

        public void EatCoin(string i_CurrentMove)
        {
            string squareToRemoveCoinFrom;
            int coinToEatIndex;
            Coin coinToEat;

            squareToRemoveCoinFrom = calculateMiddleSquare(i_CurrentMove);
            coinToEatIndex= this.GetCoinIndex(squareToRemoveCoinFrom);
            coinToEat = this.GetCoin(coinToEatIndex);
            coinToEat = null;
        }

        private string calculateMiddleSquare(string i_CurrentMove)
        {
            char currentCol = i_CurrentMove[0];
            char currentRow = i_CurrentMove[1];
            char nextColumn = i_CurrentMove[3];
            char nextRow = i_CurrentMove[4];
            char middleSquareCol = (char)((currentCol + nextColumn) / 2);
            char middleSquareRow = (char)((currentRow + nextRow) / 2);
            string possibleOpponentSquare = new string(new char[] { middleSquareCol, middleSquareRow });

            return possibleOpponentSquare;

        }

        override
        public string ToString ()
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < this.getNumOfCoins(); i++)
            {
                if (this.m_Coins[i] != null)
                {
                    s.Append(", ");
                    s.Append(m_Coins[i].Square);
                }
            }
            return s.ToString();
        }

    }
}

