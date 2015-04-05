using System;
using System.Collections.Generic;

namespace Gfi.Hiring
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;

        private BoardPosition[,] pieces;
        private Dictionary<Type, Func<PieceColor, bool>> CanAddPiece;
        private Dictionary<PieceColor, int> PawnCount;
        private Dictionary<PieceColor, int> KnightCount;

        public ChessBoard ()
        {
            // Create all the board positions as unoccupied
            pieces = new BoardPosition[MaxBoardWidth+1, MaxBoardHeight+1];
            for (int x = 0; x <= MaxBoardWidth; x++)
            {
                for (int y = 0; y <= MaxBoardHeight; y++)
                {
                    pieces[x, y] = new BoardPosition(this, x, y, false);
                }
            }
            // Functions for checking how many chess pieces we have added for each type and color
            CanAddPiece = new Dictionary<Type, Func<PieceColor, bool>>();
            CanAddPiece.Add(typeof(Pawn), new Func<PieceColor, bool>(CanAddPawn));
            CanAddPiece.Add(typeof(Knight), new Func<PieceColor, bool>(CanAddKnight));

            // Pawn Piece counter 
            PawnCount = new Dictionary<PieceColor, int>();
            PawnCount.Add(PieceColor.Black, 0);
            PawnCount.Add(PieceColor.White, 0);
            // Knight Piece counter
            KnightCount = new Dictionary<PieceColor, int>();
            KnightCount.Add(PieceColor.Black, 0);
            KnightCount.Add(PieceColor.White, 0);
        }

        public void Add(PieceBase piece, int xCoordinate, int yCoordinate)
        {
            // Check that the position on the board is legit, we haven't reached the limit for the chess piece
            // and the position isn't already occupied
            if (IsLegalBoardPosition(xCoordinate, yCoordinate) && CanAddPiece[piece.GetType()](piece.PieceColor)
                && !pieces[xCoordinate, yCoordinate].Occupied)
            {
                piece.ChessBoard = this;
                piece.XCoordinate = xCoordinate;
                piece.YCoordinate = yCoordinate;
                pieces[xCoordinate, yCoordinate].Occupied = true;
                pieces[xCoordinate, yCoordinate].Piece = piece;
            }
            else
            {
                piece.XCoordinate = -1;
                piece.YCoordinate = -1;
            }

        }

        public void Move(PieceBase piece, int xCoordinate, int yCoordinate)
        {
            // Make sure we can make the move
            if (IsLegalPieceMove(xCoordinate, yCoordinate))
            {
                // Set the previous position to unoccupied
                pieces[piece.XCoordinate, piece.YCoordinate].Occupied = false;
                // Move the piece to the new position
                pieces[xCoordinate, yCoordinate].Occupied = true;
                pieces[xCoordinate, yCoordinate].Piece = piece;
                piece.XCoordinate = xCoordinate;
                piece.YCoordinate = yCoordinate;
            }
        }

        public bool IsLegalPieceMove(int xCoordinate, int yCoordinate)
        {
            // Make sure it's a legal position on our board
            if (IsLegalBoardPosition(xCoordinate, yCoordinate))
            {
                // True if the position isn't already occupied
                return !pieces[xCoordinate, yCoordinate].Occupied;
            }
            return false;
        }

        public void Capture(PieceBase piece, int xCoordinate, int yCoordinate)
        {
            // Check we are making a legal capture
            if (IsLegalPieceCapture(piece, xCoordinate, yCoordinate))
            {
                // Set the previous position to unoccupied
                pieces[piece.XCoordinate, piece.YCoordinate].Occupied = false;
                // Get the captured piece from the new position 
                PieceBase captured = (PieceBase)pieces[xCoordinate, yCoordinate].Piece;
                // Set it's coordinates to removed
                captured.XCoordinate = -1;
                captured.YCoordinate = -1;
                // Move our piece to the new position
                pieces[xCoordinate, yCoordinate].Piece = piece;
                piece.XCoordinate = xCoordinate;
                piece.YCoordinate = yCoordinate;
            }
        }

        public bool IsLegalPieceCapture(PieceBase piece, int xCoordinate, int yCoordinate)
        {
            // Check we have a valid board position
            if (IsLegalBoardPosition(xCoordinate, yCoordinate))
            {
                // Return true if the position is occupied by the enemy's piece
                if (pieces[xCoordinate, yCoordinate].Occupied
                    && piece.PieceColor != pieces[xCoordinate, yCoordinate].Piece.PieceColor)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            // return true if we have a valid board position
            if ((xCoordinate >= 0) && (xCoordinate <= MaxBoardWidth) && 
                (yCoordinate >= 0) && (yCoordinate <= MaxBoardHeight))
            {
                return true;
            }
            return false;
        }

        public bool CanAddPawn(PieceColor pieceColor)
        {
            // Check we haven't hit the limit of pawns for our color
            if (PawnCount[pieceColor] < Pawn.MaxBoardPiece)
            {
                PawnCount[pieceColor]++;
                return true;
            } 
            return false;
        }

        public bool CanAddKnight(PieceColor pieceColor)
        {
            // Check we haven't hit the limit of knights for our color
            if (KnightCount[pieceColor] < Knight.MaxBoardPiece)
            {
                KnightCount[pieceColor]++;
                return true;
            }
            return false;
        }

    }
}
