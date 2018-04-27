using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    class Validation
    {
        String currentMove;

        public Validation(String i_CurrentMove)
        {
            this.currentMove = i_CurrentMove;

        }
        
        //TODO: check with Nadav about this
        public bool isValidMove()
        {
            return LegalMovement();
        }

        private bool LegalMovement()
        {
            bool isValidMovement = true;

            if (currentMove.Length < 5)
            {
                isValidMovement = false;
            }
            
            else if (false)
            {

            }

            return isValidMovement;
        }
    }
}
