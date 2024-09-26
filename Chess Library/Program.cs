

using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Chess_Library
{
    internal class ChessBot{
        private bool window;
        private string[] boardLayout;
        private bool PlayerMove;

        public ChessBot(string[] pieces, bool testinterface = false)
        {
            PlayerMove = false;
            if (pieces.Length != 64)
            {
                throw new ArgumentException("Pieces is not a standard chess board size of 64.");
            }
            window = testinterface;
            boardLayout = pieces;
        }
        /// <summary>
        /// Method <c>Move</c> tries to do the move supplied.
        /// </summary>
        /// <param name="move">The move in SAN</param>
        /// <returns>Whether the move is valid or not.</returns>
        public bool Move(string move)
        {

            switch(move[0].ToString())
            {
                case "K":
                    KingMove(move);
                    break;
                case "N":
                    KnightMove(move);
                    break;
                default:
                    PawnMove(move);
                    break;
            }
            static int num(string ForR)
            {
                switch (ForR)
                {
                    case "a":
                        return 1;
                    case "b":
                        return 2;
                    case "c":
                        return 3;
                    case "d":
                        return 4;
                    case "e":
                        return 5;
                    case "f":
                        return 6;
                    case "g":
                        return 7;
                    case "h":
                        return 8;
                    default:
                        return -1;
                }
            }
            bool BishopMove(string move)
            {

            }
            bool RookMove(string move)
            {

            }
            bool QueenMove(string move)
            {

            }
            bool KnightMove(string move)
            {

            }
            bool KingMove(string move)
            {

            }
            bool PawnMove(string move)
            {
                if (move.Contains(Convert.ToChar("="))){
                    if (move.Contains(Convert.ToChar("x")))
                    {
                        string[] movesplit = move.Split("x");
                    }
                    else
                    {
                        if (move.Length > 2)
                        {

                        }
                        else
                        {
                            if (Convert.ToInt32(move[2]) > 1) { if (boardLayout[])}
                        }
                    }
                }
                
                if (move.Length > 2)
                {
                    if (move.Contains(Convert.ToChar("x")))
                    {
                        string[] movesplit = move.Split("x");
                    }
                }
                else
                {

                }
            }
        }
    }
}

// & "C:\\Program Files\GitHub Desktop\resources\app\git\cmd\git.exe" config --global http.sslbackend schannel