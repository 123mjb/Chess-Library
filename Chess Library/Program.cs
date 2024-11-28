namespace Chess_Library
{
    internal class ChessBot
    {
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

            return PawnMovement.PawnCheck(move);
            bool MoveCheckerAndDoer(int from, int to, int piecenum,int topiecenum, bool taking)
            {
                if (!taking)
                {
                    if (boardLayout[from] == SAN_Tools.GetMovePiece(piecenum,PlayerMove))
                    {
                        if (boardLayout[to] == "")
                        {
                            boardLayout[from] = "";
                            boardLayout[to] = SAN_Tools.GetMovePiece(0,PlayerMove);
                        }
                        else { return false; }
                    }
                    else { return false; }
                }
                else
                {
                    return false;
                }
                return true;
            }

        }
    }
}

// & "C:\\Program Files\GitHub Desktop\resources\app\git\cmd\git.exe" config --global http.sslbackend schannel