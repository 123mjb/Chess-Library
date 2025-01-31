﻿using System;
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
        readonly static public MoveDetails Basicfalse = new MoveDetails(false);

        public static int MoveNum(string move)
        {
            return NumForFile(move[0]) * 8 + Convert.ToInt32(move[1]);
        }
        public static string GetMovePiece(int pieceNum,bool PlayerMove)
        {
            return pieces[pieceNum][PlayerMove ? 1 : 0];
        }

        public static int NumForFile(char ForR)
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

        public static bool IsFile(string potentialfile)
        {
            if (NumForFile(potentialfile[0]) != -1)
            {
                return true;
            }
            return false;
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
            public readonly Location? From;
            public readonly Location? To;
            public int PieceToBeMovedNum = -1;
            public MoveDetails(bool worked,int from, int to)
            {
                Result = worked;
                From = (Location)from;
                To = (Location)to;
            }
            public MoveDetails(bool worked)
            {
                Result=worked;
            }
            public bool Outcome => Result;

            public static bool operator &(MoveDetails a,MoveDetails b)
            {
                return a.Outcome && b.Outcome;
            }

            public static implicit operator bool (MoveDetails movedetail)
            {
                return movedetail.Outcome;
            }
            
        }
        public class Location : Move
        {
            public Location(int location) : base(location)
            {
                Location = location;
            }
        }

        public class Move
        {
            public int Location;
            public Move(int location)
            {
                Location = location;
            }
            public char File => Files[Math.DivRem(Location, 8).Quotient];
            public int FileNum => Math.DivRem(Location, 8).Quotient;

            public int Rank => Math.DivRem(Location, 8).Remainder;
            public string FileRank => File+Rank.ToString();

            public static Move operator +(Move Move, int change)
            {
                return new Move(Move.Location+change);
            }

            public static explicit operator int(Move move)
            {
                return move.Location;
            }

            public static explicit operator Move(int num)
            {
                return new Move(num);
            }

            public static explicit operator Move(string loc)
            {
                return new Move(MoveNum(loc));
            }
        }
    }
}
