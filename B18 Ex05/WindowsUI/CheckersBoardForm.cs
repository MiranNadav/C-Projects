using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using CheckersComponents;
using WindowsUI.Properties;
using B18_Ex02;

namespace WindowsUI
{
    public partial class CheckersBoardForm : Form
    {
        private readonly string r_FirstPlayerName;
        private readonly string r_SecondPlayerName;
        private readonly int r_BoardSize;
        private readonly GameManager r_GameManager;
        private readonly SoundPlayer r_WinningSound;
        private readonly SoundPlayer r_PieceMovingSound;
        private readonly SoundPlayer r_KingSound;
        private CheckersSquare m_CurrentCheckBoxChecked;
        private List<PlayerMove> m_PossibleMoves;
        private List<CheckersSquare> m_NextPossibleSquares;
        private List<CheckersSquare> m_CheckersCheckBoxList;

        public CheckersBoardForm(string i_FirstPlayerName, string i_SecondPlayerName, int i_BoardSize, bool i_IsComputer)
        {
            r_BoardSize = i_BoardSize;
            r_GameManager = new GameManager(r_BoardSize, i_FirstPlayerName, i_SecondPlayerName);
            r_FirstPlayerName = i_FirstPlayerName;
            r_SecondPlayerName = i_SecondPlayerName;
            r_WinningSound = new SoundPlayer(Resources.WinningSound);
            r_PieceMovingSound = new SoundPlayer(Resources.BoardHit);
            r_KingSound = new SoundPlayer(Resources.KingSound);

            if (i_IsComputer)
            {
                r_GameManager.SecondPlayer.IsComputer = true;
            }

            initComponents();
        }

        private void initComponents()
        {
            this.Text = "Damka";
            this.Icon = Resources.IconKing;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += new FormClosingEventHandler(Damka_Closing);
            m_CheckersCheckBoxList = new List<CheckersSquare>();
            m_NextPossibleSquares = new List<CheckersSquare>();
            this.Controls.Clear();
            this.Size = new Size(((r_BoardSize + 2) * 50) + 15, (r_BoardSize + 2) * 50);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.player1Name = new Label();
            this.player1Name.AutoSize = true;
            this.player1Name.Top = 25;
            this.player1Name.Left = (int)(((r_BoardSize / 2) - ((double)r_BoardSize / 4)) * 50);
            this.player1Name.Name = "player1Name";
            this.player1Name.TabIndex = 0;
            this.player1Name.Text = r_FirstPlayerName + ": " + r_GameManager.FirstPlayer.TotalNumberOfPoints;

            this.player2Name = new Label();
            this.player2Name.AutoSize = true;
            this.player2Name.Top = 25;
            this.player2Name.Left = (int)((r_BoardSize - ((double)r_BoardSize / 4)) * 50);
            this.player2Name.Name = "player2Name";
            this.player2Name.TabIndex = 1;
            this.player2Name.Text = r_SecondPlayerName + ": " + r_GameManager.SecondPlayer.TotalNumberOfPoints;

            this.muteSounds = new CheckBox();
            muteSounds.Text = "Mute";
            muteSounds.Top = player1Name.Top - 4;
            muteSounds.Left = player1Name.Left - 70;

            this.Controls.Add(player1Name);
            this.Controls.Add(player2Name);
            this.Controls.Add(muteSounds);

            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    CheckersSquare checkersCheckBox = new CheckersSquare();
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
                        checkersCheckBox.UseVisualStyleBackColor = false;
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

                        if (r_GameManager.Board.BoardArray[i, j] != null)
                        {
                            checkersCheckBox.CoinType = r_GameManager.Board.BoardArray[i, j].CoinType;

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
                    }
                }
            }

            assignCheckersCheckBoxToEvent();
            disableAllNonCurrentPlayerSquares();
        }

        private void Damka_Closing(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void assignCheckersCheckBoxToEvent()
        {
            foreach (Control control in this.Controls)
            {
                if (control is CheckersSquare)
                {
                    if ((control as CheckersSquare).BackColor == Color.White)
                    {
                        (control as CheckersSquare).Click += new EventHandler(validate_Click);
                        m_CheckersCheckBoxList.Add(control as CheckersSquare);
                    }
                }
            }
        }

        private void validate_Click(object sender, EventArgs e)
        {
            m_PossibleMoves = r_GameManager.getAllowedMoves((sender as CheckersSquare).Name);

            if (m_CurrentCheckBoxChecked == null)
            {
                m_CurrentCheckBoxChecked = sender as CheckersSquare;

                disableAllButChecked();
                showAvailableMoves();
            }
            else
            {
                if ((sender as CheckersSquare) == m_CurrentCheckBoxChecked)
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
            CheckersSquare moveTo = sender as CheckersSquare;
            moveTo.BackColor = Color.White;

            PlayerMove currentMove = new PlayerMove(m_CurrentCheckBoxChecked.Name + ">" + moveTo.Name);
            if (MovementValidation.IsTryingToJump(currentMove, m_CurrentCheckBoxChecked.CoinType))
            {
                Square middleSquare = currentMove.calculateMiddleSquare();
                clearSquare(middleSquare);
            }

            r_GameManager.matchManager(currentMove.ToString());
            moveCoinInForm(m_CurrentCheckBoxChecked, moveTo);
            paintAllInWhite();

            if (r_GameManager.NewKingWasMade)
            {
                changeCoinToKing(moveTo);
            }

            if (r_GameManager.ThereAreMoreJumps)
            {
                disableAllButChecked();
            }
            else
            {
                disableAllNonCurrentPlayerSquares();
            }

            playSounds();

            m_CurrentCheckBoxChecked = null;

            playComputerMove();

            if (r_GameManager.GameIsOver)
            {
                gameOverOperation();
            }
        }

        private void playComputerMove()
        {
            while (r_GameManager.CurrentPlayer.IsComputer)
            {
                r_GameManager.matchManager(string.Empty);
                CheckersSquare moveFrom = getCheckersCheckBoxByName(r_GameManager.CurrentMove.CurrentSquare.getSquare());
                CheckersSquare moveTo = getCheckersCheckBoxByName(r_GameManager.CurrentMove.NextSquare.getSquare());

                if (MovementValidation.IsTryingToJump(r_GameManager.CurrentMove, getCheckersCheckBoxByName(r_GameManager.CurrentMove.CurrentSquare.getSquare()).CoinType))
                {
                    Square middleSquare = r_GameManager.CurrentMove.calculateMiddleSquare();
                    clearSquare(middleSquare);
                }

                moveCoinInForm(moveFrom, moveTo);

                if (r_GameManager.NewKingWasMade)
                {
                    changeCoinToKing(moveTo);
                }

                if (r_GameManager.ThereAreMoreJumps)
                {
                    disableAllButChecked();
                }
                else
                {
                    disableAllNonCurrentPlayerSquares();
                }
            }
        }

        private CheckersSquare getCheckersCheckBoxByName(string i_CheckBoxName)
        {
            CheckersSquare foundCheckBox = null;

            foreach (CheckersSquare currentCheckBox in m_CheckersCheckBoxList)
            {
                if (currentCheckBox.Name.Equals(i_CheckBoxName))
                {
                    foundCheckBox = currentCheckBox;
                    break;
                }
            }

            return foundCheckBox;
        }

        private void changeCoinToKing(CheckersSquare squareToMoveTo)
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

        private void gameOverOperation()
        {
            this.player1Name.Text = r_FirstPlayerName + ": " + r_GameManager.FirstPlayer.TotalNumberOfPoints;
            this.player2Name.Text = r_SecondPlayerName + ": " + r_GameManager.SecondPlayer.TotalNumberOfPoints;
            DialogResult shouldStartNewMatch;

            if (r_GameManager.MatchInformation.MatchWinner == null)
            {
                shouldStartNewMatch = ShowTieMessage();
            }
            else
            {
                shouldStartNewMatch = ShowWinnerMessage();
            }

            if (shouldStartNewMatch == DialogResult.Yes)
            {
                r_GameManager.startAnotherMatch();
                initComponents();
                this.Show();
            }
            else if (shouldStartNewMatch == DialogResult.No)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void showAvailableMoves()
        {
            foreach (PlayerMove possibleMove in m_PossibleMoves)
            {
                foreach (Control control in this.Controls)
                {
                    CheckersSquare currentCheckerSquare = control as CheckersSquare;
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

        private void cancelClick()
        {
            paintAllInWhite();
            disableAllNonCurrentPlayerSquares();
            m_CurrentCheckBoxChecked = null;
        }

        private DialogResult ShowWinnerMessage()
        {
            return MessageBox.Show(r_GameManager.MatchInformation.MatchWinner.Name + " Won!" + Environment.NewLine + "Another Round?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private DialogResult ShowTieMessage()
        {
            return MessageBox.Show("Tie!" + Environment.NewLine + "Another Round?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void disableAllNonCurrentPlayerSquares()
        {
            foreach (CheckersSquare currentSquare in m_CheckersCheckBoxList)
            {
                currentSquare.Checked = false;

                if (r_GameManager.CurrentPlayer.Type == Coin.coinType.O)
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

        private void paintAllInWhite()
        {
            foreach (CheckersSquare checkersCheckBox in m_CheckersCheckBoxList)
            {
                checkersCheckBox.BackColor = Color.White;
            }
        }

        private void moveCoinInForm(CheckersSquare i_MoveFrom, CheckersSquare i_MoveTo)
        {
            i_MoveTo.CoinType = i_MoveFrom.CoinType;
            i_MoveFrom.CoinType = null;

            i_MoveTo.BackgroundImage = i_MoveFrom.BackgroundImage;
            i_MoveTo.BackgroundImageLayout = ImageLayout.Stretch;
            i_MoveFrom.BackgroundImage = null;
        }

        private void playSounds()
        {
            if (!this.muteSounds.Checked)
            {
                r_PieceMovingSound.Play();

                if (r_GameManager.NewKingWasMade)
                {
                    r_KingSound.Play();
                }

                if (r_GameManager.GameIsOver)
                {
                    r_WinningSound.Play();
                }
            }
        }

        private void disableAllButChecked()
        {
            foreach (CheckersSquare currentSquare in m_CheckersCheckBoxList)
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
            foreach (CheckersSquare currentSquare in m_CheckersCheckBoxList)
            {
                if (currentSquare.Name.Equals(i_SquareToClear.getSquare()))
                {
                    currentSquare.BackgroundImage = null;
                    currentSquare.CoinType = null;
                }
            }
        }
    }
}