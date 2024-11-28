using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Library
{
    internal class SAN_Tools
    {
        readonly static public string[][] pieces = new string[6][] { new string[2] { "P", "p" }, new string[2] { "K", "k" }, new string[2] { "Q", "q" }, new string[2] { "N", "n" }, new string[2] { "B", "b" }, new string[2] { "R", "r" } };
        readonly static public string[] Ranks = new string[] { "a", "b", "c", "d", "e", "f", "g", "h" };
        readonly static public string[] Files = new string[] { "1", "2", "3", "4", "5", "6", "7", "8" };


        public static string GetMovePiece(int pieceNum,bool PlayerMove)
        {
            return pieces[pieceNum][PlayerMove ? 0 : 1];
        }

        public static int NumForRank(char ForR)
        {
            return ForR.ToString() switch
            {
                "a" => 0,
                "b" => 1,
                "c" => 2,
                "d" => 3,
                "e" => 4,
                "f" => 5,
                "g" => 6,
                "h" => 7,
                _ => -1,
            };
        }

        public static int PieceToNum(char peice)
        {
            return peice.ToString().ToLower() switch
            {
                "p" => 1,
                "k" => 2,
                "q" => 3,
                "n" => 4,
                "b" => 5,
                "r" => 6,
                _ => 0,
            };
        }

    }
}
