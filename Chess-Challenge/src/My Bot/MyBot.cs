using System.Collections;
using System.Collections.Generic;
using ChessChallenge.API;
using System.Linq;
using System;

public class MyBot : IChessBot
{
    public int pv_calc(Board board, Move move) {
        board.MakeMove(move);
        PieceList[] piecelistArr = board.GetAllPieceLists();

        for (int i = 0; i < piecelistArr.Length; i++)
        {
            PieceList piecelist = piecelistArr[i];
            for (int j = 0; j < piecelist.Count; j++)
            {
                Piece cur_piece = piecelist.GetPiece(j);
                Console.WriteLine(cur_piece);
            }
        }
        return 3;
    } 
    
    public Move Think(Board board, Timer timer)
    {
        Move[] pos_moves = board.GetLegalMoves();
        List<int> mov_pv = new List<int>();

        for (int i = 0; i < pos_moves.Length; i++)
        {
            mov_pv.Add(pv_calc(board, pos_moves[i]));
        }
        int maxPv = mov_pv.Max();
        int maxPvIndex = mov_pv.IndexOf(maxPv);
        return pos_moves[maxPvIndex];
    }


}