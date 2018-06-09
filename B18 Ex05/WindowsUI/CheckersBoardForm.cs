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
using WindowsUI.Properties;

namespace WindowsUI
{
    public partial class CheckersBoardForm : Form
    {
        string m_FirstPlayerName;
        string m_SecondPlayerName;
        CheckersCheckBox m_CurrentCheckBoxChecked;
        GameManager m_GameManager;
        List<PlayerMove> m_PossibleMoves;
        List<CheckersCheckBox> m_NextPossibleSquares;
        List<CheckersCheckBox> m_CheckersCheckBoxList;
        int m_BoardSize;
        int m_FirstPlayerScore = 0;
        int m_SecondPlayerScore = 0;

        public CheckersBoardForm(string i_FirstPlayerName, string i_SecondPlayerName, int i_BoardSize, bool i_IsComputer)
        {
            m_BoardSize = i_BoardSize;
            m_GameManager = new GameManager(m_BoardSize, i_FirstPlayerName, i_SecondPlayerName);
            m_FirstPlayerName = i_FirstPlayerName;
            m_SecondPlayerName = i_SecondPlayerName;

            if (i_IsComputer)
            {
                m_GameManager.SecondPlayer.IsComputer = true;
            }

            initComponents();

            //List<PlayerMove> possibleMoves = m_GameManager.getAllowedMoves();
            //InitializeComponent();



            //assignCheckersCheckBoxToEvent();
        }

        private void assignCheckersCheckBoxToEvent()
        {
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
            this.Text = "Damka";
            this.Icon = Resources.IconKing;
            m_CheckersCheckBoxList = new List<CheckersCheckBox>();
            m_NextPossibleSquares = new List<CheckersCheckBox>();
            this.Controls.Clear();
            //TODO: this is good for 6 X 6 need to add to other sizes 
            //this.Size = new Size(450, 420);
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.Size = new Size((m_BoardSize + 2) * 50, (m_BoardSize + 2) * 50);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.player1Name = new System.Windows.Forms.Label();
            this.player2Name = new System.Windows.Forms.Label();
            // 
            // player1Name
            // 
            this.player1Name.AutoSize = true;
            this.player1Name.Top = 25;
            this.player1Name.Left = (int)((m_BoardSize / 2 - (double)m_BoardSize / 4) * 50);
            this.player1Name.Name = "player1Name";
            this.player1Name.TabIndex = 0;
            this.player1Name.Text = m_FirstPlayerName + ": " + m_GameManager.FirstPlayer.TotalNumberOfPoints;

            // 
            // player2Name
            // 
            this.player2Name.AutoSize = true;
            this.player2Name.Top = 25;
            this.player2Name.Left = (int)((m_BoardSize - (double)m_BoardSize / 4) * 50);
            this.player2Name.Name = "player2Name";
            this.player2Name.TabIndex = 1;
            this.player2Name.Text = m_SecondPlayerName + ": " + m_GameManager.SecondPlayer.TotalNumberOfPoints;

            this.Controls.Add(player1Name);
            this.Controls.Add(player2Name);

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    CheckersCheckBox checkersCheckBox = new CheckersCheckBox();
                    char row = PlaceIndexConvertor.GetSmallCharByIndex(i);
                    char column = PlaceIndexConvertor.GetCapitalCharByIndex(j);
                    checkersCheckBox.Square = new Square(column, row);
                    this.Controls.Add(checkersCheckBox);
                    if ((i + j) % 2 == 0)
                    {
                        checkersCheckBox.BackColor = System.Drawing.Color.Black;
                        checkersCheckBox.Enabled = false;
                        checkersCheckBox.Top = (i + 1) * 50;
                        checkersCheckBox.Left = (j + 1) * 50;
                        checkersCheckBox.Name = checkersCheckBox.Square.getSquare();
                        checkersCheckBox.Size = new System.Drawing.Size(50, 50);
                        checkersCheckBox.TabIndex = 12;
                        checkersCheckBox.UseVisualStyleBackColor = false;
                        //this.Controls.Add(checkersCheckBox);
                    }
                    else
                    {
                        checkersCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
                        checkersCheckBox.BackColor = System.Drawing.Color.White;
                        checkersCheckBox.Top = (i + 1) * 50;
                        checkersCheckBox.Left = (j + 1) * 50;
                        checkersCheckBox.Name = checkersCheckBox.Square.getSquare();
                        checkersCheckBox.Size = new System.Drawing.Size(50, 50);
                        checkersCheckBox.Square = null;
                        checkersCheckBox.TabIndex = 67;

                        if (m_GameManager.Board.BoardArray[i, j] != null)
                        {
                            //checkersCheckBox.Text = m_GameManager.Board.BoardArray[i, j].Type + "";
                            checkersCheckBox.CoinType = m_GameManager.Board.BoardArray[i, j].CoinType;

                            if (checkersCheckBox.CoinType == Coin.coinType.O)
                            {
                                checkersCheckBox.BackgroundImage = Resources.Chip_Black;
                            }
                            else
                            {
                                checkersCheckBox.BackgroundImage = Resources.Chip_Red;
                            }

                            checkersCheckBox.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        checkersCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        checkersCheckBox.UseVisualStyleBackColor = false;
                        //this.Controls.Add(checkersCheckBox);
                    }
                }
            }

            assignCheckersCheckBoxToEvent();

            disableAllNonCurrentPlayerSquares();

        }
        //TODO: fix bug - checking square twice and disable a green square
        //Current fix: List of next Possible squares, and check if it is not part of the list. 

        private void validateClick(object sender, EventArgs e)
        {
            m_PossibleMoves = m_GameManager.getAllowedMoves((sender as CheckersCheckBox).Name);

            if (m_CurrentCheckBoxChecked == null)
            {
                m_CurrentCheckBoxChecked = sender as CheckersCheckBox;

                disableAllButChecked();
                showAvailableMoves();
            }
            else
            {
                if ((sender as CheckersCheckBox) == m_CurrentCheckBoxChecked)
                {
                    cancelClick();
                }
                else
                {
                    makeMoveInBoard(sender);
                }
            }
        }

        private void makeMoveInBoard(object sender)
        {
            m_CurrentCheckBoxChecked.BackColor = Color.White;
            //m_CurrentCheckBoxChecked.toggleBackgroundImage();
            CheckersCheckBox squareToMoveTo = (sender as CheckersCheckBox);
            squareToMoveTo.BackColor = Color.White;
            //TODO: change name so it is clear that this makes the move in the logic 


            PlayerMove currentMove = new PlayerMove(m_CurrentCheckBoxChecked.Name + ">" + squareToMoveTo.Name);
            if (MovementValidation.IsTryingToJump(currentMove, m_CurrentCheckBoxChecked.CoinType))
            {
                Square middleSquare = currentMove.calculateMiddleSquare();
                clearSquare(middleSquare);
            }

            m_GameManager.matchManager(currentMove.ToString());
            moveSoldierInBoard(m_CurrentCheckBoxChecked, squareToMoveTo);
            paintAllInWhite();

            if (m_GameManager.NewKingWasMade)
            {
                squareToMoveTo.CoinType = squareToMoveTo.CoinType.Equals(Coin.coinType.O) ? Coin.coinType.K : Coin.coinType.U;
                if (squareToMoveTo.CoinType == Coin.coinType.K)
                {
                    squareToMoveTo.BackgroundImage = Resources.King_Black;
                }
                else
                {
                    squareToMoveTo.BackgroundImage = Resources.King_Red;

                }
            }
            if (m_GameManager.ThereAreMoreJumps)
            {
                disableAllButChecked();
            }
            else
            {
                disableAllNonCurrentPlayerSquares();
            }

            m_CurrentCheckBoxChecked = null;

            playComputerMove();

            if (m_GameManager.GameIsOver)
            {
                gameOverOperation();
            }
        }

        private void gameOverOperation()
        {
            this.player1Name.Text = m_FirstPlayerName + ": " + m_GameManager.FirstPlayer.TotalNumberOfPoints;
            this.player2Name.Text = m_SecondPlayerName + ": " + m_GameManager.SecondPlayer.TotalNumberOfPoints;
            DialogResult shouldStartNewMatch;

            if (m_GameManager.MatchInformation.MatchWinner == null)
            {
                shouldStartNewMatch = ShowTieMessage();
            }
            else
            {
                shouldStartNewMatch = ShowWinnerMessage();
            }

            if (shouldStartNewMatch == DialogResult.Yes)
            {
                m_GameManager.startAnotherMatch();
                initComponents();
                this.Show();
            }
            else if (shouldStartNewMatch == DialogResult.No)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void playComputerMove()
        {
            while (m_GameManager.CurrentPlayer.IsComputer)
            {
                m_GameManager.matchManager(string.Empty);
                CheckersCheckBox moveFrom = getCheckersCheckBoxByName(m_GameManager.CurrentMove.CurrentSquare.getSquare());
                CheckersCheckBox moveTo = getCheckersCheckBoxByName(m_GameManager.CurrentMove.NextSquare.getSquare());

                if (MovementValidation.IsTryingToJump(m_GameManager.CurrentMove, getCheckersCheckBoxByName(m_GameManager.CurrentMove.CurrentSquare.getSquare()).CoinType))
                {
                    Square middleSquare = m_GameManager.CurrentMove.calculateMiddleSquare();
                    clearSquare(middleSquare);
                }

                moveSoldierInBoard(moveFrom, moveTo);

                if (m_GameManager.NewKingWasMade)
                {
                    moveTo.CoinType = moveTo.CoinType.Equals(Coin.coinType.O) ? Coin.coinType.K : Coin.coinType.U;
                    if (moveTo.CoinType == Coin.coinType.K)
                    {
                        moveTo.BackgroundImage = Resources.King_Black;
                    }
                    else
                    {
                        moveTo.BackgroundImage = Resources.King_Red;

                    }
                }
                if (m_GameManager.ThereAreMoreJumps)
                {
                    disableAllButChecked();
                }
                else
                {
                    disableAllNonCurrentPlayerSquares();
                }

            }
        }

        private void cancelClick()
        {
            paintAllInWhite();
            //enableAllButtons();
            disableAllNonCurrentPlayerSquares();
            m_CurrentCheckBoxChecked = null;
        }

        private void showAvailableMoves()
        {
            foreach (PlayerMove possibleMove in m_PossibleMoves)
            {
                foreach (Control control in this.Controls)
                {
                    CheckersCheckBox currentCheckerSquare = (control as CheckersCheckBox);
                    if (currentCheckerSquare != null)
                    {
                        //Change string comparison
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

        private DialogResult ShowWinnerMessage()
        {

            return MessageBox.Show(m_GameManager.MatchInformation.MatchWinner.Name + " Won!" + Environment.NewLine + "Another Round?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private DialogResult ShowTieMessage()
        {
            return MessageBox.Show("Tie!" + Environment.NewLine + "Another Round?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        //TODO: check what is the best way to do this
        private void disableAllNonCurrentPlayerSquares()
        {
            foreach (CheckersCheckBox currentSquare in m_CheckersCheckBoxList)
            {

                currentSquare.Checked = false;

                if (m_GameManager.CurrentPlayer.Type == Coin.coinType.O)
                {
                    if (!currentSquare.CoinType.Equals(Coin.coinType.O) && !currentSquare.CoinType.Equals(Coin.coinType.K))
                    {
                        currentSquare.Enabled = false;
                    }
                    else
                    {
                        currentSquare.Enabled = true;
                    }
                }
                else
                {
                    if (!currentSquare.CoinType.Equals(Coin.coinType.X) && !currentSquare.CoinType.Equals(Coin.coinType.U))
                    {
                        currentSquare.Enabled = false;
                    }
                    else
                    {
                        currentSquare.Enabled = true;
                    }
                }
            }
        }

        private void enableAllButtons()
        {
            foreach (CheckersCheckBox currentSquare in m_CheckersCheckBoxList)
            {
                currentSquare.Enabled = true;
            }
        }

        private void paintAllInWhite()
        {
            foreach (CheckersCheckBox checkersCheckBox in m_CheckersCheckBoxList)
            {
                checkersCheckBox.BackColor = Color.White;
            }
        }

        private void moveSoldierInBoard(CheckersCheckBox i_MoveFrom, CheckersCheckBox i_MoveTo)
        {
            //i_MoveFrom.toggleBackgroundImage(null, null);
            //i_MoveTo.Text = i_MoveFrom.Text;
            //i_MoveFrom.Text = string.Empty;
            i_MoveTo.CoinType = i_MoveFrom.CoinType;
            i_MoveFrom.CoinType = null;

            i_MoveTo.BackgroundImage = i_MoveFrom.BackgroundImage;
            i_MoveTo.BackgroundImageLayout = ImageLayout.Stretch;
            i_MoveFrom.BackgroundImage = null;
        }

        private CheckersCheckBox getCheckersCheckBoxByName(string i_CheckBoxName)
        {
            CheckersCheckBox foundCheckBox = null;

            foreach (CheckersCheckBox currentCheckBox in m_CheckersCheckBoxList)
            {
                if (currentCheckBox.Name.Equals(i_CheckBoxName))
                {
                    foundCheckBox = currentCheckBox;
                    break;
                }
            }

            return foundCheckBox;
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

        private void disableAllButChecked()
        {
            foreach (CheckersCheckBox currentSquare in m_CheckersCheckBoxList)
            {
                if (!currentSquare.Checked)
                {
                    currentSquare.Enabled = false;
                }

                currentSquare.Checked = false;
            }
        }

        private void clearSquare(Square i_SquareToClear)
        {
            foreach (CheckersCheckBox currentSquare in m_CheckersCheckBoxList)
            {
                if (currentSquare.Name.Equals(i_SquareToClear.getSquare()))
                {
                    //currentSquare.Text = string.Empty;
                    currentSquare.BackgroundImage = null;
                    currentSquare.CoinType = null;
                }
            }
        }

        private void unCheckAllSqaures()
        {
            foreach (CheckersCheckBox currentSquare in m_CheckersCheckBoxList)
            {
                currentSquare.Checked = false;
            }
        }
    }
}