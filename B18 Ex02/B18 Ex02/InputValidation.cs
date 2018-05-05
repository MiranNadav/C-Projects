﻿using System;
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
  

        public static bool inputFormatIsValid(string i_CurrentMove)
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
    }
}