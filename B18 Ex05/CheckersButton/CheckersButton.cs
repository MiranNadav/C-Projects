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
    public class CheckersCheckBox : CheckBox
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

        public CheckersCheckBox()
        {
            this.Appearance = Appearance.Button;
            base.Click += new EventHandler(toggleBackgroundColor);
            //base.Click += new EventHandler(toggleBackgroundImage);
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

        public void toggleBackgroundImage(object sender, EventArgs e)
        {
            if (m_CoinType == Coin.coinType.O)
            {

                if (BackColor == Color.Blue)//(BackgroundImage == Image.FromFile(@"C:\Users\shuhs\Documents\GitHub\C-Projects\B18 Ex05\Graphics\Chip-Black.jpg"))
                {
                    BackgroundImage = Image.FromFile(@"C:\Users\nmiran\Documents\Repositories\C#\B18 Ex05\Graphics\Chip_Black_Blue.jpg");
                }
                else
                {
                    BackgroundImage = Image.FromFile(@"C:\Users\nmiran\Documents\Repositories\C#\B18 Ex05\Graphics\Chip-Black.jpg");
                }
            }
            else if(m_CoinType == Coin.coinType.X)
            {
                if (BackColor == Color.Blue)//(BackgroundImage == Image.FromFile(@"C:\Users\shuhs\Documents\GitHub\C-Projects\B18 Ex05\Graphics\Chip-Red.jpg"))
                {
                    BackgroundImage = Image.FromFile(@"C:\Users\nmiran\Documents\Repositories\C#\B18 Ex05\Graphics\Chip-Red-Blue.jpg");
                }
                else
                {
                    BackgroundImage = Image.FromFile(@"C:\Users\nmiran\Documents\Repositories\C#\B18 Ex05\Graphics\Chip-Red.jpg");
                }
            }
        }

        //public void toggleBackgroundImage()
        //{
        //    if (m_CoinType == Coin.coinType.O)
        //    {

        //        if (BackColor == Color.Blue)//(BackgroundImage == Image.FromFile(@"C:\Users\shuhs\Documents\GitHub\C-Projects\B18 Ex05\Graphics\Chip-Black.jpg"))
        //        {
        //            BackgroundImage = Image.FromFile(@"C:\Users\shuhs\Documents\GitHub\C-Projects\B18 Ex05\Graphics\Chip_Black_Blue.jpg");
        //        }
        //        else
        //        {
        //            BackgroundImage = Image.FromFile(@"C:\Users\shuhs\Documents\GitHub\C-Projects\B18 Ex05\Graphics\Chip-Black.jpg");
        //        }
        //    }
        //    else
        //    {
        //        if (BackColor == Color.Blue)//(BackgroundImage == Image.FromFile(@"C:\Users\shuhs\Documents\GitHub\C-Projects\B18 Ex05\Graphics\Chip-Red.jpg"))
        //        {
        //            BackgroundImage = Image.FromFile(@"C:\Users\shuhs\Documents\GitHub\C-Projects\B18 Ex05\Graphics\Chip-Red-Blue.jpg");
        //        }
        //        else
        //        {
        //            BackgroundImage = Image.FromFile(@"C:\Users\shuhs\Documents\GitHub\C-Projects\B18 Ex05\Graphics\Chip-Red.jpg");
        //        }
        //    }
        //}


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
