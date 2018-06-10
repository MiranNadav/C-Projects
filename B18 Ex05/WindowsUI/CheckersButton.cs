using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using B18_Ex02;

namespace CheckersComponents
{
    public class CheckersButton : CheckBox
    {
        private Square m_Square;
        private Coin.coinType? m_CoinType;

        public Square Square
        {
            get
            {
                return m_Square;
            }
            set
            {
                m_Square = value;
            }

        }

        public CheckersButton()
        {
            this.Appearance = Appearance.Button;
            base.Click += new EventHandler(toggleBackgroundColor);
        }

        private void toggleBackgroundColor(object sender, EventArgs e)
        {
            if (BackColor == Color.White)
            {
                BackColor = Color.Blue;
            }
            else
            {
                BackColor = Color.White;
            }
        }

        public Coin.coinType? CoinType
        {
            get
            {
                return m_CoinType;
            }
            set
            {
                m_CoinType = value;
            }
        }
    }
}
