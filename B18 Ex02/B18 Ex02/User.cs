using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    class User
    {
        private string m_UserName;
        private char m_CoinType;
        private Coins coins;

        public User(string i_UserName, char i_CoinType)
        {
            this.m_UserName = i_UserName;
            this.m_CoinType = i_CoinType;
            this.coins = new Coins(i_CoinType, 12); // TODO: need to use actual board size  
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
                return this.UserName;
            }
            set
            {
                this.UserName = value;
            }
        }

        public Coins GetCoins()
        {
            return this.coins;
        }
    }
}
