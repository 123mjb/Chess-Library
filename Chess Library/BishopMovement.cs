using static SAN_Tools.SAN_Tools;

namespace Chess_Library
{
    internal class BishopMovement
    {
        static MoveDetails Mover(ChessBoard chessBoard, string move, bool Playermove)
        {
            if (move.StartsWith('B') || move.StartsWith('b'))
            {
                move.Remove(0);
                if (move.EndsWith('+')) move.Remove(move.Length-1);
                
                string[] editedmove = move.Split('x');

                if (editedmove.Length < 2& editedmove[0].Length>2)
                {
                    string[] temp = editedmove;
                    editedmove = new string[2] { (string)temp[0].Take(temp[0].Length - 2), (string)temp[0].Skip(temp[0].Length - 2) };
                }

                MoveDetails actualmove = diagonallymove(chessBoard, editedmove[0], editedmove[1], Playermove);//CHECK THAT TO AND FROM ARE CORRECT
                return actualmove;
            }
            else return new MoveDetails(false);
        }
        private static MoveDetails diagonallymove(ChessBoard chessBoard, string to, string from,bool Playermove)
        {
            if (NumForRank(from[0]) > NumForRank(to[0]))
            {
                return checker(chessBoard,new Move(MoveNum(to)), true,Playermove);
            }
            else if (NumForRank(from[0]) < NumForRank(to[0]))
            {
                return checker(chessBoard,new Move(MoveNum(to)), false,Playermove);
            }
            else return new MoveDetails(false);
        }
        private static MoveDetails diagonallymove(ChessBoard chessBoard, string to, bool Playermove)
        {
            MoveDetails c1 = checker(chessBoard, new Move(MoveNum(to)),true, Playermove);
            MoveDetails c2 = checker(chessBoard, new Move(MoveNum(to)), false, Playermove);
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
        private static MoveDetails checker(ChessBoard chessBoard, Move from, bool move, bool Playermove)
        {
            MoveDetails c1 = up(chessBoard, from, move,Playermove);
            MoveDetails c2 = down(chessBoard, from, move,Playermove);
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
        private static MoveDetails up(ChessBoard chessBoard, Move from, bool move, bool Playermove)
        {
            for (int i=(int)from; (chessBoard[i]==GetMovePiece(6,Playermove)|| chessBoard[i] == "")&&(from.FileNum>-1&&from.FileNum<8&&from.Rank>-1&&from.Rank<8); i += move ? 7 : -9)
            {
                if (chessBoard[i] == GetMovePiece(6, Playermove))
                {
                    return new MoveDetails(true, i, (int)from);
                }
                
            }
            return new MoveDetails(false);
        }
        private static MoveDetails down(ChessBoard chessBoard, Move from, bool move, bool Playermove)
        {
            for (int i = (int)from; (chessBoard[i] == GetMovePiece(6, Playermove) || chessBoard[i] == "") && (from.FileNum > -1 && from.FileNum < 8 && from.Rank > -1 && from.Rank < 8); i += move ? 9 : -7)
            {
                if (chessBoard[i] == GetMovePiece(6, Playermove))
                {
                    return new MoveDetails(true, i, (int)from);
                }
            }
            return new MoveDetails(false);
        }
    }
}