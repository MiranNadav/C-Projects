using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace B18_Ex02
{
    class User
    {
        private string m_UserName;
        private char m_CoinType;
        private Coins coins;
        private int numOfCOins;

        public User(string i_UserName, char i_CoinType)
        {
            this.m_UserName = i_UserName;
            this.m_CoinType = i_CoinType;
            this.coins = new Coins(i_CoinType); // TODO: need to use actual board size  
            this.numOfCOins = 12; // TODO: need to use actual board size  
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


        public string UserName
        {
            get
            {
                return this.m_UserName;
            }
            set
            {
                this.m_UserName = value;
            }
        }


        public Coins GetCoins()
        {
            return this.coins;
        }

        public bool squareHasCoin(String square)
        {
            bool squareIsOcupid = false;

            for (int i = 0; i < this.numOfCOins; i++)
            {
                if (this.coins.GetCoin(i).getCurrentSquare().Equals(square))
                {
                    squareIsOcupid = true;
                    break;
                }
            }
            return squareIsOcupid;
        }
    }
}
