using System;

namespace Gfi.Hiring
{
    public class Pawn : PieceBase
    {
        public static readonly int MaxBoardPiece = 8;

        public Pawn(PieceColor pieceColor)
            : base(pieceColor)
        {
        }

        protected override bool LegalMove(int newX, int newY)
        {
            // White moves up the board so Y increases
            // Black moves down the board so Y decreases
            int move = PieceColor.Equals(PieceColor.White) ? 1 : -1;

            // Make sure our movement is 1 step forward
            return newX.Equals(XCoordinate) && newY.Equals(YCoordinate + move);
        }

        protected override bool LegalCapture(int newX, int newY)
        {
            // White moves up the board so Y increases
            // Black moves down the board so Y decreases
            int move = PieceColor.Equals(PieceColor.White) ? 1 : -1;

            // Make Sure our capture is 1 step forward
            if (newY.Equals(YCoordinate + move))
            {
                // Make sure the capture is diagonal by 1 square
                if (newX.Equals(XCoordinate + 1) || (newX.Equals(XCoordinate - 1)))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
