﻿using System;
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
    }
}
