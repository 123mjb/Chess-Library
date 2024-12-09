using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static SAN_Tools.SAN_Tools;

namespace Chess_Library
{
    internal class PawnMovement
    {
        public static bool PawnCheck(string move)
        {
            return Ranks.Contains(move[0].ToString()) || Files.Contains(move[0].ToString());
        }

        public static bool PawnMove(string[] boardLayout,string move,bool PlayerMove)
        {
            return false;
        }

        public static bool ForwardMove(string[] boardLayout, string move, bool PlayerMove)
        {
            if (move.Contains(Convert.ToChar("x"))){ return false;} // Cant be a forward move if it takes a piece

            if (Ranks.Contains(move[0].ToString())) // if ranks are first then go from there
            {

            }

            if (Files.Contains(move[0].ToString())) // if files are first then across the file behind it based on current player move
            {
                if (PlayerMove) // Black Move
                {
                    int _count = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        if (boardLayout[i * 8 + Convert.ToInt32(move[0]) - 1] == GetMovePiece(0, false))
                        {
                            _count++;
                            if (_count > 1) { return false; }
                        }
                    }
                    
                }
                else // White Move
                {
                    int _count=0;
                    for (int i = 0; i<8; i++)
                    {
                        if (boardLayout[i * 8 + Convert.ToInt32(move[0]) + 1] == GetMovePiece(0, false)) {
                            _count++;
                            if (_count > 1) { return false; }
                        }
                    }
                }
            }


            return false;
        }
    }
}
