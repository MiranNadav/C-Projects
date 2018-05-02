using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    class KingValidation
    {
        public static bool IsValidMove(PlayerMove currentMove, Player i_CurrentPlayer, Player i_OtherPlayer, Board i_Board)
        {
            bool moveIsValid = true;

            moveIsValid = isDiagonal_King(currentMove);

            return moveIsValid;
        }

        private static bool isDiagonal_King(PlayerMove currentMove)
        {
            bool moveIsValid = true;

            //By checking if the move is diagonal for both coin types we check is it is diagonal for both front and back move.
            moveIsValid = Validation.isDiagonal(currentMove, 'O');
            if (!moveIsValid)
            {

                moveIsValid = Validation.isDiagonal(currentMove, 'X');
            }

            return moveIsValid;
        }

        private static bool isTryingToJump_King(PlayerMove i_CurrentMove)
        {
            bool isTryingToJump = true;

            isTryingToJump = Validation.IsTryingToJump(i_CurrentMove, 'O');
            if (!isTryingToJump)
            {
                isTryingToJump = Validation.IsTryingToJump(i_CurrentMove, 'X');
            }

            return isTryingToJump;
        }



    }
}