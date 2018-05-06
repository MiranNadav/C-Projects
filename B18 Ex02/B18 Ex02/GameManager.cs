using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace B18_Ex02
{
    internal class GameManager
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

        public void initializeMatch()
        {
            string numOfPlayers;

            m_InputValidation = new InputValidation();

            this.m_FirstPlayer = new Player(m_InputValidation.getInputNameFromUser(), Constants.k_FirstCoinType);
            m_PlayingBoard = new Board(int.Parse(m_InputValidation.GetBoardSizeFromUser()));
            numOfPlayers = m_InputValidation.GetNumOfPlayersFromUser();

            if (int.Parse(numOfPlayers) == 2)
            {
                m_SecondPlayer = new Player(m_InputValidation.getInputNameFromUser(), Constants.k_SecondCoinType);
            }
            else
            {
                m_SecondPlayer = new Player();
            }

            m_CurrentPlayer = m_FirstPlayer;
            m_PlayingBoard.printBoard();
            m_PossibleMoves = new PossibleMoves(m_PlayingBoard);
            m_MatchInformation = new MatchInformation(m_FirstPlayer, m_SecondPlayer, m_PlayingBoard);

            matchManager(m_PlayingBoard);

            Console.ReadLine();
            Console.WriteLine("Press enter to close terminal");
        }

        private void startAnotherMatch()
        {
            int boardSize = m_PlayingBoard.BoardSize;
            m_PlayingBoard = new Board(boardSize);
            m_PlayingBoard.printBoard();
            m_PossibleMoves = new PossibleMoves(m_PlayingBoard);
            matchManager(m_PlayingBoard);
        }

        private void matchManager(Board i_PlayingBoard)
        {
            int boardSize = i_PlayingBoard.BoardSize;
            bool gameIsOver = false;
            bool isFirstUserTurn = true;

            Console.WriteLine(m_CurrentPlayer.Name + "'s turn:");

            while (!gameIsOver)
            {
                if (isFirstUserTurn)
                {
                    this.m_CurrentPlayer = m_FirstPlayer;
                    gameIsOver = parseUserInput(m_FirstPlayer, m_SecondPlayer);
                    isFirstUserTurn = false;
                }
                else
                {
                    this.m_CurrentPlayer = m_SecondPlayer;
                    gameIsOver = parseUserInput(m_SecondPlayer, m_FirstPlayer);
                    isFirstUserTurn = true;
                }
            }

            if (m_StartNewMatch)
            {
                startAnotherMatch();
            }
            else
            {
                endGameScreen();
            }
        }

        private void endGameScreen()
        {
            string gameWinnerName;
            int firstUserTotalPoints = this.m_FirstPlayer.TotalNumberOfPoints;
            int secondUserTotalPonts = this.m_SecondPlayer.TotalNumberOfPoints;
            currentStatePrinter();

            if (firstUserTotalPoints == secondUserTotalPonts)
            {
                Console.WriteLine("The game ended in a DRAW. GOODBYE");
            }
            else
            {
                gameWinnerName = firstUserTotalPoints > secondUserTotalPonts ? this.m_FirstPlayer.Name : this.m_SecondPlayer.Name;
                Console.WriteLine(gameWinnerName + " Has won the game!!! congratulations " + gameWinnerName, "you are the BEST. GOODBYE");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to close terminal");
            Console.ReadLine();
            Environment.Exit(0);
        }

        private bool parseUserInput(Player i_CurrentPlayer, Player i_OtherPlayer)
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

            if (!this.m_CurrentPlayer.IsComputer)
            {
                inputMove = Console.ReadLine();

                while (!gameIsOver && (!isValidMove || (isValidMove && tryingToQuit)))
                {
                    tryingToQuit = m_InputValidation.IsTryingToQuit(inputMove);
                    allowedToQuit = MovementValidation.IsAllowedToQuit(m_MatchInformation, i_CurrentPlayer, i_OtherPlayer);
                    if (tryingToQuit && !allowedToQuit)
                    {
                        Console.WriteLine(ErrorMessageGenerator.InvalidQuitMessage());
                    }

                    if (tryingToQuit && allowedToQuit)
                    {
                        if (quitHandler(this.m_CurrentPlayer.Name))
                        {
                            gameIsOver = true;
                        }
                        else
                        {
                            tryingToQuit = false;
                            inputMove = Console.ReadLine();
                        }
                    }
                    else
                    {
                        isValidMove = m_InputValidation.InputFormatIsValid(inputMove);
                        if (isValidMove)
                        {
                            this.m_CurrentMove = new PlayerMove(inputMove);
                            string errorMessage = MovementValidation.IsLegalMovement(this.m_CurrentMove, m_PlayingBoard);
                            if (!errorMessage.Equals(string.Empty))
                            {
                                isValidMove = false;
                                Console.WriteLine(errorMessage);
                                inputMove = Console.ReadLine();
                            }
                            else
                            {
                                currentCoin = m_PlayingBoard.BoardArray[this.m_CurrentMove.CurrentRowIndex, this.m_CurrentMove.CurrentColIndex];
                                if (!MovementValidation.IsCoinBelongToPlayer(this.m_CurrentPlayer, currentCoin))
                                {
                                    Console.WriteLine(ErrorMessageGenerator.TryingToMoveOpponentsCoin());
                                    inputMove = Console.ReadLine();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(ErrorMessageGenerator.FormatErrorMessage());
                            inputMove = Console.ReadLine();
                        }
                    }
                }

                this.m_CurrentMove = new PlayerMove(inputMove);
            }
            else
            {
                this.m_CurrentMove = RandomMovementGenerator.getRandomMove(m_PossibleMoves.SecondPlayerPossibleMoves);
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
                }

                currentMoveIsJump = currentCoin.IsKing == false ? MovementValidation.IsTryingToJump(this.m_CurrentMove, currentUserCoinType) : KingValidation.isTryingToJump_King(this.m_CurrentMove);
                if (currentMoveIsJump)
                {
                    m_PlayingBoard.EatCoin(this.m_CurrentMove);

                    m_PossibleMoves = new PossibleMoves(m_PlayingBoard);
                    allPossibleJumps = m_PossibleMoves.getAllPossibleJumps(this.m_CurrentMove, currentUserCoinType);

                    while (allPossibleJumps.Count != 0 && !newKingWasCreated)
                    {
                        Ex02.ConsoleUtils.Screen.Clear();
                        m_PlayingBoard.printBoard();

                        if (!this.m_CurrentPlayer.IsComputer)
                        {
                            Console.WriteLine(this.m_CurrentPlayer.Name + ", you can eat more. Please enter another move.");
                            inputMove = Console.ReadLine();
                            isValidMove = m_InputValidation.InputFormatIsValid(inputMove);
                            while (!isValidMove)
                            {
                                Console.WriteLine(this.m_CurrentPlayer.Name + ", the input is invalid. enter a good move please");
                                inputMove = Console.ReadLine();
                                isValidMove = m_InputValidation.InputFormatIsValid(inputMove);
                                this.m_CurrentMove = new PlayerMove(inputMove);
                            }

                            this.m_CurrentMove = new PlayerMove(inputMove);

                            if (!PossibleMoves.isJumpPossible(allPossibleJumps, this.m_CurrentMove))
                            {
                                Console.WriteLine(this.m_CurrentPlayer.Name + ", the Move is not a valid jump. enter a good jump please");
                                isValidMove = false;
                            }
                        }
                        else
                        {
                            this.m_CurrentMove = RandomMovementGenerator.getRandomMove(allPossibleJumps);
                        }

                        m_PlayingBoard.EatCoin(this.m_CurrentMove);
                        m_PlayingBoard.MoveCoinInBoard(this.m_CurrentMove);
                        m_PossibleMoves = new PossibleMoves(m_PlayingBoard);
                        allPossibleJumps = m_PossibleMoves.getAllPossibleJumps(this.m_CurrentMove, currentUserCoinType);
                    }
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

        private bool quitHandler(string i_PlayerName)
        {
            string playerAnswer;
            bool playerWantsToQuit = false;

            Console.WriteLine(i_PlayerName + ", Do You really want to quit? Y/N");
            playerAnswer = Console.ReadLine();

            while (!playerAnswer.Equals(Constants.k_YesAnswer) && !playerAnswer.Equals(Constants.k_NoAnswer))
            {
                Console.WriteLine("Invalid answer. Please type Y or N");
                playerAnswer = Console.ReadLine();
            }

            if (playerAnswer.Equals(Constants.k_YesAnswer))
            {
                playerWantsToQuit = true;
                endMatch();
                if (m_StartNewMatch)
                {
                    startAnotherMatch();
                }
                else
                {
                    endGameScreen();
                }
            }
            else
            {
                Console.WriteLine(i_PlayerName + ", We are happy to see you are not a loser. Please enter your move");
            }

            return playerWantsToQuit;
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
            bool startNewMatch;
            string userInput;

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
            userInput = m_InputValidation.ValidYesOrNo();

            if (userInput.Equals(Constants.k_YesAnswer))
            {
                startNewMatch = true;
            }
            else
            {
                startNewMatch = false;
            }

            this.m_StartNewMatch = startNewMatch;
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
    }
}
