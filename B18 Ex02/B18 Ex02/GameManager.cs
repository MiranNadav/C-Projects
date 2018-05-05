﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace B18_Ex02
{
    class GameManager
    {

        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private Player m_CurrentPlayer;
        private bool m_WinnerFound = false;
        private Board m_PlayingBoard;
        private PossibleMoves m_PossibleMoves;
        private bool m_StartNewMatch = false;

        public void initializeMatch()
        {
            string boardSize;
            string firstUserName;
            string numOfPlayers;
            //Player firstPlayer;
            //Player Computer;


            firstUserName = getInputNameFromUser();

            Console.WriteLine("Please enter a valid board size (6,8,10):");
            boardSize = Console.ReadLine();
            while (!InputValidation.ValidateBoardSizeInput(boardSize))
            {
                Console.WriteLine("Board size is invalid. Please enter one of the following: 6/8/10");
                boardSize = Console.ReadLine();
            }

            m_FirstPlayer = new Player(firstUserName, 'O', int.Parse(boardSize));

            Console.WriteLine("Write 1 if you want to play against another player, 2 if you want to play vs the computer:");
            numOfPlayers = Console.ReadLine();
            while (!int.TryParse(numOfPlayers, out int numOfPlayers_int) || (!(numOfPlayers_int == 1) && !(numOfPlayers_int == 2)))
            {
                Console.WriteLine("The number of players can only be 1 or 2. Please enter one of the following");
                numOfPlayers = Console.ReadLine();
            }

            if (int.Parse(numOfPlayers) == 1)
            {
                m_SecondPlayer = new Player(getInputNameFromUser(), 'X', int.Parse(boardSize));
            }
            else
            {
                m_SecondPlayer = new Player(int.Parse(boardSize));
            }

            m_CurrentPlayer = m_FirstPlayer;

            m_PlayingBoard = new Board(int.Parse(boardSize));
            m_PlayingBoard.printBoard();
            m_PossibleMoves = new PossibleMoves(m_PlayingBoard);

            //// TO DELETE!!!!!!!!!
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Bc>Cd"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Ef>Fe"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Cd>De"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Gf>He"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("De>Ef"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Fg>Gf"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Ef>Fg"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Dg>Ef"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Cb>Bc"));
            //m_PlayingBoard.MoveCoinInBoard(new PlayerMove("Eh>Dg"));
            //m_PlayingBoard.printBoard();

            //// TO DELETE!!!!!!!!!

            matchManager(m_PlayingBoard);

            //TODO: remove this 
            Console.ReadLine();
            Console.WriteLine("Press enter to close terminal");
        }
        private void startNewMatch()
        {
            int boardSize = m_PlayingBoard.BoardSize;
            m_PlayingBoard = new Board(boardSize);
            m_PlayingBoard.printBoard();
            m_PossibleMoves = new PossibleMoves(m_PlayingBoard);
            matchManager(m_PlayingBoard);
        }
        private string getInputNameFromUser()
        {
            Console.WriteLine("Please enter your name:");
            string inputName = Console.ReadLine();
            while (!InputValidation.IsInputNameValid(inputName))
            {
                Console.WriteLine("Your name is invalid! Please tell us your name.");
                inputName = Console.ReadLine();
            }
            return inputName;
        }

        private void matchManager(Board i_PlayingBoard)
        {
            //Board currentBoard = i_PlayingBoard;
            int boardSize = i_PlayingBoard.BoardSize;
            bool gameIsOver = false;
            bool isFirstUserTurn = true;
            //Coins firstUserCoins = i_FirstPlayer.GetCoins();
            //Coins secondUserCoins = i_SecondPlayer.GetCoins();

            Console.WriteLine(m_CurrentPlayer.Name + "'s turn:");

            while (!gameIsOver)
            {
                if (isFirstUserTurn)
                {
                    gameIsOver = parseUserInput(m_FirstPlayer, m_SecondPlayer);
                    isFirstUserTurn = false;
                }
                else
                {
                    gameIsOver = parseUserInput(m_SecondPlayer, m_FirstPlayer);
                    isFirstUserTurn = true;
                }
            }
            if (m_StartNewMatch)
            {
                startNewMatch();
            }
        }

        private bool parseUserInput(Player i_CurrentPlayer, Player i_OtherPlayer)
        {
            bool isValidMove = false;
            string inputMove;
            PlayerMove currentMove;
            bool currentMoveIsJump = false;
            bool gameIsOver = false;
            bool tryingToQuit = false;
            Coin currentCoin;
            ArrayList allPossibleJumps;
            PointsCalculator pointsCalculator;

            m_PossibleMoves = new PossibleMoves(m_PlayingBoard);

            if (!i_CurrentPlayer.IsComputer)
            {
                inputMove = Console.ReadLine();

                while (!gameIsOver && (!isValidMove || (isValidMove && tryingToQuit)))
                {
                    tryingToQuit = InputValidation.IsTryingToQuit(inputMove);
                    if (tryingToQuit)
                    {
                        pointsCalculator = new PointsCalculator(this.m_FirstPlayer, this.m_SecondPlayer, this.m_PlayingBoard);
                        if (quitHandler(i_CurrentPlayer.Name, pointsCalculator))
                        {
                            gameIsOver = true;
                        }
                        else
                        {
                            tryingToQuit = false;
                            inputMove = Console.ReadLine();
                        }
                    }
                    //Not Trying To QUIT
                    else
                    {
                        isValidMove = InputValidation.InputFormatIsValid(inputMove);
                        if (isValidMove)
                        {
                            currentMove = new PlayerMove(inputMove);
                            string errorMessage = Validation.IsLegalMovement(currentMove, m_PlayingBoard);
                            if (!errorMessage.Equals(String.Empty))
                            {
                                isValidMove = false;
                                Console.WriteLine(errorMessage);
                                inputMove = Console.ReadLine();
                            }
                            else
                            {
                                currentCoin = m_PlayingBoard.BoardArray[currentMove.CurrentRowIndex, currentMove.CurrentColIndex];
                                if (!MovementValidation.IsCoinBelongToPlayer(i_CurrentPlayer, currentCoin))
                                {
                                    Console.WriteLine("You are trying to move an opponents coin. Please enter a valid input.");
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
                currentMove = new PlayerMove(inputMove);
            }
            else
            {
                currentMove = RandomMovementGenerator.getRandomMove(m_PossibleMoves.SecondPlayerPossibleMoves);
            }
            Coin[,] boardArray = m_PlayingBoard.BoardArray;
            currentCoin = m_PlayingBoard.BoardArray[currentMove.CurrentRowIndex, currentMove.CurrentColIndex];


            if (!gameIsOver)
            {
                char currentUserCoinType = currentCoin.Type;

                m_PlayingBoard.MoveCoinInBoard(currentMove);

                if (shouldBeKinged(currentMove, m_PlayingBoard, currentUserCoinType))
                {
                    currentCoin.IsKing = true;
                }

                currentMoveIsJump = currentCoin.IsKing == false ? Validation.IsTryingToJump(currentMove, currentUserCoinType) : KingValidation.isTryingToJump_King(currentMove);
                if (currentMoveIsJump)
                {
                    m_PlayingBoard.EatCoin(currentMove);
                    //calcUserPoints(i_OtherPlayer);

                    m_PossibleMoves = new PossibleMoves(m_PlayingBoard);
                    allPossibleJumps = m_PossibleMoves.getAllPossibleJumps(currentMove, currentUserCoinType);

                    while (allPossibleJumps.Count != 0)
                    {
                        Ex02.ConsoleUtils.Screen.Clear();
                        m_PlayingBoard.printBoard();

                        if (!i_CurrentPlayer.IsComputer)
                        {
                            Console.WriteLine(i_CurrentPlayer.Name + ", you can eat more. Please enter another move.");
                            inputMove = Console.ReadLine();
                            isValidMove = InputValidation.InputFormatIsValid(inputMove);
                            while (!isValidMove)
                            {
                                Console.WriteLine(i_CurrentPlayer.Name + ", the input is invalid. eneter a good move please");
                                inputMove = Console.ReadLine();
                                isValidMove = InputValidation.InputFormatIsValid(inputMove);
                                currentMove = new PlayerMove(inputMove);
                            }
                            currentMove = new PlayerMove(inputMove);
                            if (!PossibleMoves.isJumpPossible(allPossibleJumps, currentMove))
                            {
                                Console.WriteLine(i_CurrentPlayer.Name + ", the Move is not a valid jump. eneter a good jump please");
                                isValidMove = false;
                            }
                        }
                        else
                        {
                            currentMove = RandomMovementGenerator.getRandomMove(allPossibleJumps);
                        }

                        m_PlayingBoard.EatCoin(currentMove);
                        //calcUserPoints(i_OtherPlayer);
                        m_PlayingBoard.MoveCoinInBoard(currentMove);
                        allPossibleJumps = m_PossibleMoves.getAllPossibleJumps(currentMove, currentUserCoinType);
                    }
                }
            }

            Ex02.ConsoleUtils.Screen.Clear();
            if (!gameIsOver)
            {
                pointsCalculator = new PointsCalculator(this.m_FirstPlayer, this.m_SecondPlayer, m_PlayingBoard);
                gameIsOver = pointsCalculator.IsWinnerFound();
                if (gameIsOver)
                {
                    startNewGame(pointsCalculator);
                }
                else
                {
                    m_PlayingBoard.printBoard();
                    Console.WriteLine(i_CurrentPlayer.Name + "'s move was: " + currentMove.GetFullMove());
                    Console.WriteLine(i_OtherPlayer.Name + "'s Turn (" + i_OtherPlayer.CoinType + ") :");
                }
            }

            return gameIsOver;
        }


        //private bool isGameOverDueToQuit(string i_InputMove)
        //{
        //    return InputValidation.IsTryingToQuit(i_InputMove) && quitHandler(m_CurrentPlayer.Name);

        //}
        private bool quitHandler(string i_PlayerName, PointsCalculator i_PointsCalculator)
        {
            string playerAnswer;
            bool playerWantsToQuit = false;

            Console.WriteLine(i_PlayerName + ", Do You really want to quit? Y/N");
            playerAnswer = Console.ReadLine();

            while (!playerAnswer.Equals("Y") && !playerAnswer.Equals("N"))
            {
                Console.WriteLine("Invalid answer. Please type Y or N");
                playerAnswer = Console.ReadLine();
            }

            if (playerAnswer.Equals("Y"))
            {
                playerWantsToQuit = true;
                startNewGame(i_PointsCalculator);
            }
            else
            {
                Console.WriteLine(i_PlayerName + ", We are happy to see you are not a loser. Please enter your move");
            }

            return playerWantsToQuit;
        }

        private static bool shouldBeKinged(PlayerMove i_CurrentMove, Board i_CurrentBoard, char i_CurrentCoinType)
        {
            bool turnToKing = false;
            Coin[,] boardArray = i_CurrentBoard.BoardArray;
            Coin currentCoin = boardArray[i_CurrentMove.NextRowIndex, i_CurrentMove.NextColIndex];

            if (currentCoin.IsKing)
            {
                turnToKing = false;
            }
            else
            {
                if (i_CurrentCoinType.Equals('X'))
                {
                    turnToKing = i_CurrentMove.NextRowIndex == 0 ? true : false;
                }
                else
                {
                    turnToKing = i_CurrentMove.NextRowIndex == i_CurrentBoard.BoardSize - 1 ? true : false;
                }
            }

            return turnToKing;
        }

        private void startNewGame(PointsCalculator i_PointsCalculator)
        {
            bool startNewMatch;
            string userInput;
            if (i_PointsCalculator.IsWinnerFound())
            {
                Console.WriteLine(i_PointsCalculator.MatchWinner.Name + ", you won the match!");
            }
            else
            {
                Console.WriteLine("The match ended in a draw");
            }
            Console.WriteLine(this.m_FirstPlayer.Name + "number of total points is: " + i_PointsCalculator.FirstPlayerTotalPoints);
            Console.WriteLine(this.m_SecondPlayer.Name + "number of total points is: " + i_PointsCalculator.SecondPlayerTotalPoints);
            Console.WriteLine("Would you like to start a new match? please answer with Y/N");
            userInput = InputValidation.ValidYesOrNo();
            if (userInput.Equals("Y"))
            {
                startNewMatch = true;
            }
            else
            {
                startNewMatch = false;
            }

            this.m_StartNewMatch = startNewMatch;
        }

        //private void calcUserPoints(Player i_CurrentPlayer)
        //{
        //    int totalPoints = 0;
        //    ArrayList firstUserCoins = m_PlayingBoard.GetUserCoins(i_CurrentPlayer.CoinType);
        //    foreach (Coin coin in firstUserCoins)
        //    {
        //        totalPoints += coin.IsKing ? 4 : 1;
        //    }

        //    i_CurrentPlayer.Points = totalPoints;
        //}
    }
}
