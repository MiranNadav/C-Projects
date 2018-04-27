using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    class Match
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
            User FirstUser;

            Console.WriteLine("Please enter your name:");
            //TODO: validate the input of the user
            firstUserName = Console.ReadLine();
            FirstUser = new User(firstUserName, 'O');

            Console.WriteLine("Please enter a valid board size (6,8,10):");
            boardSize = Console.ReadLine();
            //TODO: validate the input of the user (tryParse)
            PlayingBoard = new Board(int.Parse(boardSize));

            Console.WriteLine("Write 1 if you want to play against another player, 2 if you want to play vs the computer:");
            Console.ReadLine();

            matchManager(PlayingBoard, FirstUser);

            //TODO: remove this 
            Console.WriteLine("Press enter to close terminal");
            Console.ReadLine();
        }

        private static void matchManager(Board i_PlayingBoard, User i_FirstUser)
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
                    currentBoard = parseUserInput(currentBoard, i_FirstUser); //TODO: need to add another player
                }
                Ex02.ConsoleUtils.Screen.Clear();
                i_PlayingBoard.printBoard();
                gameIsOver = currentBoard.gameStatus();
            }
            //TODO: add end game lines 

        }

        private static Board parseUserInput(Board i_PlayingBoard, User i_FirstUser)
        {
            i_PlayingBoard.printBoard();
            bool isValidMove;
            string currentMove;
            Validation moveValidation;

            Console.WriteLine(i_FirstUser.UserName + ", it's your turn. Please enter your move");
            currentMove = Console.ReadLine();
            moveValidation = new Validation(currentMove);
            isValidMove = moveValidation.isValidMove();

            while (!(isValidMove))
            {
                Console.WriteLine("The move you entered is illegal. Please enter a different move.");
                currentMove = Console.ReadLine();
                isValidMove = moveValidation.isValidMove();
            }

            i_PlayingBoard.moveCoin(currentMove, i_FirstUser.CoinType);

            return i_PlayingBoard;
        }

        private User createUsers(string i_UserName, char i_CoinType)
        {
            User user;

            user = new User(i_UserName, i_CoinType);

            return user;
        }

        public Match(string i_FirstUserName)
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
