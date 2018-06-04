using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckersComponents;

namespace WindowsUI
{
    public partial class CheckersBoardForm : Form
    {
        string m_FirstPlayerName;
        string m_SecondPlayerName;
        int m_BoardSize;
        CheckersCheckBox m_CurrentCheckBoxChecked;

        public CheckersBoardForm(string i_FirstPlayerName, string i_SecondPlayerName, int i_BoardSize)
        {
            InitializeComponent();

            m_FirstPlayerName = i_FirstPlayerName;
            m_SecondPlayerName = i_SecondPlayerName;
            m_BoardSize = i_BoardSize;
            this.player1Name.Text = i_FirstPlayerName;
            this.player2Name.Text = i_SecondPlayerName;

            foreach (Control control in this.Controls)
            {
                if (control is CheckersCheckBox)
                {
                    (control as CheckersCheckBox).Click += new EventHandler(validateClick);
                }
            }
        }

        private void validateClick(object sender, EventArgs e)
        {
            if (m_CurrentCheckBoxChecked == null)
            {
                m_CurrentCheckBoxChecked = sender as CheckersCheckBox;
            }
            else
            {
                m_CurrentCheckBoxChecked.BackColor = Color.White;
                (sender as CheckersCheckBox).BackColor = Color.White;
                m_CurrentCheckBoxChecked = null;
                //validatemove();
            }
        }
    }
}
