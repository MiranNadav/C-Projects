using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    class ErrorPrinter
    {
        static private string boardSizeErrorMessage = "Board size is invalid.Please enter one of the following: 6/8/10";
        static private string formatErrorMessage = "The format of the move you entered is invalid. Please try entering a move in the following format: COLrow>COLrow";
        static private string noCoinToMoveMessage = "The square you want to move from doesn't contains a coin. Please try a different move.";
        static private string outOfBoundsMessage = "The Square you are trying to move to is out of the bounds of the board. Please try a different move";
        //TODO: add why the jump is invalid
        static private string invalidJumpMessage = "Invalid jump. Please try a different move";
        static private string squareIsBlockedMessage = "The square you are trying to jump to is blocked. Please try a different move";
        static private string notDiagonalMessage = "You are trying to move a coin not in a diagonal way. Please try a different move";
        static private string invalidQuitMessage = "The number of your points is not lower then your opponent. You cannot quit. Please, enter a move";

        private static void printErrorMessage(string i_ErrorMessage)
        {
            Console.WriteLine(i_ErrorMessage);
        }

        public static void BoardSizeErrorMessage()
        {
            printErrorMessage(boardSizeErrorMessage);
        }

        public static void FormatErrorMessage()
        {
            printErrorMessage(formatErrorMessage);
        }

        public static void NoCoinToMoveMessage()
        {
            printErrorMessage(noCoinToMoveMessage);
        }

        public static void OutOfBoundMessage()
        {
            printErrorMessage(outOfBoundsMessage);
        }

        public static void InvalidJumpMessage()
        {
            printErrorMessage(invalidJumpMessage);
        }

        public static void SquareIsBlockedMessage()
        {
            printErrorMessage(squareIsBlockedMessage);
        }

        public static void NotDiagonalMessage()
        {
            printErrorMessage(notDiagonalMessage);
        }

        public static void InvalidQuitMessage()
        {
            printErrorMessage(invalidQuitMessage);
        }




    }
}
