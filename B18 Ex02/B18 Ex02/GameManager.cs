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
        private bool m_WinnerFound = false;
        private Board m_PlayingBoard;

        public static void Main(String[] args)
        {
            initializeMatch();
        }

        public GameManager(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            this.m_FirstPlayer = i_FirstPlayer;
            this.m_SecondPlayer = i_SecondPlayer;
        }


        private static void initializeMatch()
        {

            string boardSize;
            Board PlayingBoard;
            string firstUserName;
            Player firstPlayer;
            Player Computer;

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
            firstPlayer = new Player(firstUserName, 'O', int.Parse(boardSize));
            Computer = new Player("Comp", 'X', int.Parse(boardSize));
            PlayingBoard = new Board(int.Parse(boardSize));

            matchManager(PlayingBoard, firstPlayer, Computer);

            //TODO: remove this 
            Console.WriteLine("Press enter to close terminal");
            Console.ReadLine();
        }

        private static void matchManager(Board i_PlayingBoard, Player i_FirstPlayer, Player i_SecondPlayer)
        {
            i_PlayingBoard.printBoard();
            Board currentBoard = i_PlayingBoard;
            int boardSize = i_PlayingBoard.GetBoardSize();
            bool gameIsOver = false;
            bool isFirstUserTurn = true;
            Coins firstUserCoins = i_FirstPlayer.GetCoins();
            Coins secondUserCoins = i_SecondPlayer.GetCoins();

            while (!gameIsOver)
            {
                if (isFirstUserTurn)
                {
                    gameIsOver = parseUserInput(currentBoard, i_FirstPlayer, i_SecondPlayer);
                    isFirstUserTurn = false;
                }
                else
                {
                    gameIsOver = parseUserInput(currentBoard, i_SecondPlayer, i_FirstPlayer);
                    isFirstUserTurn = true;
                }

                //currentBoard = new Board(boardSize, firstUserCoins, secondUserCoins);
                Ex02.ConsoleUtils.Screen.Clear();
                if (!gameIsOver)
                {
                    currentBoard.printBoard();
                }
                // gameIsOver = currentBoard.gameStatus();
            }
            //TODO: add end game lines 
            //TODO: remove this 

            Console.WriteLine("The game is over");
            Console.ReadLine();
        }

        private static bool parseUserInput(Board i_CurrentBoard, Player i_CurrentPlayer, Player i_OtherPlayer)
        {
            bool isValidMove = false;
            //TODO: should be changed to new move?
            string inputMove;
            PlayerMove parseMove;
            bool currentMoveIsJump = false;
            bool gameIsOver = false;
            bool tryingToQuit = false;
            Coin currentCoin;

            //Coins currentUserCoins = i_CurrentBoard.GetUserCoins(currentUserCoinType);
            //Coins otherUserCoins = i_CurrentBoard.GetOtherUserCoins(currentUserCoinType);


            Console.WriteLine(i_CurrentPlayer.Name + ", it's your turn. Please enter your move");

            inputMove = Console.ReadLine();

            while (!gameIsOver && (!isValidMove || (isValidMove && tryingToQuit)))
            {
                tryingToQuit = InputValidation.IsTryingToQuit(inputMove);
                if (tryingToQuit)
                {
                    //isValidMove = quitHandler(i_CurrentPlayer.Name);
                    if (quitHandler(i_CurrentPlayer.Name))
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
                    isValidMove = InputValidation.inputFormatIsValid(inputMove);
                    if (isValidMove)
                    {
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
                parseMove = new PlayerMove(inputMove);
                Coin[,] boardArray = i_CurrentBoard.BoardArray;
                char currentUserCoinType = boardArray[parseMove.CurrentRowIndex, parseMove.CurrentColIndex].Type;
                currentCoin = i_CurrentBoard.BoardArray[parseMove.CurrentRowIndex, parseMove.CurrentColIndex];
                i_CurrentBoard.MoveCoinInBoard(parseMove);
                if (shouldBeKinged(parseMove, i_CurrentBoard, currentUserCoinType))
                {
                    currentCoin.IsKing = true;
                }

                currentMoveIsJump = currentCoin.IsKing == false ? Validation.IsTryingToJump(parseMove, currentUserCoinType) : KingValidation.isTryingToJump_King(parseMove);
                if (currentMoveIsJump)
                {
                    i_CurrentBoard.EatCoin(parseMove);
                    i_OtherPlayer.CalcUserPoints();
                }
            }

            return gameIsOver;
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
