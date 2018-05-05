using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace B18_Ex02
{
    class Player
    {
        private string m_Name;
        private char m_CoinType;
        private Coins m_Coins;
        private int m_NumOfCoins = 0;
        private int m_UserPoints = 0;

        public Player(string i_UserName, char i_CoinType, int i_BoardSize)
        {
            this.m_Name = i_UserName;
            this.m_CoinType = i_CoinType;

            this.m_NumOfCoins = (i_BoardSize * i_BoardSize - 2 * i_BoardSize) / 4;

            this.m_Coins = new Coins(i_CoinType, m_NumOfCoins); // TODO: need to use actual board size   
            CalcUserPoints();
        }

        public int CalcUserPoints()
        {
            Coin currentCoin;
            int points = 0;

            for (int i = 0; i < this.m_NumOfCoins; i++)
            {
                currentCoin = this.m_Coins.GetCoin(i);
                if (currentCoin != null)
                {
                    if (currentCoin.IsKing)
                    {
                        points = points + 4;
                    }
                    else
                    {
                        points = points + 1;
                    }
                }
            }

            this.m_UserPoints = points;
            return points;
        }


        public int Points
        {
            get
            {
                return this.m_UserPoints;
            }
            set
            {
                this.m_UserPoints = CalcUserPoints();
            }
        }

        public char CoinType
        {
            get
            {
                return this.m_CoinType;
            }
            set
            {
                this.m_CoinType = value;
            }
        }


        public string Name
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.m_Name = value;
            }
        }


        public Coins GetCoins()
        {
            return this.m_Coins;
        }
      
    }
}
