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
        private int numOfCoins = 0;

        public User(string i_UserName, char i_CoinType, int i_BoardSize)
        {
            this.m_UserName = i_UserName;
            this.m_CoinType = i_CoinType;
            if (i_BoardSize == 6)
            {
                this.numOfCoins = 6; // TODO: need to use actual board size  
            }
            else if (i_BoardSize == 8)
            {
                this.numOfCoins = 12;
            }
            else
            {
                this.numOfCoins = 20;
            }
            this.coins = new Coins(i_CoinType, numOfCoins); // TODO: need to use actual board size  
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


    }
}
