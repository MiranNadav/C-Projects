using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace B18_Ex02
{
    public class GameManager
    {
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private Player m_CurrentPlayer;
        private Board m_PlayingBoard;
        private PossibleMoves m_PossibleMoves;
        private MatchInformation m_MatchInformation;
        private PlayerMove m_CurrentMove;
        private InputValidation m_InputValidation;
        private bool m_StartNewMatch = false;

        private bool m_GameIsOver = false;
        private bool m_ThereAreMoreJumps;
        private bool m_NewKingWasMade;

        public PossibleMoves PossibleMoves
        {
            get { return m_PossibleMoves; }
            set { m_PossibleMoves = value; }
        }

        public Board Board
        {
            get
            {
                return m_PlayingBoard;
            }

            set
            {
                m_PlayingBoard = value;
            }
        }

        public GameManager(int i_BoardSize, string i_FirstPlayerName, string i_SecondPlayerName)
        {
            m_FirstPlayer = new Player(i_FirstPlayerName, 'O');
            m_SecondPlayer = new Player(i_SecondPlayerName, 'X');
            m_PlayingBoard = new Board(i_BoardSize);
            m_MatchInformation = new MatchInformation(m_FirstPlayer, m_SecondPlayer, m_PlayingBoard);
            m_CurrentPlayer = m_FirstPlayer;
            m_PossibleMoves = new PossibleMoves(m_PlayingBoard);
            m_InputValidation = new InputValidation();
        }

        public List<PlayerMove> getAllowedMoves(string i_CurrentSquare)
        {
            List<PlayerMove> currentAllowedMoves = new List<PlayerMove>();
            m_PossibleMoves = new PossibleMoves(m_PlayingBoard);
            ArrayList allPossibleJumps;
            Square currentSquare = new Square(i_CurrentSquare[0], i_CurrentSquare[1]);

            if (m_CurrentPlayer == m_FirstPlayer)
            {
                if (m_ThereAreMoreJumps)
                {
                    allPossibleJumps = m_PossibleMoves.getAllPossibleJumps(currentSquare, m_CurrentPlayer.CoinType);
                    foreach (PlayerMove playerMove in allPossibleJumps)
                    {
                        if (playerMove.CurrentSquare.getSquare() == i_CurrentSquare)
                        {
                            currentAllowedMoves.Add(playerMove);
                        }
                    }
                }
                else
                {
                    foreach (PlayerMove playerMove in m_PossibleMoves.FirstPlayerPossibleMoves)
                    {
                        if (playerMove.CurrentSquare.getSquare() == i_CurrentSquare)
                        {
                            currentAllowedMoves.Add(playerMove);
                        }
                    }
                }
            }
            else
            {
                if (m_ThereAreMoreJumps)
                {
                    allPossibleJumps = m_PossibleMoves.getAllPossibleJumps(currentSquare, m_CurrentPlayer.CoinType);
                    foreach (PlayerMove playerMove in allPossibleJumps)
                    {
                        if (playerMove.CurrentSquare.getSquare() == i_CurrentSquare)
                        {
                            currentAllowedMoves.Add(playerMove);
                        }
                    }
                }
                else
                {
                    foreach (PlayerMove playerMove in m_PossibleMoves.SecondPlayerPossibleMoves)
                    {
                        if (playerMove.CurrentSquare.getSquare() == i_CurrentSquare)
                        {
                            currentAllowedMoves.Add(playerMove);
                        }
                    }
                }
            }

            return currentAllowedMoves;
        }

        public void startAnotherMatch()
        {
            m_GameIsOver = false;
            int boardSize = m_PlayingBoard.BoardSize;
            m_PlayingBoard = new Board(boardSize);
            m_CurrentPlayer = m_FirstPlayer;
            m_PossibleMoves = new PossibleMoves(m_PlayingBoard);
            m_InputValidation = new InputValidation();
        }

        public void matchManager(string i_Move)
        {
            bool gameIsOver = false;
            if (m_CurrentPlayer.CoinType == 'O')
            {
                m_CurrentPlayer = m_FirstPlayer;
                gameIsOver = parseUserInput(m_FirstPlayer, m_SecondPlayer, i_Move);
                if (!m_ThereAreMoreJumps && !gameIsOver)
                {
                    m_CurrentPlayer = m_SecondPlayer;
                }
            }
            else
            {
                m_CurrentPlayer = m_SecondPlayer;
                gameIsOver = parseUserInput(m_SecondPlayer, m_FirstPlayer, i_Move);
                if (!m_ThereAreMoreJumps)
                {
                    m_CurrentPlayer = m_FirstPlayer;
                }
            }
        }

        private bool parseUserInput(Player i_CurrentPlayer, Player i_OtherPlayer, string i_Move)
        {
            bool isValidMove = false;
            string inputMove;
            bool currentMoveIsJump = false;     
            bool gameIsOver = false;
            bool tryingToQuit = false;
            bool allowedToQuit = false;
            bool newKingWasCreated = false;
            Coin currentCoin;
            ArrayList allPossibleJumps;

            m_PossibleMoves = new PossibleMoves(m_PlayingBoard);

            inputMove = i_Move;

            if (!this.m_CurrentPlayer.IsComputer)
            {
                while (!gameIsOver && (!isValidMove || (isValidMove && tryingToQuit)))
                {
                    tryingToQuit = m_InputValidation.IsTryingToQuit(inputMove);
                    allowedToQuit = MovementValidation.IsAllowedToQuit(m_MatchInformation, i_CurrentPlayer, i_OtherPlayer);
                    if (tryingToQuit && !allowedToQuit)
                    {
                        Console.WriteLine(ErrorMessageGenerator.InvalidQuitMessage());
                    }

                    isValidMove = m_InputValidation.InputFormatIsValid(inputMove);
                    if (isValidMove)
                    {
                        this.m_CurrentMove = new PlayerMove(inputMove);
                        string errorMessage = MovementValidation.IsLegalMovement(this.m_CurrentMove, m_PlayingBoard);
                        if (!errorMessage.Equals(string.Empty))
                        {
                            isValidMove = false;
                            Console.WriteLine(errorMessage);
                        }
                        else
                        {
                            currentCoin = m_PlayingBoard.BoardArray[this.m_CurrentMove.CurrentRowIndex, this.m_CurrentMove.CurrentColIndex];
                            if (!MovementValidation.IsCoinBelongToPlayer(this.m_CurrentPlayer, currentCoin))
                            {
                                Console.WriteLine(ErrorMessageGenerator.TryingToMoveOpponentsCoin());
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(ErrorMessageGenerator.FormatErrorMessage());
                    }
                }

                this.m_CurrentMove = new PlayerMove(inputMove);
            }
            else
            {
                if (m_ThereAreMoreJumps)
                {
                    this.m_CurrentMove = RandomMovementGenerator.getRandomMove(m_PossibleMoves.getAllPossibleJumps(this.m_CurrentMove, 'X'));
                }
                else
                {
                    this.m_CurrentMove = RandomMovementGenerator.getRandomMove(m_PossibleMoves.SecondPlayerPossibleMoves);
                }
            }

            Coin[,] boardArray = m_PlayingBoard.BoardArray;
            currentCoin = m_PlayingBoard.BoardArray[this.m_CurrentMove.CurrentRowIndex, this.m_CurrentMove.CurrentColIndex];

            if (!gameIsOver)
            {
                char currentUserCoinType = currentCoin.Type;
                m_PlayingBoard.MoveCoinInBoard(this.m_CurrentMove);

                if (shouldBeKinged())
                {
                    currentCoin.IsKing = true;
                    newKingWasCreated = true;
                    m_NewKingWasMade = true;
                }
                else
                {
                    m_NewKingWasMade = false;
                }

                currentMoveIsJump = currentCoin.IsKing == false ? MovementValidation.IsTryingToJump(this.m_CurrentMove, Convert.ToString(currentUserCoinType)) : KingValidation.isTryingToJump_King(this.m_CurrentMove);

                if (currentMoveIsJump)
                {
                    m_PlayingBoard.EatCoin(this.m_CurrentMove);
                    
                    m_PossibleMoves = new PossibleMoves(m_PlayingBoard);
                    allPossibleJumps = m_PossibleMoves.getAllPossibleJumps(this.m_CurrentMove, currentUserCoinType);

                    if (allPossibleJumps.Count != 0 && !newKingWasCreated)
                    {
                        m_ThereAreMoreJumps = true;
                    }
                    else
                    {
                        m_ThereAreMoreJumps = false;
                    }
                }
                else
                {
                    m_ThereAreMoreJumps = false;
                }
            }

            if (shouldBeKinged())
            {
                currentCoin.IsKing = true;
                newKingWasCreated = true;
            }

            Ex02.ConsoleUtils.Screen.Clear();
            if (!gameIsOver)
            {
                this.m_MatchInformation = new MatchInformation(this.m_FirstPlayer, this.m_SecondPlayer, m_PlayingBoard);
                gameIsOver = this.m_MatchInformation.IsWinnerFound();
                if (gameIsOver)
                {
                    m_GameIsOver = true;
                    endMatch();
                }
                else
                {
                    m_PlayingBoard.printBoard();
                    Console.WriteLine(this.m_CurrentPlayer.Name + "'s move was: " + this.m_CurrentMove.GetFullMove());
                    Console.WriteLine(i_OtherPlayer.Name + "'s Turn (" + i_OtherPlayer.CoinType + ") :");
                }
            }

            return gameIsOver;
        }

        private bool shouldBeKinged()
        {
            bool turnToKing = false;
            Coin[,] boardArray = this.m_PlayingBoard.BoardArray;
            Coin currentCoin = boardArray[this.m_CurrentMove.NextRowIndex, this.m_CurrentMove.NextColIndex];
            char currentPlayerCoinType = this.m_CurrentPlayer.CoinType;

            if (currentCoin.IsKing)
            {
                turnToKing = false;
            }
            else
            {
                if (currentPlayerCoinType.Equals(Constants.k_SecondCoinType))
                {
                    turnToKing = this.m_CurrentMove.NextRowIndex == 0 ? true : false;
                }
                else
                {
                    turnToKing = this.m_CurrentMove.NextRowIndex == this.m_PlayingBoard.BoardSize - 1 ? true : false;
                }
            }

            return turnToKing;
        }

        private void endMatch()
        {
            calcTotalPoints();

            if (this.m_MatchInformation.IsWinnerFound())
            {
                Console.WriteLine(this.m_MatchInformation.MatchWinner.Name + ", you won the match!");
            }
            else
            {
                Console.WriteLine("The match ended in a draw");
            }

            currentStatePrinter();
            m_CurrentPlayer = m_FirstPlayer;
            Console.WriteLine("Would you like to start a new match? please answer with Y/N");

            this.m_StartNewMatch = false;
        }

        private void calcTotalPoints()
        {
            if (m_MatchInformation.IsWinnerFound())
            {
                this.m_MatchInformation.MatchWinner.TotalNumberOfPoints += Math.Abs(this.m_MatchInformation.FirstPlayerCurrentPoints - this.m_MatchInformation.SecondPlayerCurrentPoints);
            }
        }

        private void currentStatePrinter()
        {
            Console.WriteLine(this.m_FirstPlayer.Name + "'s number of total points is: " + this.m_FirstPlayer.TotalNumberOfPoints);
            Console.WriteLine(this.m_SecondPlayer.Name + "s' number of total points is: " + this.m_SecondPlayer.TotalNumberOfPoints);
        }

        public PlayerMove CurrentMove
        {
            get
            {
                return m_CurrentMove;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }

            set
            {
                m_CurrentPlayer = value;
            }
        }

        public bool ThereAreMoreJumps
        {
            get
            {
                return m_ThereAreMoreJumps;
            }
        }

        public bool NewKingWasMade
        {
            get
            {
                return m_NewKingWasMade;
            }
        }

        public Player FirstPlayer
        {
            get
            {
                return m_FirstPlayer;
            }

            set
            {
                m_FirstPlayer = value;
            }
        }

        public Player SecondPlayer
        {
            get
            {
                return m_SecondPlayer;
            }

            set
            {
                m_SecondPlayer = value;
            }
        }

        public bool GameIsOver
        {
            get
            {
                return m_GameIsOver;
            }

            set
            {
                m_GameIsOver = value;
            }
        }

        public MatchInformation MatchInformation
        {
            get
            {
                return m_MatchInformation;
            }
        }
    }
}
