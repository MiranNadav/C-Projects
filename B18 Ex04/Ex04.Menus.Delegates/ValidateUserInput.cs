using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    class ValidateUserInput
    {
        public static bool IsInputInRange(int i_userChoiceAsInt, int i_MaxValue)
        {
            return i_userChoiceAsInt <= i_MaxValue;
        }
    }
}
