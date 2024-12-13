using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAN_Tools
{
    internal class SAN_Tools
    {
        readonly static public string[][] pieces = new string[6][] { new string[2] { "P", "p" }, new string[2] { "K", "k" }, new string[2] { "Q", "q" }, new string[2] { "N", "n" }, new string[2] { "B", "b" }, new string[2] { "R", "r" } };
        readonly static public char[] Files = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        readonly static public char[] Ranks = new char[] { '1', '2', '3', '4', '5', '6', '7', '8' };

        public static int MoveNum(string move)
        {
            return NumForRank(move[0]) * 8 + Convert.ToInt32(move[1]);
        }
        public static string GetMovePiece(int pieceNum,bool PlayerMove)
        {
            return pieces[pieceNum][PlayerMove ? 1 : 0];
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

        public class ChessBoard
        {
            private string[] Board;
            public ChessBoard(string[] peices)
            {
                Board = peices;
            }
            public string[] ToArray()
            {
                return Board;
            }
            
            public void Set(int place, string piece)
            {
                Board[place] = piece;
            }
            public string this[int index]
            {
                get { return Board[index]; }
            }
        }

        public class MoveDetails
        {
            private readonly bool Result;
            public readonly int From;
            public readonly int To;
            public int PieceToBeMovedNum = -1;
            public MoveDetails(bool worked,int from, int to)
            {
                Result = worked;
                From = from;
                To = to;
            }
            public MoveDetails(bool worked)
            {
                Result=worked;
            }
            public bool Outcome()
            {
                return Result;
            }
            
        }
    }
}
