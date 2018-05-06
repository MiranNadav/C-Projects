using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    internal class ErrorMessageGenerator
    {
        private static string s_BoardSizeErrorMessage = "Board size is invalid. Please enter one of the following: 6/8/10";
        private static string s_FormatErrorMessage = "The format of the move you entered is invalid. Please try entering a move in the following format: COLrow>COLrow";
        private static string s_NoCoinToMoveMessage = "The square you want to move from doesn't contains a coin. Please try a different move.";
        private static string s_OutOfBoundsMessage = "The Square you are trying to move to is out of the bounds of the board. Please try a different move";
        private static string s_InvalidJumpMessage = "Invalid jump. Please try a different move";
        private static string s_SquareIsBlockedMessage = "The square you are trying to jump to is blocked. Please try a different move";
        private static string s_NotDiagonalMessage = "You are trying to move a coin not in a diagonal way. Please try a different move";
        private static string s_InvalidQuitMessage = "The number of your points is not lower then your opponent. You cannot quit. Please, enter a move";
        private static string s_TryingToMoveOpponentsCoin = "You are trying to move an opponents coin. Please enter a valid input.";

        public static string BoardSizeErrorMessage()
        {
            return s_BoardSizeErrorMessage;
        }

        public static string FormatErrorMessage()
        {
            return s_FormatErrorMessage;
        }

        public static string NoCoinToMoveMessage()
        {
            return s_NoCoinToMoveMessage;
        }

        public static string OutOfBoundMessage()
        {
            return s_OutOfBoundsMessage;
        }

        public static string InvalidJumpMessage()
        {
            return s_InvalidJumpMessage;
        }

        public static string SquareIsBlockedMessage()
        {
            return s_SquareIsBlockedMessage;
        }

        public static string NotDiagonalMessage()
        {
            return s_NotDiagonalMessage;
        }

        public static string InvalidQuitMessage()
        {
            return s_InvalidQuitMessage;
        }

        public static string TryingToMoveOpponentsCoin()
        {
            return s_TryingToMoveOpponentsCoin;
        }
    }
}
