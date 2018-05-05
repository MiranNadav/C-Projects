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


        //public GameManager(Player i_FirstPlayer, Player i_SecondPlayer)
        //{
        //    this.m_FirstPlayer = i_FirstPlayer;
        //    this.m_SecondPlayer = i_SecondPlayer;
        //}


        public void initializeMatch()
        {

            string boardSize;
            Board PlayingBoard;
            string firstUserName;
            //Player firstPlayer;
            //Player Computer;

            Console.WriteLine("Please enter your name:");
            //TODO: validate the input of the user
            firstUserName = Console.ReadLine();

            Console.WriteLine("Please enter a valid board size (6,8,10):");
            boardSize = Console.ReadLine();
            while (!Validation.ValidateBoardSizeInput(boardSize))
            {
                Console.WriteLine("Board size is invalid. Please enter one of the following: 6/8/10");
                boardSize = Console.ReadLine();
            }

            //TODO: validate this input
            Console.WriteLine("Write 1 if you want to play against another player, 2 if you want to play vs the computer:");
            Console.ReadLine();
            m_FirstPlayer = new Player(firstUserName, 'O', int.Parse(boardSize));
            m_SecondPlayer = new Player("Comp", 'X', int.Parse(boardSize));
            m_CurrentPlayer = m_FirstPlayer;

            PlayingBoard = new Board(int.Parse(boardSize));

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

            Console.WriteLine("The game is over");
            Console.ReadLine();
        }

        private bool parseUserInput(Board i_CurrentBoard, Player i_CurrentPlayer, Player i_OtherPlayer)
        {
            bool isValidMove = false;
            //TODO: should be changed to new move?
            string inputMove;
            PlayerMove parseMove;
            bool currentMoveIsJump = false;
            bool gameIsOver = false;
            bool tryingToQuit = false;
            char currentUserCoinType = i_CurrentPlayer.CoinType;
            //Coins currentUserCoins = i_CurrentBoard.GetUserCoins(currentUserCoinType);
            //Coins otherUserCoins = i_CurrentBoard.GetOtherUserCoins(currentUserCoinType);


            inputMove = Console.ReadLine();

            while (!gameIsOver &&  !isValidMove)//|| (isValidMove && tryingToQuit)))
            {
                gameIsOver = isGameOverDueToQuit(inputMove);
                if (!gameIsOver)
                {
                    inputMove = Console.ReadLine();
                    isValidMove = InputValidation.inputFormatIsValid(inputMove);
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
                        //Validation.printErrorMessage("The format of the move you entered is invalid. Please try entering a move in the following format: COLrow>COLrow");
                        ErrorPrinter.FormatErrorMessage();
                        inputMove = Console.ReadLine();
                    }
                }
            }

            if (!gameIsOver)
            {
                parseMove = new PlayerMove(inputMove);
                currentMoveIsJump = Validation.IsTryingToJump(parseMove, currentUserCoinType);
                i_CurrentBoard.MoveCoinInBoard(parseMove);

                if (currentMoveIsJump)
                {
                    i_CurrentBoard.EatCoin(parseMove);
                    i_OtherPlayer.CalcUserPoints();
                }
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
    }
}
