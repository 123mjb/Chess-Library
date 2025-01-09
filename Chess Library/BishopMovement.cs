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
        private static MoveDetails diagonallymove(ChessBoard chessBoard, string to, string from)
        {
            if (NumForRank(from[0]) > NumForRank(to[0]))
            {
                return checker(chessBoard, MoveNum(to), 1);
            }
            else if (NumForRank(from[0]) < NumForRank(to[0]))
            {
                return checker(chessBoard, MoveNum(to), -1);
            }
            else return new MoveDetails(false);
        }
        private static MoveDetails diagonallymove(ChessBoard chessBoard, string to)
        {
            MoveDetails c1 = checker(chessBoard, MoveNum(to),1);
            MoveDetails c2 = checker(chessBoard, MoveNum(to), -1);
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
        private static MoveDetails checker(ChessBoard chessBoard, int from, int move)
        {
            
        }
        private static MoveDetails up(ChessBoard chessBoard, int from, int move)
        {

        }
        private static MoveDetails down(ChessBoard chessBoard, int from, int move)
        {

        }
    }
}
