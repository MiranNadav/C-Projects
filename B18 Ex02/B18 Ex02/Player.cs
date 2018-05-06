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
        private int m_NumOfCoins = 0;
        private int m_UserPoints = 0;
        private bool m_IsComputer = false;
        private int m_TotalNumberOfPoints;

        public Player(string i_UserName, char i_CoinType, int i_BoardSize)
        {
            this.m_Name = i_UserName;
            this.m_CoinType = i_CoinType;

            this.m_NumOfCoins = (i_BoardSize * i_BoardSize - 2 * i_BoardSize) / 4;
            this.m_UserPoints = this.m_NumOfCoins;

        }

        public Player(int i_BoardSize)
        {
            this.m_Name = "Comp";
            this.m_CoinType = 'X';
            this.m_NumOfCoins = (i_BoardSize * i_BoardSize - 2 * i_BoardSize) / 4;
            this.m_UserPoints = this.m_NumOfCoins;
            this.m_IsComputer = true;

        }

        public int TotalNumberOfPoints
        {
            get
            {
                return this.m_TotalNumberOfPoints;
            }
            set
            {
                this.m_TotalNumberOfPoints += value;
            }
        }

        public bool IsComputer
        {
            get
            {
                return this.m_IsComputer;
            }
        }

        public int Points
        {
            get
            {
                return this.m_UserPoints;
            }
            set
            {
                this.m_UserPoints = value;
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


    }
}
