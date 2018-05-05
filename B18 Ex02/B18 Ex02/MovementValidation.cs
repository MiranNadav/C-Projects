using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    class MovementValidation
    {
        public static bool IsCoinBelongToPlayer(Player i_Player, Coin i_Coin)
        {
            return i_Player.CoinType.Equals(i_Coin.Type);
        }
    }
}
