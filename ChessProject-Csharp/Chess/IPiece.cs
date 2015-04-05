using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{
    public interface IPiece
    {
        PieceColor PieceColor { get; }
        void Move(MovementType movementType, int newX, int newY);
    }
}
