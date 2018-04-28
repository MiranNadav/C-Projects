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
<<<<<<< HEAD
        private int numOfCoins = 0;
=======
        private int numOfCOins;
>>>>>>> cd205ade1e9955260d5e72297b636838ea8a8ed6

        public User(string i_UserName, char i_CoinType, int i_BoardSize)
        {
            this.m_UserName = i_UserName;
            this.m_CoinType = i_CoinType;
<<<<<<< HEAD
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
=======
            this.coins = new Coins(i_CoinType); // TODO: need to use actual board size  
            this.numOfCOins = 12; // TODO: need to use actual board size  
>>>>>>> cd205ade1e9955260d5e72297b636838ea8a8ed6
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

<<<<<<< HEAD

=======
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
>>>>>>> cd205ade1e9955260d5e72297b636838ea8a8ed6
    }
}
