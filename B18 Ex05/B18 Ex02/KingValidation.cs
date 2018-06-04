using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    internal class KingValidation
    {
        public static bool IsValidMove(PlayerMove i_CurrentMove, Player i_CurrentPlayer, Player i_OtherPlayer, Board i_Board)
        {
            bool moveIsValid = true;

            moveIsValid = isDiagonal_King(i_CurrentMove);

            return moveIsValid;
        }

        public static bool isDiagonal_King(PlayerMove currentMove)
        {
            bool moveIsValid = true;
            moveIsValid = MovementValidation.IsDiagonal(currentMove, Constants.k_FirstCoinType);
            if (!moveIsValid)
            {
                moveIsValid = MovementValidation.IsDiagonal(currentMove, Constants.k_SecondCoinType);
            }

            return moveIsValid;
        }

        public static bool isTryingToJump_King(PlayerMove i_CurrentMove)
        {
            bool isTryingToJump = true;

            isTryingToJump = MovementValidation.IsTryingToJump(i_CurrentMove, Constants.k_FirstCoinType);
            if (!isTryingToJump)
            {
                isTryingToJump = MovementValidation.IsTryingToJump(i_CurrentMove, Constants.k_SecondCoinType);
            }

            return isTryingToJump;
        }
    }
}