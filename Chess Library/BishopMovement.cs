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

        }
        private static MoveDetails checker(ChessBoard chessBoard, int from, int move)
        {

        }
    }
}
