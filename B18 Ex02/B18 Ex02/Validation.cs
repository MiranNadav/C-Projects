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

            //if (!boardSizeIsValid)
            //{
            //    printErrorMessage(boardSizeErrorMesege);
            //}

            return boardSizeIsValid;
        }

        public static bool IsLegalMovement(PlayerMove currentMove, Player i_CurrentPlayer, Player i_OtherPlayer, Board i_Board)
        {
            //PlayerMove currentMove;
            bool isValidMovement = true;
            string sourceSquare;
            string destinationSquare;
            char currentUserCoinType;
            Coins currentCoinsArray;
            Coins secondCoinsArray;
            bool tryingToJump;

            //i_ParseMove = new PlayerMove(currentMove.GetFullMove());

            currentUserCoinType = i_CurrentPlayer.CoinType;
            currentCoinsArray = i_Board.GetUserCoins(currentUserCoinType);
            Console.WriteLine(currentCoinsArray.GetCoin(0).Square);
            secondCoinsArray = i_Board.GetOtherUserCoins(currentUserCoinType);
            tryingToJump = IsTryingToJump(currentMove, i_CurrentPlayer.CoinType);
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
            else if (currentCoinsArray.GetCoinIndex(sourceSquare) == -1)
            {
                isValidMovement = false;
                ErrorPrinter.NoCoinToMoveMessage();
                goto endValidation;
            }

            // Checks if the jump is valid 
            if (tryingToJump == true)
            {
                isValidMovement = isValidJump(currentMove, i_CurrentPlayer.CoinType, currentCoinsArray, secondCoinsArray);
                ErrorPrinter.InvalidJumpMessage();
                goto endValidation;
            }

            // Checks whether an opponents coin appear in the toSquare
            else if (secondCoinsArray.GetCoinIndex(destinationSquare) != -1)
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
            bool quitIsValid = false;
            int currentPlayerPoints = i_CurrentPlayer.Points;
            int otherPlayerPoints = i_OtherPlayer.Points;

            quitIsValid = currentPlayerPoints < otherPlayerPoints ? true : false;

            //if (!quitIsValid)
            //{
            //    printErrorMessage(invalidQuitMessage);
            //}

            return quitIsValid;
        }

        private static bool movementInputInRange(PlayerMove i_ParseMove, int i_BoardSize)
        {
            bool inputIsValid = true;
            char maxPossibleRow = (char)('a' + (i_BoardSize - 1));
            char maxPossibleColumn = (char)('A' + (i_BoardSize - 1));

            if (i_ParseMove.CurrentColumn > maxPossibleColumn || i_ParseMove.NextColumn > maxPossibleColumn ||
                i_ParseMove.CurrentRow > maxPossibleRow || i_ParseMove.NextRow > maxPossibleRow)
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
                isDiagonal = ((i_ParseMove.NextColumn == i_ParseMove.CurrentColumn + 1 || i_ParseMove.NextColumn == i_ParseMove.CurrentColumn - 1)
                    && i_ParseMove.NextRow == i_ParseMove.CurrentRow + 1);
            }
            else
            {
                isDiagonal = ((i_ParseMove.NextColumn == i_ParseMove.CurrentColumn + 1 || i_ParseMove.NextColumn == i_ParseMove.CurrentColumn - 1)
                && i_ParseMove.NextRow == i_ParseMove.CurrentRow - 1);
            }

            return isDiagonal;
        }
        private static bool isValidJump(PlayerMove i_ParseMove, char i_CoinType, Coins i_CurrentUserCoins, Coins i_OtherUserCoins)
        {
            int opponentCoinIndex;
            char middleSquareCol = (char)((i_ParseMove.CurrentColumn + i_ParseMove.NextColumn) / 2);
            char middleSquareRow = (char)((i_ParseMove.CurrentRow + i_ParseMove.NextRow) / 2);
            string possibleOpponentSquare = new string(new char[] { middleSquareCol, middleSquareRow });
            string squareToLandOn = new string(new char[] { i_ParseMove.NextColumn, i_ParseMove.NextRow });
            bool isValidJump = true;

            opponentCoinIndex = i_OtherUserCoins.GetCoinIndex(possibleOpponentSquare);
            if (opponentCoinIndex == -1)
            {
                isValidJump = false;
            }
            else if (i_OtherUserCoins.GetCoinIndex(squareToLandOn) != -1 || i_CurrentUserCoins.GetCoinIndex(squareToLandOn) != -1)
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
                isJumpByTwoSquares = (i_ParseMove.NextRow != i_ParseMove.CurrentRow + 2) ? false : true;
            }
            else
            {
                isJumpByTwoSquares = (i_ParseMove.NextRow != i_ParseMove.CurrentRow - 2) ? false : true;
            }

            if (isJumpByTwoSquares)
            {
                isJumpByTwoSquares = (Math.Abs(i_ParseMove.NextColumn - i_ParseMove.CurrentColumn) != 2) ? false : true;
            }

            return isJumpByTwoSquares;
        }


    }
}
