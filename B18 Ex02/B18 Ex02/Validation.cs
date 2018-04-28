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
        String currentMove;
        Board currentBoard;
        User currentUser;

        public Validation(String i_CurrentMove, Board i_currentBoard, User i_currentUser)
        {
            currentMove = i_CurrentMove;
            currentBoard = i_currentBoard;
            currentUser = i_currentUser;
        }

        public static bool LegalMovement(String i_CurrentMove, User i_CurrentUser)
        {
            bool isValidMovement = true;

            if (!inputFormatIsValid(i_CurrentMove))
            {
                isValidMovement = false;
            }
            //// Check if the user's square to move from has a coin
            else if (!(i_CurrentUser.squareHasCoin(i_CurrentMove)))
            {
                isValidMovement = false;
            }
            //// Check if the move is diagonal
            //else if (!isDiagonal())
            //{
            //    isValidMovement = false;
            //}

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

        private bool isDiagonal()
        {
            char currentCol = currentMove[0];
            char currentRow = currentMove[1];
            char nextCol = currentMove[3];
            char nextRow = currentMove[4];
            bool isDiagonal = true;

            if (currentUser.CoinType.Equals('O'))
            {
                if (currentCol != nextCol + 1 || currentRow != nextRow + 1)
                {
                    isDiagonal = false;
                }
            }
            else
            {
                if (currentCol != nextCol - 1 || currentRow != nextRow - 1)
                {
                    isDiagonal = false;
                }
            }

            return isDiagonal;
        }
    }
}
