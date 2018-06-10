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
    public class CheckersSquare : CheckBox
    {
        private Square m_Square;
        private Coin.coinType? m_CoinType;
        private PictureBox m_CoinPicture;

        public PictureBox CoinPicture
        {
            get
            {
                return m_CoinPicture;
            }
            set
            {
                m_CoinPicture = value;
            }
        }

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

        public CheckersSquare()
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
