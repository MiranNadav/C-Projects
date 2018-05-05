using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace B18_Ex02
{
    class GameManager
    {
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private Player m_CurrentPlayer;
        private bool m_WinnerFound = false;
        private Board m_PlayingBoard;


        public void initializeMatch()
        {
            string boardSize;
            string firstUserName;
            //Player firstPlayer;
            //Player Computer;

            Console.WriteLine("Please enter your name:");
            firstUserName = Console.ReadLine();
            while (firstUserName.Length == 0)
            {
                Console.WriteLine("Your name cannot be blank. Please tell us your name.");
                firstUserName = Console.ReadLine();
            }


            Console.WriteLine("Please enter a valid board size (6,8,10):");
            boardSize = Console.ReadLine();
            while (!Validation.ValidateBoardSizeInput(boardSize))
            {
                Console.WriteLine("Board size is invalid. Please enter one of the following: 6/8/10");
                boardSize = Console.ReadLine();
            }

            Console.WriteLine("Write 1 if you want to play against another player, 2 if you want to play vs the computer:");
            numOfPlayers = Console.ReadLine();
            while (!int.TryParse(numOfPlayers, out int numOfPlayers_int) || (!(numOfPlayers_int == 1) && !(numOfPlayers_int == 2)))
            {
                Console.WriteLine("The number of players can only be 1 or 2. Please enter one of the following");
                numOfPlayers = Console.ReadLine();
            }

            m_FirstPlayer = new Player(firstUserName, 'O', int.Parse(boardSize));
            m_SecondPlayer = new Player("Comp", 'X', int.Parse(boardSize));
            m_CurrentPlayer = m_FirstPlayer;

            playingBoard = new Board(int.Parse(boardSize));
            playingBoard.printBoard();
            matchManager(playingBoard, firstPlayer, Computer);

            matchManager(PlayingBoard);

            //TODO: remove this 
            Console.WriteLine("Press enter to close terminal");
            Console.ReadLine();
        }

        private void matchManager(Board i_PlayingBoard)
        {
            i_PlayingBoard.printBoard();
            //Board currentBoard = i_PlayingBoard;
            int boardSize = i_PlayingBoard.GetBoardSize();
            bool gameIsOver = false;
            bool isFirstUserTurn = true;
            //Coins firstUserCoins = i_FirstPlayer.GetCoins();
            //Coins secondUserCoins = i_SecondPlayer.GetCoins();


            while (!gameIsOver)
            {
                Console.WriteLine(m_CurrentPlayer.Name + "'s , it's your turn. Please enter your move");
                if (isFirstUserTurn)
                {
                    gameIsOver = parseUserInput(i_PlayingBoard, m_FirstPlayer, m_SecondPlayer);
                    isFirstUserTurn = false;
                }
                else
                {
                    gameIsOver = parseUserInput(i_PlayingBoard, m_SecondPlayer, m_FirstPlayer);
                    isFirstUserTurn = true;
                }

                //currentBoard = new Board(boardSize, firstUserCoins, secondUserCoins);
                Ex02.ConsoleUtils.Screen.Clear();
                if (!gameIsOver)
                {
                    i_PlayingBoard.printBoard();
                    Console.WriteLine();
                }
                // gameIsOver = currentBoard.gameStatus();
            }
            //TODO: add end game lines 
            //TODO: remove this 
        }
        }

        private bool parseUserInput(Board i_CurrentBoard, Player i_CurrentPlayer, Player i_OtherPlayer)
        {
            bool isValidMove = false;
            string inputMove;
            PlayerMove currentMove;
            bool currentMoveIsJump = false;
            bool gameIsOver = false;
            bool tryingToQuit = false;
            Coin currentCoin;


            inputMove = Console.ReadLine();
            currentMove = new PlayerMove(inputMove);
            while (!gameIsOver &&  !isValidMove)//|| (isValidMove && tryingToQuit)))
            {
                gameIsOver = isGameOverDueToQuit(inputMove);
                if (!gameIsOver)
                {
                    inputMove = Console.ReadLine();
                    isValidMove = InputValidation.inputFormatIsValid(currentMove);
                    if (isValidMove)
                    {
                        inputMove = Console.ReadLine();
                        isValidMove = Validation.IsLegalMovement(new PlayerMove(inputMove), i_CurrentPlayer, i_OtherPlayer, i_CurrentBoard);
                        if (!isValidMove)
                        {
                            inputMove = Console.ReadLine();
                        }
                    }
                    else
                    {
                        ErrorPrinter.FormatErrorMessage();
                        inputMove = Console.ReadLine();
                    }
                }
            }

            if (!gameIsOver)
            {
                Coin[,] boardArray = i_CurrentBoard.BoardArray;
                char currentUserCoinType = boardArray[currentMove.CurrentRowIndex, currentMove.CurrentColIndex].Type;
                currentCoin = i_CurrentBoard.BoardArray[currentMove.CurrentRowIndex, currentMove.CurrentColIndex];
                i_CurrentBoard.MoveCoinInBoard(currentMove);

                if (shouldBeKinged(currentMove, i_CurrentBoard, currentUserCoinType))
                {
                    currentCoin.IsKing = true;
                }

                currentMoveIsJump = currentCoin.IsKing == false ? Validation.IsTryingToJump(currentMove, currentUserCoinType) : KingValidation.isTryingToJump_King(currentMove);
                if (currentMoveIsJump)
                {
                    i_CurrentBoard.EatCoin(currentMove);
                    i_OtherPlayer.CalcUserPoints();
                }
            }

            Ex02.ConsoleUtils.Screen.Clear();
            if (!gameIsOver)
            {
                i_CurrentBoard.printBoard();
                Console.WriteLine(i_CurrentPlayer.Name + "'s move was: " + currentMove.GetFullMove());
                Console.WriteLine(i_OtherPlayer.Name + "'s Turn (" + i_OtherPlayer.CoinType + ") :");
            }

            return gameIsOver;
        }

        private bool isGameOverDueToQuit (string i_InputMove)
        {
            return InputValidation.IsTryingToQuit(i_InputMove) && quitHandler(m_CurrentPlayer.Name);
                
        }
        private static bool quitHandler(string i_PlayerName)
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
                    turnToKing = i_CurrentMove.NextRowIndex == i_CurrentBoard.GetBoardSize() - 1 ? true : false;
                }
            }

            return turnToKing;

        }
    }
}
