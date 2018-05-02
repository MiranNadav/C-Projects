using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex02
{
    class PlaceIndexConvertor
    {
        static private char[] m_SmallLetters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        static private char [] m_CapitalLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public static int GetIndexOfLetter (char i_Letter)
        {
            return Char.IsLower(i_Letter) ? Array.IndexOf(m_SmallLetters, i_Letter) : Array.IndexOf(m_CapitalLetters, i_Letter);
        }

        public static char GetSmallCharByIndex (int i_Index)
        {
            return m_SmallLetters[i_Index];
        }

        public static char GetCapitalCharByIndex(int i_Index)
        {
            return m_CapitalLetters[i_Index];
        }

    }
}
