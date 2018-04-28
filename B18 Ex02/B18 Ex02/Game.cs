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
        //private User m_FirstUser;
        //private User m_SecondUser;
        //private bool m_WinnerFound = false;
        //private Board m_PlayingBoard;

        public static void Main(String[] args)
        {
            playMatch();
        }
        private static void playMatch()
        {
            string firstUserName;
            string boardSize;
            int intBoardSize;
            Board PlayingBoard;
            User firstUser;
            User Computer;

            Console.WriteLine("Please enter your name:");
            //TODO: validate the input of the user
            firstUserName = Console.ReadLine();

            /*
             * Board size
             */
            Console.WriteLine("Please enter a valid board size (6,8,10):");
            boardSize = Console.ReadLine();
            while (!Validation.ValidateBoardSizeInput(boardSize))
            {
                Console.WriteLine("Invalid board size. Please enter one of the following 6/8/10!");
                boardSize = Console.ReadLine();
            }
            intBoardSize = int.Parse(boardSize);

            /*
             * Create users (computer or second user)
             */
            firstUser = new User(firstUserName, 'O', intBoardSize);
            Console.WriteLine("Write 1 if you want to play against another player, 2 if you want to play vs the computer:");
            Console.ReadLine();
            Computer = new User("Comp", 'X', intBoardSize);
            
            /*
             * create a clean board for match
             */
            PlayingBoard = new Board(int.Parse(boardSize));

            matchManager(PlayingBoard, firstUser, Computer);

            //TODO: remove this 
            Console.WriteLine("Press enter to close terminal");
            Console.ReadLine();
        }
        private static void matchManager(Board i_PlayingBoard, User i_FirstUser, User i_SecondUser)
        {
            i_PlayingBoard.printBoard();
            Board currentBoard = i_PlayingBoard;
            bool gameIsOver;
            gameIsOver = false;
            bool isFirstUserTurn = true;

            while (!gameIsOver)
            {
                if (isFirstUserTurn)
                {
                    parseUserInput(currentBoard, i_FirstUser);
                    isFirstUserTurn = false;
                }
                else
                {
                    parseUserInput(currentBoard, i_SecondUser); //TODO: need to add another player
                    isFirstUserTurn = true;
                }

                Ex02.ConsoleUtils.Screen.Clear();
                currentBoard.printBoard();
                gameIsOver = currentBoard.gameStatus();
            }


            //TODO: add end game lines 
            //TODO: remove this 

            Console.WriteLine("The game is over");
            Console.ReadLine();
        }

        private static void parseUserInput(Board i_Board, User i_CurrentUser)
        {
            bool isValidMove = false;
            bool moveIsJump = false;
            char currentUserCoinType = i_CurrentUser.CoinType;
            Coins currentUserCoins = i_Board.GetUserCoins(currentUserCoinType);
            Coins otherUserCoins = i_Board.GetOtherUserCoins(currentUserCoinType);
            string currentMove;
            
            Console.WriteLine(i_CurrentUser.UserName + ", it's your turn. Please enter your move");
            currentMove = Console.ReadLine();
            isValidMove = Validation.LegalMovement(currentMove, i_CurrentUser, i_Board);
           
            while (!(isValidMove))
            {
                Console.WriteLine("The move you entered is illegal. Please enter a different move.");
                currentMove = Console.ReadLine();
                isValidMove = Validation.LegalMovement(currentMove, i_CurrentUser, i_Board);
            }

            i_Board.MoveCoinInBoard(currentMove, i_CurrentUser);
            moveIsJump = Validation.IsTryingToJump(currentMove, i_CurrentUser.CoinType);

            if (moveIsJump)
            {
                otherUserCoins.EatCoin(currentMove);
            }
            Console.WriteLine(otherUserCoins.ToString());

        }

        //private User createUsers(string i_UserName, char i_CoinType)
        //{
        //    User user;

        //    user = new User(i_UserName, i_CoinType);

        //    return user;
        //}

        //public Game(string i_FirstUserName)
        //{
        //    this.m_FirstUser = new User(i_FirstUserName, 'O');
        //}

        //private void moveCoin(string i_Movement, User i_CurrentUser)
        //{
        //    if (Validation.LegalMovement(i_Movement))
        //    {
        //        this.m_PlayingBoard.moveCoin(i_Movement, i_CurrentUser.CoinType);
        //    }
        //}
    }
}
