namespace Chess_Library
{
    internal class ChessBot
    {
        private bool window;
        private string[] boardLayout;
        private bool PlayerMove;
        private string[][] pieces = new string[6][] { new string[2] { "P", "p" }, new string[2] { "K", "k" }, new string[2] { "Q", "q" }, new string[2] { "N", "n" }, new string[2] { "B", "b" }, new string[2] { "R", "r" } };
        int piecetonum(char peice)
        {
            switch (peice.ToString().ToLower())
            {
                case "p":
                    return 1;
                case "k":
                    return 2;
                case "q":
                    return 3;
                case "n":
                    return 4;
                case "b":
                    return 5;
                case "r":
                    return 6;
                default : return 0;

            }
        }
        string numberToNot(int numloc)
        {

        }
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
            static int num(char ForR)
            {
                switch (ForR.ToString())
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
                int from, to, piecenum,topiecenum;
                bool take=false;
                if (move.Contains(Convert.ToChar("="))){
                    topiecenum = piecetonum(move.Split('=')[1][0]);
                }
                if (move.Contains(Convert.ToChar("x"))) {
                    string[] sects = move.Split('x');
                    sects[1] = sects[1].Split('=')[0];
                    take = true;
                    to = 8*num(sects[1][0])+Convert.ToInt32(sects[1][1]);
                    if (Convert.ToInt32(sects[1][1]) > 0)
                    {
                        if (sects[0] == "")
                        {
                            if (to-8 + (PlayerMove?-1:1)>0 & boardLayout[to - 8 + (PlayerMove ? -1 : 1)] == getmovepiece(0))
                            {

                            }
                            if (to + 8 + (PlayerMove ? -1 : 1) > 0 & boardLayout[to + 8 + (PlayerMove ? -1 : 1)] == getmovepiece(0))
                            {

                            }
                        }
                    }
                }
                



                return MoveCheckerAndDoer(take)
                //if (move.Contains(Convert.ToChar("="))){if (move.Contains(Convert.ToChar("x"))){string[] movesplit = move.Split("x");}else{if (move.Length > 2){}else{if (Convert.ToInt32(move[2]) > 1){return MoveCheckerAndDoer(8*num(move[0].ToString()) + Convert.ToInt32(move[2]) - 1, num(move[0].ToString()) + Convert.ToInt32(move[2]) - 1, 0,false);}else{return false;}}}}

            }
            bool MoveCheckerAndDoer(int from, int to, int piecenum,int topiecenum, bool taking)
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
                        else { return false; }
                    }
                    else { return false; }
                }
                else
                {

                }
            }

        }
    }
}

// & "C:\\Program Files\GitHub Desktop\resources\app\git\cmd\git.exe" config --global http.sslbackend schannel