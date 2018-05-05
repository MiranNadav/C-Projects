using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace B18_Ex02
{
    class InputValidation
    {
        
        public static bool IsTryingToQuit (string i_InputMove)
        {
            return i_InputMove.Equals("Q");
        }
  
        public static bool IsEmptyInput ()
        {
            return false;
        }
        public static bool InputFormatIsValid(string i_CurrentMove)
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
        public static bool IsInputNameValid(string i_Name)
        {
            return (i_Name.Length > 0) && (i_Name.Length <= 20) && (!i_Name.Contains(" "));
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
    }
}
