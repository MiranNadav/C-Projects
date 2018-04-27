using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    class Coins
    {
        private Coin[] coins;

        public Coins(char i_coinType, int i_BoadSize)
        {
            this.coins = new Coin[12]; // TODO: Use boardSize
            createCoinsArray(i_coinType);
        }

        private void createCoinsArray(char i_CoinType)
        {
            char row;
            char colm;

            if (i_CoinType.Equals("O"))
            {
                row = 'b';
                colm = 'A';

                for (int i = 0; i < coins.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        coins[i] = new Coin(row, colm, i_CoinType);
                    }
                    else
                    {
                        colm++;
                        row--;
                        coins[i] = new Coin(row, colm, i_CoinType);
                        row = (char)(row + 2);
                        coins[i] = new Coin(row, colm, i_CoinType);
                        colm++;
                    }
                }
            }
            else
            {
                row = 'g';
                colm = 'A';
                for (int i = 0; i < coins.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        row++;
                        coins[i] = new Coin(row, colm, i_CoinType);
                        row = (char)(row - 2);
                        coins[i] = new Coin(row, colm, i_CoinType);
                        row--;
                        colm++;
                    }
                    else
                    {
                        coins[i] = new Coin(row, colm, i_CoinType);
                    }
                }

            }

        }

        public Coin GetCoin(int i_CoinIndex)
        {
            return this.coins[i_CoinIndex];
        }

        public int getNumOfCoins()
        {
            return this.coins.Length;
        }
    }
}

