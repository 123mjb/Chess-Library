

namespace Chess_Library
{
    internal class ChessBot{
        private bool window;
        private string[] boardLayout;
        private readonly string nameinmoves = "KkNnQqRrBb";

        public ChessBot(string[] pieces, bool testinterface = false)
        {
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
                if (move.Contains(Convert.ToChar("x")))
                {
                    string[] movesplit = move.Split("x");
                }
                else
                {
                    if(move.Length > 2)
                    {

                    }
                    else
                    {
                        if
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

