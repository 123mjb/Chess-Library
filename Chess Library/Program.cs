namespace Chess_Library
{
    internal class ChessBot
    {
        private bool window;
        private string[] boardLayout;
        private bool PlayerMove;
        private string[][] pieces = new string[][] { new string[] { "P", "p" }, new string[] { "K", "k" }, new string[] { "Q", "q" }, new string[] { "N", "n" }, new string[] { "B", "b" }, new string[] { "R", "r" } };
        string getmovepiece(int pieceNum)
        {
            return pieces[pieceNum][PlayerMove ? 0 : 1];
        }
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

            switch (move[0].ToString())
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
                        return 0;
                    case "b":
                        return 1;
                    case "c":
                        return 2;
                    case "d":
                        return 3;
                    case "e":
                        return 4;
                    case "f":
                        return 5;
                    case "g":
                        return 6;
                    case "h":
                        return 7;
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
                if (move.Contains(Convert.ToChar("=")))
                {
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
                            if (Convert.ToInt32(move[2]) > 1)
                            {
                                return MoveCheckerAndDoer(8*num(move[0].ToString()) + Convert.ToInt32(move[2]) - 1, num(move[0].ToString()) + Convert.ToInt32(move[2]) - 1, 0,false);
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }

            }
            bool MoveCheckerAndDoer(int from, int to, int piecenum, bool taking)
            {
                if (!taking)
                {
                    if (boardLayout[from] == getmovepiece(piecenum))
                    {
                        if (boardLayout[to] == "")
                        {
                            boardLayout[from] = "";
                            boardLayout[to] = getmovepiece(0);
                        }
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