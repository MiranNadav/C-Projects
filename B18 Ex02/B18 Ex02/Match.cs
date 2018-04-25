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
        public static void Main (String[] args)
        {
            Console.WriteLine("Please enter your name:");
            Console.ReadLine();

            Console.WriteLine("Please enter a valid board size (6,8,10):");
            Console.ReadLine();

            Console.WriteLine("Write 1 if you want to play against another player, 2 if you want to play vs the computer:");
            Console.ReadLine();
            Board b = new Board(8);
            b.printBoard();
        }
        public Match (string i_FirstUserName)
        {
            this.m_FirstUser = new User (i_FirstUserName, 'O');
        }

        private void moveCoin (string i_Movement, User i_CurrentUser)
        {
            if (Validation.LegalMovement(i_Movement))
            {
                this.m_PlayingBoard.moveCoin(i_Movement, i_CurrentUser.CoinType);
            }
        }
    }
}
