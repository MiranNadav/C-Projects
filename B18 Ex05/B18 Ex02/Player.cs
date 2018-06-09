using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace B18_Ex02
{
    public class Player
    {
        private string m_Name;
        private char m_CoinType;
        private bool m_IsComputer = false;
        private int m_TotalNumberOfPoints = 0;

        public Player(string i_UserName, char i_CoinType)
        {
            this.m_Name = i_UserName;
            this.m_CoinType = i_CoinType;
        }

        public Player()
        {
            this.m_Name = "Comp";
            this.m_CoinType = Constants.k_SecondCoinType;
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
                this.m_TotalNumberOfPoints = value;
            }
        }

        public bool IsComputer
        {
            get
            {
                return this.m_IsComputer;
            }
            set
            {
                m_IsComputer = value;
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
