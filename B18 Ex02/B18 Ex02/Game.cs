using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace B18_Ex02
{
    class Game
    {
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private bool m_WinnerFound = false;
        private Board m_PlayingBoard;

        public static void Main(String[] args)
        {
            initializeMatch();
        }

        public Game(Player i_FirstPlayer, Player i_SecondPlayer)
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
            PlayingBoard = new Board(int.Parse(boardSize), firstPlayer.GetCoins(), Computer.GetCoins());

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

                currentBoard = new Board(boardSize, firstUserCoins, secondUserCoins);
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
            bool isValidMove;
            //TODO: should be changed to new move?
            string currentMove;
            string playerAnswer;
            PlayerMove parseMove;
            bool currentMoveIsJump = false;
            bool gameIsOver = false;
            bool tryingToQuit = false;
            char currentUserCoinType = i_CurrentPlayer.CoinType;
            Coins currentUserCoins = i_CurrentBoard.GetUserCoins(currentUserCoinType);
            Coins otherUserCoins = i_CurrentBoard.GetOtherUserCoins(currentUserCoinType);


            Console.WriteLine(i_CurrentPlayer.Name + ", it's your turn. Please enter your move");
            currentMove = Console.ReadLine();
            //currentMove = new PlayerMove(currentMove);
            //isValidMove = Validation.LegalMovement(currentMove, i_CurrentUser, i_CurrentBoard);
            isValidMove = Validation.LegalMovement(currentMove, i_CurrentPlayer, i_OtherPlayer, i_CurrentBoard);
            tryingToQuit = currentMove.Equals("Q") ? true : false;

            while (!(isValidMove) || (isValidMove && tryingToQuit))
            {
                if (!isValidMove)
                {
                    currentMove = Console.ReadLine();
                    isValidMove = Validation.LegalMovement(currentMove, i_CurrentPlayer, i_OtherPlayer, i_CurrentBoard);
                    tryingToQuit = currentMove.Equals("Q") ? true : false;
                }
                else
                {
                    isValidMove = quiteHandler(i_CurrentPlayer.Name);
                    if (isValidMove)
                    {
                        gameIsOver = true;
                    }

                    tryingToQuit = false;
                }
            }


            if (!gameIsOver)
            {
                parseMove = new PlayerMove(currentMove);
                currentMoveIsJump = Validation.IsTryingToJump(parseMove, currentUserCoinType);
                i_CurrentBoard.MoveCoinInBoard(currentMove, i_CurrentPlayer);

                if (currentMoveIsJump)
                {
                    otherUserCoins.EatCoin(currentMove);
                    i_OtherPlayer.CalcUserPoints();
                }
            }

            return gameIsOver;
        }

        private static bool quiteHandler(string i_PlayerName)
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
