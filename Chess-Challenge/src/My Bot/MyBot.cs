using ChessChallenge.API;

public class MyBot : IChessBot
{
    public Move Think(Board board, Timer timer)
    {
        Move[] capture_moves = board.GetLegalMoves(true);
        if (capture_moves.Length > 0)
        {
            return capture_moves[0];
        }
        else
        {
            Move[] moves = board.GetLegalMoves();
            return moves[0];
        }
    }
}