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
        List<CheckersCheckBox> m_CheckersCheckBoxList;

        public CheckersBoardForm(string i_FirstPlayerName, string i_SecondPlayerName, int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            m_GameManager = new GameManager(m_BoardSize);
            m_FirstPlayerName = i_FirstPlayerName;
            m_SecondPlayerName = i_SecondPlayerName;
            m_CheckersCheckBoxList = new List<CheckersCheckBox>();
            //this.player1Name.Text = i_FirstPlayerName;
            //this.player2Name.Text = i_SecondPlayerName;
            //List<PlayerMove> possibleMoves = m_GameManager.getAllowedMoves();
            //InitializeComponent();
            initComponents();


            m_NextPossibleSquares = new List<CheckersCheckBox>();

            foreach (Control control in this.Controls)
            {
                if (control is CheckersCheckBox)
                {
                    if ((control as CheckersCheckBox).BackColor == Color.White)
                    {
                        (control as CheckersCheckBox).Click += new EventHandler(validateClick);
                        m_CheckersCheckBoxList.Add(control as CheckersCheckBox);
                    }
                }
            }
        }

        private void initComponents()
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    CheckersCheckBox checkersCheckBox = new CheckersCheckBox();
                    char row = PlaceIndexConvertor.GetSmallCharByIndex(i);
                    char column = PlaceIndexConvertor.GetCapitalCharByIndex(j);
                    checkersCheckBox.Square = new Square(column, row);
                    //this.Controls.Add(checkersCheckBox);
                    if ((i + j) % 2 == 0)
                    {
                        checkersCheckBox.BackColor = System.Drawing.Color.Black;
                        checkersCheckBox.Enabled = false;
                        checkersCheckBox.Top = (i) * 50;
                        checkersCheckBox.Left = (j + 1) * 50;
                        checkersCheckBox.Name = checkersCheckBox.Square.getSquare();
                        checkersCheckBox.Size = new System.Drawing.Size(50, 50);
                        checkersCheckBox.TabIndex = 12;
                        checkersCheckBox.UseVisualStyleBackColor = false;
                        this.Controls.Add(checkersCheckBox);

                    }
                    else
                    {
                        checkersCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
                        checkersCheckBox.BackColor = System.Drawing.Color.White;
                        checkersCheckBox.Top = (i) * 50;
                        checkersCheckBox.Left = (j + 1) * 50;
                        checkersCheckBox.Name = checkersCheckBox.Square.getSquare();
                        checkersCheckBox.Size = new System.Drawing.Size(50, 50);
                        checkersCheckBox.Square = null;
                        checkersCheckBox.TabIndex = 67;
                        if (m_GameManager.Board.BoardArray[i, j] != null)
                            checkersCheckBox.Text = m_GameManager.Board.BoardArray[i, j].Type + "";
                        checkersCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        checkersCheckBox.UseVisualStyleBackColor = false;
                        this.Controls.Add(checkersCheckBox);

                    }
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
                    paintAllInWhite();
                    enableAllButtons();
                    m_CurrentCheckBoxChecked = null;
                }
                else
                {
                    m_CurrentCheckBoxChecked.BackColor = Color.White;
                    CheckersCheckBox checkerCheckBox = (sender as CheckersCheckBox);
                    checkerCheckBox.BackColor = Color.White;
                    m_GameManager.matchManager(m_GameManager.Board, m_CurrentCheckBoxChecked.Name + ">" + checkerCheckBox.Name);
                    moveSoldierInBoard(m_CurrentCheckBoxChecked, checkerCheckBox);
                    paintAllInWhite();
                    enableAllButtons();
                    m_CurrentCheckBoxChecked = null;
                    //validatemove();
                }
            }
        }

        private void enableAllButtons()
        {
            foreach (CheckersCheckBox checkersCheckBox in m_CheckersCheckBoxList)
            {
                checkersCheckBox.Enabled = true;
            }
        }

        private void paintAllInWhite()
        {
            foreach (CheckersCheckBox checkersCheckBox in m_CheckersCheckBoxList)
            {
                checkersCheckBox.BackColor = Color.White;
            }
        }

        private void moveSoldierInBoard (CheckersCheckBox i_MoveFrom, CheckersCheckBox i_MoveTo)
        {
            i_MoveTo.Text = i_MoveFrom.Text;
            i_MoveFrom.Text = string.Empty;
        }
        private void printSoldiers()
        {

            for (int i = 0; i < m_GameManager.Board.BoardArray.GetLength(0); i++)
            {
                for (int j = 0; j < m_GameManager.Board.BoardArray.GetLength(1); j++)
                {
                    if (m_GameManager.Board.BoardArray[i, j] != null)
                    {

                    }
                }
            }
        }
    }
}
