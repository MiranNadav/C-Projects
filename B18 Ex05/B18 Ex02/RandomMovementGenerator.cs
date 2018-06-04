using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    internal class RandomMovementGenerator
    {
        public static PlayerMove getRandomMove(ArrayList i_PossibleMoves)
        {
            return (PlayerMove)i_PossibleMoves[new Random().Next(0, i_PossibleMoves.Count)];
        }
    }
}
