using static SAN_Tools.SAN_Tools;

namespace Chess_Library
{
    internal class BishopMovement
    {
        static void Move(ChessBoard chessBoard, string move, bool Playermove)
        {
            string[] editedmove = move.Split('x');

            MoveDetails actualmove = diagonallymove(chessBoard, editedmove[0], editedmove[1]);
        }
        private static MoveDetails diagonallymove(ChessBoard chessBoard, string to, string from,bool Playermove)
        {
            if (NumForRank(from[0]) > NumForRank(to[0]))
            {
                return checker(chessBoard, MoveNum(to), true);
            }
            else if (NumForRank(from[0]) < NumForRank(to[0]))
            {
                return checker(chessBoard, MoveNum(to), false);
            }
            else return new MoveDetails(false);
        }
        private static MoveDetails diagonallymove(ChessBoard chessBoard, string to, bool Playermove)
        {
            MoveDetails c1 = checker(chessBoard, MoveNum(to),true);
            MoveDetails c2 = checker(chessBoard, MoveNum(to), false);
            if (c1 & c2)
            {
                return new MoveDetails(false);
            }
            else if (c1.Outcome)
            {
                return c1;
            }
            return c2;
        }
        private static MoveDetails checker(ChessBoard chessBoard, int from, bool move, bool Playermove)
        {
            MoveDetails c1 = up(chessBoard, from, move);
            MoveDetails c2 = down(chessBoard, from, move);
            if (c1 & c2)
            {
                return new MoveDetails(false);
            }
            else if (c1.Outcome)
            {
                return c1;
            }
            return c2;
        }
        private static MoveDetails up(ChessBoard chessBoard, int from, bool move, bool Playermove)
        {
            for (int i=from; (chessBoard[i]==GetMovePiece(6,Playermove)|| chessBoard[i] == ""); i += move ? 7 : -9)
            {
                
            }
        }
        private static MoveDetails down(ChessBoard chessBoard, int from, bool move, bool Playermove)
        {
            for (int i = from; ; i += move ? 9 : -7)
            {

            }
        }
    }
}
