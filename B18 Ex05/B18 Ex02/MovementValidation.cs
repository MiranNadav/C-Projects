using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    public class MovementValidation
    {
        public static bool IsCoinBelongToPlayer(Player i_Player, Coin i_Coin)
        {
            return i_Player.CoinType.Equals(i_Coin.Type);
        }

        public static string IsLegalMovement(PlayerMove currentMove, Board i_Board)
        {
            bool isValidMovement = true;
            Square sourceSquare;
            Square destinationSquare;
            char currentUserCoinType;
            char otherUserCoinType;
            bool tryingToJump;
            Coin[,] boardArray = i_Board.BoardArray;
            sourceSquare = currentMove.CurrentSquare;
            destinationSquare = currentMove.NextSquare;
            string errorMessage = string.Empty;

            if (!movementIndexesInRange(currentMove, i_Board.BoardSize))
            {
                isValidMovement = false;
                errorMessage = ErrorMessageGenerator.OutOfBoundMessage();
            }
            else
            {
                Coin currentCoin = boardArray[sourceSquare.RowIndex, sourceSquare.ColumnIndex];
                if (i_Board.IsEmptyAtSquare(sourceSquare))
                {
                    isValidMovement = false;
                    errorMessage = ErrorMessageGenerator.NoCoinToMoveMessage();
                }

                if (isValidMovement)
                {
                    currentUserCoinType = currentCoin.Type;
                    otherUserCoinType = currentUserCoinType == Constants.k_FirstCoinType ? Constants.k_SecondCoinType : Constants.k_FirstCoinType;

                    if (!currentCoin.Type.Equals(currentUserCoinType))
                    {
                        isValidMovement = false;
                        errorMessage = ErrorMessageGenerator.NoCoinToMoveMessage();
                    }
                    else if (currentCoin.IsKing)
                    {
                        tryingToJump = KingValidation.isTryingToJump_King(currentMove);
                        if (tryingToJump)
                        {
                            isValidMovement = IsValidJump(currentMove, otherUserCoinType, i_Board);
                            if (!isValidMovement)
                            {
                                errorMessage = ErrorMessageGenerator.InvalidJumpMessage();
                            }
                        }
                        else
                        {
                            if (!i_Board.IsEmptyAtSquare(destinationSquare))
                            {
                                isValidMovement = false;
                                errorMessage = ErrorMessageGenerator.SquareIsBlockedMessage();
                            }
                            else
                            {
                                isValidMovement = KingValidation.isDiagonal_King(currentMove);
                                if (!isValidMovement)
                                {
                                    errorMessage = ErrorMessageGenerator.NotDiagonalMessage();
                                }
                            }
                        }
                    }
                    else if (IsTryingToJump(currentMove, currentUserCoinType))
                    {
                        if (!IsValidJump(currentMove, otherUserCoinType, i_Board))
                        {
                            errorMessage = ErrorMessageGenerator.InvalidJumpMessage();
                        }
                    }
                    else if (!i_Board.IsEmptyAtSquare(destinationSquare))
                    {
                        isValidMovement = false;
                        errorMessage = ErrorMessageGenerator.SquareIsBlockedMessage();
                    }
                    else if (!IsDiagonal(currentMove, currentUserCoinType))
                    {
                        isValidMovement = false;
                        errorMessage = ErrorMessageGenerator.NotDiagonalMessage();
                    }
                }
            }

            return errorMessage;
        }

        public static bool IsAllowedToQuit(MatchInformation i_MatchInformation, Player i_CurrentPlayer, Player i_OtherPlayer)
        {
            int currentPlayerPoints = i_MatchInformation.PlayerPoints(i_CurrentPlayer);
            int otherPlayerPoints = i_MatchInformation.PlayerPoints(i_OtherPlayer);

            return currentPlayerPoints <= otherPlayerPoints;
        }

        private static bool movementIndexesInRange(PlayerMove i_ParseMove, int i_BoardSize)
        {
            return IsMovementIndexesTooBig(i_ParseMove.CurrentColIndex, i_ParseMove.CurrentRowIndex, i_ParseMove.NextColIndex, i_ParseMove.NextRowIndex, i_BoardSize) && IsMovementIndexesTooSmall(i_ParseMove.CurrentColIndex, i_ParseMove.CurrentRowIndex, i_ParseMove.NextColIndex, i_ParseMove.NextRowIndex, i_BoardSize);
        }

        public static bool movementIndexesInRange(int i_CurrentColumnIndex, int i_CurrentRowIndex, int i_NextColumnIndex, int i_NextRowIndex, int i_BoardSize)
        {
            return IsMovementIndexesTooBig(i_CurrentColumnIndex, i_CurrentRowIndex, i_NextColumnIndex, i_NextRowIndex, i_BoardSize) && IsMovementIndexesTooSmall(i_CurrentColumnIndex, i_CurrentRowIndex, i_NextColumnIndex, i_NextRowIndex, i_BoardSize);
        }

        private static bool IsMovementIndexesTooBig(int i_CurrentColumnIndex, int i_CurrentRowIndex, int i_NextColumnIndex, int i_NextRowIndex, int i_BoardSize)
        {
            return !(i_CurrentColumnIndex > (i_BoardSize - 1) || i_NextColumnIndex > (i_BoardSize - 1) || i_CurrentRowIndex > (i_BoardSize - 1) || i_NextRowIndex > (i_BoardSize - 1));
        }

        private static bool IsMovementIndexesTooSmall(int i_CurrentColumnIndex, int i_CurrentRowIndex, int i_NextColumnIndex, int i_NextRowIndex, int i_BoardSize)
        {
            return !(i_CurrentColumnIndex < 0 || i_NextColumnIndex < 0 || i_CurrentRowIndex < 0 || i_NextRowIndex < 0);
        }

        public static bool IsDiagonal(PlayerMove i_ParseMove, char i_CoinType)
        {
            bool isDiagonal = true;

            if (i_CoinType.Equals(Constants.k_FirstCoinType))
            {
                isDiagonal = (i_ParseMove.NextColIndex == i_ParseMove.CurrentColIndex + 1 || i_ParseMove.NextColIndex == i_ParseMove.CurrentColIndex - 1) && i_ParseMove.NextRowIndex == i_ParseMove.CurrentRowIndex + 1;
            }
            else
            {
                isDiagonal = (i_ParseMove.NextColIndex == i_ParseMove.CurrentColIndex + 1 || i_ParseMove.NextColIndex == i_ParseMove.CurrentColIndex - 1) && i_ParseMove.NextRowIndex == i_ParseMove.CurrentRowIndex - 1;
            }

            return isDiagonal;
        }

        public static bool IsValidJump(PlayerMove i_ParseMove, char i_CoinType, Board i_Board)
        {
            bool isValidJump = true;

            Square middleSquare = i_ParseMove.calculateMiddleSquare();
            Square squareToLandOn = i_ParseMove.NextSquare;

            if (!i_Board.IsEmptyAtSquare(squareToLandOn) || !i_Board.IsSquareContainCoinByType(middleSquare, i_CoinType))
            {
                isValidJump = false;
            }

            return isValidJump;
        }

        public static bool IsTryingToJump(PlayerMove i_ParseMove, char i_CoinType)
        {
            bool isJumpByTwoSquares = true;

            if (i_CoinType.Equals(Constants.k_FirstCoinType))
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
