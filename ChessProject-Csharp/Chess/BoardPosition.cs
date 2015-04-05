using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{
    class BoardPosition : BoardPositionBase
    {
        // True if position is occupied by a piece
        public bool Occupied { get; set; }
        // The piece occupying the position
        public IPiece Piece { get; set; }

        public BoardPosition (ChessBoard board, int xCoord, int yCoord, bool occupied)
            : base(board, xCoord, yCoord)
        {
            Occupied = occupied;
        }
    }
}
