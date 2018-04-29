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
            if (i_BoardSize == 6)
            {
                this.m_NumOfCoins = 6; // TODO: need to use actual board size  
            }
            else if (i_BoardSize == 8)
            {
                this.m_NumOfCoins = 12;
            }
            else
            {
                this.m_NumOfCoins = 20;
            }

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
        public bool squareHasCoin(String square)
        {
            bool squareIsOcupid = false;

            for (int i = 0; i < this.m_NumOfCoins; i++)
            {
                if (this.m_Coins.GetCoin(i).getCurrentSquare().Equals(square))
                {
                    squareIsOcupid = true;
                    break;
                }
            }
            return squareIsOcupid;
        }
    }
}
