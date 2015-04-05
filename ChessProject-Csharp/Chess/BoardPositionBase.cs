using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{
    public abstract class BoardPositionBase
    {
        private ChessBoard _chessBoard;
        private int _xCoordinate;
        private int _yCoordinate;

        public ChessBoard ChessBoard
        {
            get { return _chessBoard; }
            set { _chessBoard = value; }
        }

        public int XCoordinate
        {
            get { return _xCoordinate; }
            set { _xCoordinate = value; }
        }

        public int YCoordinate
        {
            get { return _yCoordinate; }
            set { _yCoordinate = value; }
        }

        public BoardPositionBase()
        { }

        public BoardPositionBase(ChessBoard board, int xCoord, int yCoord)
        {
            ChessBoard = board;
            XCoordinate = xCoord;
            YCoordinate = yCoord;
        }

    }
}
