using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    class Validation
    {

        public static bool LegalMovement (string i_Movement)
        {
            bool isValidMovement = true;
            if (i_Movement.Length < 5)
            {
                isValidMovement = false;
            }

            return isValidMovement;
        }
    }
}
