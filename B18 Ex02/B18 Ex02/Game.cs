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
        private User m_FirstUser;
        private User m_SecondUser;
        private bool m_WinnerFound = false;
        private Board m_PlayingBoard;

        public static void Main(String[] args)
        {
            string boardSize;
            Board PlayingBoard;
            string firstUserName;
            User firstUser;
            User Computer;

            Console.WriteLine("Please enter your name:");
            //TODO: validate the input of the user
            firstUserName = Console.ReadLine();
            firstUser = new User(firstUserName, 'O');


            for (int i = 0; i < firstUser.GetCoins().getNumOfCoins(); i++)
            {
                Console.WriteLine(firstUser.GetCoins().GetCoin(i).getCurrentSquare());
            }

            Console.WriteLine("Please enter a valid board size (6,8,10):");
            boardSize = Console.ReadLine();
            //TODO: validate the input of the user (tryParse)

            Console.WriteLine("Write 1 if you want to play against another player, 2 if you want to play vs the computer:");
            Console.ReadLine();
            Computer = new User("Comp", 'X');
            PlayingBoard = new Board(int.Parse(boardSize), firstUser, Computer);

            matchManager(PlayingBoard, firstUser, Computer);

            //TODO: remove this 
            Console.WriteLine("Press enter to close terminal");
            Console.ReadLine();
        }

        private static void matchManager(Board i_PlayingBoard, User i_FirstUser, User i_secondUser)
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
                    currentBoard = parseUserInput(currentBoard, i_FirstUser);
                }
                else
                {
                    currentBoard = parseUserInput(currentBoard, i_secondUser); //TODO: need to add another player
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

        private static Board parseUserInput(Board i_CurrentBoard, User i_FirstUser)
        {
            bool isValidMove;
            string currentMove;

            Console.WriteLine(i_FirstUser.UserName + ", it's your turn. Please enter your move");
            currentMove = Console.ReadLine();
            isValidMove = Validation.LegalMovement(currentMove, i_FirstUser);

            while (!(isValidMove))
            {
                Console.WriteLine("The move you entered is illegal. Please enter a different move.");
                currentMove = Console.ReadLine();
                isValidMove = Validation.LegalMovement(currentMove, i_FirstUser);
            }

            //i_CurrentBoard.moveCoin(currentMove, i_FirstUser.CoinType);

            return i_CurrentBoard;
        }

        private User createUsers(string i_UserName, char i_CoinType)
        {
            User user;

            user = new User(i_UserName, i_CoinType);

            return user;
        }

        public Game(string i_FirstUserName)
        {
            this.m_FirstUser = new User(i_FirstUserName, 'O');
        }

        //private void moveCoin(string i_Movement, User i_CurrentUser)
        //{
        //    if (Validation.LegalMovement(i_Movement))
        //    {
        //        this.m_PlayingBoard.moveCoin(i_Movement, i_CurrentUser.CoinType);
        //    }
        //}
    }
}
