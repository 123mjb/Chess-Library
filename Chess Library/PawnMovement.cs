﻿using static SAN_Tools.SAN_Tools;

namespace Chess_Library
{
    internal class PawnMovement
    {
        public static bool PawnCheck(string move)
        {
            return Ranks.Contains(move[0]) || Files.Contains(move[0]);
        }

        public static MoveDetails PawnMove(ChessBoard chessBoard, string move, bool PlayerMove)
        {


        }
        public static MoveDetails UpgradeChecker(ChessBoard chessBoard, string move, bool PlayerMove)
        {
            string[] movesplit = move.Split('=');

            MoveDetails forwardMove = ForwardMove(chessBoard, movesplit[0], PlayerMove);
            if (move.Contains('='))
            {
                if (Math.DivRem(forwardMove.To, 8).Remainder == (PlayerMove ? 8 : 0))
                {
                    forwardMove.PieceToBeMovedNum = PieceToNum(move[^1]);
                }
            }
            if (forwardMove.Outcome())
            {
                return forwardMove;
            }

            MoveDetails diagonalTake = DiagonalTake(chessBoard, movesplit[0], PlayerMove);
            if (Math.DivRem(forwardMove.To, 8).Remainder == (PlayerMove ? 8 : 0))
            {
                forwardMove.PieceToBeMovedNum = PieceToNum(move[^1]);
            }
            if (diagonalTake.Outcome())
            {
                return diagonalTake;
            }



            return new MoveDetails(false);
        }

        public static MoveDetails ForwardMove(ChessBoard chessBoard, string move, bool PlayerMove)
        {
            if (move.Contains('x')) { return new MoveDetails(false); } // Cant be a forward move if it takes a piece

            if (Ranks.Contains(move[0])) // if ranks are first then go from there
            {
                if (PlayerMove) // Black Move
                {
                    int _count = 0;
                    MoveDetails temp = new(false);
                    for (int i = 0; i < 8; i++)
                    {
                        if (chessBoard[i * 8 + Convert.ToInt32(move[0]) - 1] == GetMovePiece(0, false))
                        {
                            temp = new MoveDetails(true, i * 8 + Convert.ToInt32(move[0]) - 1, i * 8 + Convert.ToInt32(move[0]));
                            _count++;
                            if (_count > 1) { return new MoveDetails(false); }
                        }
                    }
                    if (_count == 0) { return new MoveDetails(false); }
                    return temp;

                }
                else // White Move
                {
                    int _count = 0;
                    MoveDetails temp = new(false);
                    for (int i = 0; i < 8; i++)
                    {
                        if (chessBoard[i * 8 + Convert.ToInt32(move[0]) + 1] == GetMovePiece(0, false))
                        {
                            temp = new MoveDetails(true, i * 8 + Convert.ToInt32(move[0]) + 1, i * 8 + Convert.ToInt32(move[0]));
                            _count++;
                            if (_count > 1) { return new MoveDetails(false); }
                        }
                    }
                    if (_count == 0) { return new MoveDetails(false); }
                    return temp;
                }
            }

            if (Files.Contains(move[0])) // if files are first then across the file behind it based on current player move
            {
                if (chessBoard[NumForRank(move[0]) * 8 + Convert.ToInt32(move[1]) + (PlayerMove ? -1 : 1)] == GetMovePiece(0, PlayerMove))
                {
                    return new MoveDetails(true, NumForRank(move[0]) * 8 + Convert.ToInt32(move[1]) + (PlayerMove ? -1 : 1), NumForRank(move[0]) * 8 + Convert.ToInt32(move[1]));
                }
            }

            return new MoveDetails(false);
        }

        public static MoveDetails DiagonalTake(ChessBoard chessBoard, string move, bool PlayerMove)
        {
            if (!move.Contains('x')) { return new MoveDetails(false); }
            string startfile = move.Split('x')[0];
            string endsquare = move.Split('x')[1];


            Move leftloc = new Move(MoveNum(endsquare)) + (PlayerMove ? -9 : -7);
            Move rightloc = new Move(MoveNum(endsquare)) + (PlayerMove ? 7 : 9);
            MoveDetails lessfile = new(false);
            MoveDetails morefile = new(false);
            if (Math.Abs(NumForRank(move[0]) - Math.DivRem((int)leftloc, 8).Quotient) == 1 & (int)leftloc >= 0 & (int)leftloc <= 63) // Black
            {
                if (chessBoard[(int)leftloc] == GetMovePiece(0, PlayerMove))
                {

                    lessfile = new(true, (int)leftloc, MoveNum(move));

                }
            }
            if (Math.Abs(NumForRank(move[0]) - Math.DivRem((int)rightloc, 8).Quotient) == 1 & (int)rightloc >= 0 & (int)rightloc <= 63) // Black
            {
                if (chessBoard[(int)rightloc] == GetMovePiece(0, PlayerMove))
                {
                    morefile = new(true, (int)rightloc, MoveNum(move));
                }
            }
            if (lessfile & morefile)
            {
                return new MoveDetails(false);
            }
            else if (morefile.Outcome)
            {
                return morefile;
            }
            else
            {
                return lessfile;
            }
        }
    }
}
