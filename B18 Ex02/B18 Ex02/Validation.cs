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
        String i_CurrentMove;
        Board currentBoard;
        User currentUser;

        public Validation(String i_CurrentMove, Board i_currentBoard, User i_currentUser)
        {
            this.i_CurrentMove = i_CurrentMove;
            currentBoard = i_currentBoard;
            currentUser = i_currentUser;
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

        public static bool LegalMovement(String i_CurrentMove, User i_CurrentUser, Board i_Board)
        {
            bool isValidMovement = true;
            string sourceSquare = i_CurrentMove.Substring(0, 2);
            string destinationSquare = i_CurrentMove.Substring(3, 2);
            char currentUserCoinType = i_CurrentUser.CoinType;
            Coins currentCoinsArray = i_Board.GetUserCoins(currentUserCoinType);
            Coins secondCoinsArray = i_Board.GetOtherUserCoins(currentUserCoinType);
            bool tryingToJump = IsTryingToJump(i_CurrentMove, i_CurrentUser.CoinType);

            // checks format of input [A-Z][a-z]>[A-Z][a-z]
            if (!inputFormatIsValid(i_CurrentMove))
            {
                isValidMovement = false;
            }
            // Check if the user's square to move from has a coin
            else if (currentCoinsArray.GetCoinIndex(sourceSquare) == -1)
            {
                isValidMovement = false;
            }
            //checks whether the input is within the board bounds
            else if (!movementInputInRange(i_CurrentMove, i_Board.GetBoardSize()))
            {
                isValidMovement = false;
            }

            else if (tryingToJump == true)
            {
                isValidMovement = isValidJump(i_CurrentMove, i_CurrentUser.CoinType, currentCoinsArray, secondCoinsArray);
            }
            // Checks whether an opponents coin appear in the toSquare
            else if (secondCoinsArray.GetCoinIndex(destinationSquare) != -1)
            {
                isValidMovement = false;
            }
            // Check if the move is diagonal
            else if (!isDiagonal(i_CurrentMove, i_CurrentUser.CoinType))
            {
                isValidMovement = false;
            }


            return isValidMovement;
        }

        private static bool inputFormatIsValid(string i_CurrentMove)
        {
            bool formatIsValid = true;
            Regex regex = new Regex(@"^[A-Z][a-z]>[A-Z][a-z]$");
            Match match = regex.Match(i_CurrentMove);

            if (!(match.Success))
            {
                formatIsValid = false;
            }

            return formatIsValid;
        }

        private static bool movementInputInRange(string i_CurrentMove, int i_BoardSize)
        {
            bool inputIsValid = true;
            char fromColumn = i_CurrentMove[0];
            char fromRow = i_CurrentMove[1];
            char toColumn = i_CurrentMove[3];
            char toRow = i_CurrentMove[3];
            char maxPossibleRow = (char)('a' + (i_BoardSize - 1));
            char maxPossibleColumn = (char)('A' + (i_BoardSize - 1));

            if (fromColumn > maxPossibleColumn || toColumn > maxPossibleColumn || fromRow > maxPossibleRow || toRow > maxPossibleRow)
            {
                inputIsValid = false;
            }

            return inputIsValid;
        }

        private static bool isDiagonal(string i_CurrentMove, char i_CoinType)
        {
            char currentCol = i_CurrentMove[0];
            char currentRow = i_CurrentMove[1];
            char nextCol = i_CurrentMove[3];
            char nextRow = i_CurrentMove[4];
            bool isDiagonal = true;

            if (i_CoinType.Equals('O'))
            {
                isDiagonal = ((nextCol == currentCol + 1 || nextCol == currentCol - 1) && nextRow == currentRow + 1);
            }
            else
            {
                isDiagonal = ((nextCol == currentCol + 1 || nextCol == currentCol - 1) && nextRow == currentRow - 1);
            }

            return isDiagonal;
        }

        private static bool isValidJump(string i_CurrentMove, char i_CoinType, Coins i_CurrentUserCoins, Coins i_OtherUserCoins)
        {
            //TODO: stop duplicating this code.
            char currentCol = i_CurrentMove[0];
            char currentRow = i_CurrentMove[1];
            char nextColumn = i_CurrentMove[3];
            char nextRow = i_CurrentMove[4];
            int opponentCoinIndex;
            char middleSquareCol = (char)((currentCol + nextColumn) / 2);
            char middleSquareRow = (char)((currentRow + nextRow) / 2);
            string possibleOpponentSquare = new string(new char[] { middleSquareCol, middleSquareRow });
            string squareToLandOn = new string(new char[] { nextColumn, nextRow });
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

        public static bool IsTryingToJump(string i_CurrentMove, char i_CoinType)
        {
            char currentColumn = i_CurrentMove[0];
            char currentRow = i_CurrentMove[1];
            char nextColumn = i_CurrentMove[3];
            char nextRow = i_CurrentMove[4];
            bool isJumpByTwoSquares = true;

            if (i_CoinType.Equals('O'))
            {
                isJumpByTwoSquares = (nextRow != currentRow + 2) ? false : true;
            }
            else
            {
                isJumpByTwoSquares = (nextRow != currentRow - 2) ? false : true;
            }

            if (isJumpByTwoSquares)
            {
                isJumpByTwoSquares = (Math.Abs(nextColumn - currentColumn) != 2) ? false : true;
            }

            return isJumpByTwoSquares;
        }
    }
}
