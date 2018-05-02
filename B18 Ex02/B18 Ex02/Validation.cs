using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace B18_Ex02
{
    class Validation
    {

        public static void printErrorMessage(string i_ErrorMessage)
        {
            Console.WriteLine(i_ErrorMessage);
        }

        public static bool ValidateBoardSizeInput(string i_BoardSize)
        {
            bool boardSizeIsValid = true;

            if (!int.TryParse(i_BoardSize, out int integerBoardSize))
            {
                boardSizeIsValid = false;
            }
            else
            {
                if (integerBoardSize != 6 && integerBoardSize != 8 && integerBoardSize != 10)
                {
                    boardSizeIsValid = false;
                }
            }

            return boardSizeIsValid;
        }

        public static bool IsLegalMovement(PlayerMove currentMove, Player i_CurrentPlayer, Player i_OtherPlayer, Board i_Board)
        {

            bool isValidMovement = true;
            Square sourceSquare;
            Square destinationSquare;
            char currentUserCoinType;

            bool tryingToJump;


            currentUserCoinType = i_CurrentPlayer.CoinType;

            sourceSquare = currentMove.CurrentSquare;
            destinationSquare = currentMove.NextSquare;

            //checks whether the input is within the board bounds
            if (!movementInputInRange(currentMove, i_Board.GetBoardSize()))
            {
                isValidMovement = false;
                ErrorPrinter.OutOfBoundMessage();
                goto endValidation;
            }

            // Check if the user's square to move from has a coin
            else if (i_Board.IsEmptyAtSquare(sourceSquare))
            {
                isValidMovement = false;
                ErrorPrinter.NoCoinToMoveMessage();
                goto endValidation;
            }

            // Checks if the jump is valid 
            if (IsTryingToJump(currentMove, i_CurrentPlayer.CoinType) && !isValidJump(currentMove, i_OtherPlayer.CoinType, i_Board))
            {
                ErrorPrinter.InvalidJumpMessage();
                goto endValidation;
            }

            // Checks whether an opponents coin appear in the toSquare
            else if (!i_Board.IsEmptyAtSquare(destinationSquare))
            {
                isValidMovement = false;
                ErrorPrinter.SquareIsBlockedMessage();
                goto endValidation;
            }
            // Check if the move is diagonal
            else if (!isDiagonal(currentMove, i_CurrentPlayer.CoinType))
            {
                isValidMovement = false;
                ErrorPrinter.NotDiagonalMessage();
                goto endValidation;
            }

            endValidation:
            return isValidMovement;
        }



        public static bool tryingToQuit(Player i_CurrentPlayer, Player i_OtherPlayer)
        {
            int currentPlayerPoints = i_CurrentPlayer.Points;
            int otherPlayerPoints = i_OtherPlayer.Points;

            return currentPlayerPoints < otherPlayerPoints ? true : false;
        }

        //TODO: Fix for different sizes of board
        private static bool movementInputInRange(PlayerMove i_ParseMove, int i_BoardSize)
        {
            bool inputIsValid = true;
            char maxPossibleRow = (char)('a' + (i_BoardSize - 1));
            char maxPossibleColumn = (char)('A' + (i_BoardSize - 1));

            if (i_ParseMove.CurrentColIndex > maxPossibleColumn || i_ParseMove.NextColIndex > maxPossibleColumn ||
                i_ParseMove.CurrentRowIndex > maxPossibleRow || i_ParseMove.NextRowIndex > maxPossibleRow)
            {
                inputIsValid = false;
            }

            return inputIsValid;
        }

        private static bool isDiagonal(PlayerMove i_ParseMove, char i_CoinType)
        {
            bool isDiagonal = true;

            if (i_CoinType.Equals('O'))
            {
                int a = i_ParseMove.NextColIndex;
                isDiagonal = ((i_ParseMove.NextColIndex == i_ParseMove.CurrentColIndex + 1 || i_ParseMove.NextColIndex == i_ParseMove.CurrentColIndex - 1)
                    && i_ParseMove.NextRowIndex == i_ParseMove.CurrentRowIndex + 1);
            }
            else
            {
                isDiagonal = ((i_ParseMove.NextColIndex == i_ParseMove.CurrentColIndex + 1 || i_ParseMove.NextColIndex == i_ParseMove.CurrentColIndex - 1)
                && i_ParseMove.NextRowIndex == i_ParseMove.CurrentRowIndex - 1);
            }

            return isDiagonal;
        }

        private static bool isValidJump(PlayerMove i_ParseMove, char i_CoinType, Board i_Board)
        {
            bool isValidJump = true;

            Square middleSquare = i_ParseMove.calculateMiddleSquare();
            Square squareToLandOn = i_ParseMove.NextSquare;
            
            if (!i_Board.IsEmptyAtSquare(squareToLandOn) || i_Board.IsEmptyAtSquare(middleSquare, i_CoinType))
            {
                isValidJump = false;
            }

            return isValidJump;
        }

        public static bool IsTryingToJump(PlayerMove i_ParseMove, char i_CoinType)
        {
            bool isJumpByTwoSquares = true;

            if (i_CoinType.Equals('O'))
            {
                isJumpByTwoSquares = (i_ParseMove.NextRowIndex != i_ParseMove.CurrentRowIndex + 2) ? false : true;
            }
            else
            {
                isJumpByTwoSquares = (i_ParseMove.NextRowIndex != i_ParseMove.CurrentRowIndex - 2) ? false : true;
            }

            if (isJumpByTwoSquares)
            {
                isJumpByTwoSquares = (Math.Abs(i_ParseMove.CurrentColIndex - i_ParseMove.NextColIndex) != 2) ? false : true;
            }

            return isJumpByTwoSquares;
        }

    }
}
