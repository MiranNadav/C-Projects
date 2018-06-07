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
using B18_Ex02;

namespace WindowsUI
{
    public partial class CheckersBoardForm : Form
    {
        string m_FirstPlayerName;
        string m_SecondPlayerName;
        int m_BoardSize;
        CheckersCheckBox m_CurrentCheckBoxChecked;
        GameManager m_GameManager;
        List<PlayerMove> m_PossibleMoves;
        List<CheckersCheckBox> m_NextPossibleSquares;

        public CheckersBoardForm(string i_FirstPlayerName, string i_SecondPlayerName, int i_BoardSize)
        {
            m_GameManager = new GameManager(6);
            //List<PlayerMove> possibleMoves = m_GameManager.getAllowedMoves();
            InitializeComponent();

            m_FirstPlayerName = i_FirstPlayerName;
            m_SecondPlayerName = i_SecondPlayerName;
            m_BoardSize = i_BoardSize;
            this.player1Name.Text = i_FirstPlayerName;
            this.player2Name.Text = i_SecondPlayerName;

            m_NextPossibleSquares = new List<CheckersCheckBox>();

            foreach (Control control in this.Controls)
            {
                if (control is CheckersCheckBox)
                {
                    (control as CheckersCheckBox).Click += new EventHandler(validateClick);
                }
            }
        }

        //TODO: fix bug - checking square twice and disable a green square
        //Current fix: List of next Possible squares, and check if it is not part of the list. 

        private void validateClick(object sender, EventArgs e)
        {
            if (m_CurrentCheckBoxChecked == null)
            {
                m_CurrentCheckBoxChecked = sender as CheckersCheckBox;
                m_PossibleMoves = m_GameManager.getAllowedMoves((sender as CheckersCheckBox).Name);
                foreach (PlayerMove possibleMove in m_PossibleMoves)
                {
                    foreach (Control control in this.Controls)
                    {
                        CheckersCheckBox currentCheckerSquare = (control as CheckersCheckBox);
                        if (currentCheckerSquare != null)
                        {
                            if (currentCheckerSquare.Name == possibleMove.NextSquare.getSquare())
                            {
                                currentCheckerSquare.BackColor = Color.Green;
                                currentCheckerSquare.Enabled = true;
                                m_NextPossibleSquares.Add(currentCheckerSquare);
                            }
                            else if (currentCheckerSquare != m_CurrentCheckBoxChecked && !m_NextPossibleSquares.Contains(currentCheckerSquare))
                            {
                                currentCheckerSquare.Name = currentCheckerSquare.Name;
                                currentCheckerSquare.Enabled = false;
                            }
                        }
                    }
                }
            }
            else
            {
                if ((sender as CheckersCheckBox) == m_CurrentCheckBoxChecked)
                {
                    m_CurrentCheckBoxChecked.BackColor = Color.White;
                    m_CurrentCheckBoxChecked = null;
                }
                else
                {
                    m_CurrentCheckBoxChecked.BackColor = Color.White;
                    CheckersCheckBox checkerCheckBox = (sender as CheckersCheckBox);
                    checkerCheckBox.BackColor = Color.White;
                    //m_GameManager.matchManager(m_GameManager.Board, m_CurrentCheckBoxChecked.Name + ">" + checkerCheckBox.Name);
                    m_CurrentCheckBoxChecked = null;
                    //validatemove();
                }
            }
        }

        private void enableAllButtons()
        {

        }
    }
}
