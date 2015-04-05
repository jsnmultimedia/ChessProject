using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{
    public abstract class PieceBase : BoardPositionBase, IPiece
    {
        public PieceColor PieceColor { get; protected set; }

        public PieceBase(PieceColor pieceColor)
        {
            PieceColor = pieceColor;
        }

        protected abstract bool LegalMove(int newX, int newY);

        protected virtual bool LegalCapture(int newX, int newY)
        {
            // Most pieces have the same movement for capture
            return LegalMove(newX, newY);
        }

        public virtual void Move(MovementType movementType, int newX, int newY)
        {
            // Move
            if (movementType == MovementType.Move)
            {
                // Make sure it's a legal move for this piece
                if (LegalMove(newX, newY))
                {
                    // Try and make the move
                    ChessBoard.Move(this, newX, newY);
                }
            }
            else // Capture
            {
                // Make sure it's a legal capture for this piece
                if (LegalCapture(newX, newY))
                {
                    // Try and Capture
                    ChessBoard.Capture(this, newX, newY);
                }
            }
        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, PieceColor);
        }
    }
}
