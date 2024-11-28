using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Library
{
    internal class PawnMovement
    {
        public static bool PawnCheck(string move)
        {
            return SAN_Tools.Ranks.Contains(move[0].ToString()) || SAN_Tools.Files.Contains(move[0].ToString());
        }

        public static bool PawnMove(string[] boardLayout,string move,bool PlayerMove)
        {
            return false;
        }

        public static bool ForwardMove(string move, bool PlayerMove)
        {
            return false;
        }
    }
}
