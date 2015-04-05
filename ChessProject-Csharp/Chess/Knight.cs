using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{
    public class Knight : PieceBase
    {
        public static readonly int MaxBoardPiece = 2;

        public Knight(PieceColor pieceColor)
            : base(pieceColor)
        {
        }

        protected override bool LegalMove(int newX, int newY)
        {
            // Knights can move one step forward or back
            if (newX.Equals(XCoordinate + 1) || newX.Equals(XCoordinate - 1))
            {
                // and then 2 steps left or right
                if (newY.Equals(YCoordinate + 2) || newY.Equals(YCoordinate - 2))
                {
                    return true;
                }
            } // Or they can move 2 steps forward or back
            else if (newX.Equals(XCoordinate + 2) || newX.Equals(XCoordinate - 2))
            {
                // and then 1 step left or right
                if (newY.Equals(YCoordinate + 1) || newY.Equals(YCoordinate - 1))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
