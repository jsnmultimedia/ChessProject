using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring.Tests
{
    [TestFixture]
    public class Knight_Tests
    {
        private ChessBoard _chessBoard;
        private Knight _blackKnight;
        private Knight _blackKnight2;
        private Knight _whiteKnight;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard();
            _blackKnight = new Knight(PieceColor.Black);
            _blackKnight2 = new Knight(PieceColor.Black);
            _whiteKnight = new Knight(PieceColor.White);
        }

        [Test]
        public void ChessBoard_Add_Sets_XCoordinate()
        {
            _chessBoard.Add(_blackKnight, 1, 7);
            _chessBoard.Add(_whiteKnight, 6, 0);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(1));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(6));
        }

        [Test]
        public void ChessBoard_Add_Sets_YCoordinate()
        {
            _chessBoard.Add(_blackKnight, 1, 7);
            _chessBoard.Add(_whiteKnight, 6, 0);
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(7));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(0));
        }

        [Test]
        public void Knight_Move_IllegalCoordinates_Right_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 1, 7);
            _chessBoard.Add(_whiteKnight, 6, 0);
            _blackKnight.Move(MovementType.Move, 2, 7);
            _whiteKnight.Move(MovementType.Move, 7, 0);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(1));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(7));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(6));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(0));
        }

        [Test]
        public void Knight_Move_IllegalCoordinates_Left_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 1, 7);
            _chessBoard.Add(_whiteKnight, 6, 0);
            _blackKnight.Move(MovementType.Move, 0, 7);
            _whiteKnight.Move(MovementType.Move, 5, 0);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(1));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(7));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(6));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(0));
        }

        [Test]
        public void Knight_Move_IllegalCoordinates_Front_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 1, 7);
            _chessBoard.Add(_whiteKnight, 6, 0);
            _blackKnight.Move(MovementType.Move, 1, 6);
            _whiteKnight.Move(MovementType.Move, 6, 1);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(1));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(7));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(6));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(0));
        }

        [Test]
        public void Knight_Move_IllegalCoordinates_Back_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 1, 6);
            _chessBoard.Add(_whiteKnight, 6, 1);
            _blackKnight.Move(MovementType.Move, 1, 7);
            _whiteKnight.Move(MovementType.Move, 6, 0);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(1));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(6));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(6));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(1));
        }

        [Test]
        public void Knight_Move_IllegalCoordinates_Forward2_Left2_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 6, 7);
            _chessBoard.Add(_whiteKnight, 6, 0);
            _blackKnight.Move(MovementType.Move, 4, 5);
            _whiteKnight.Move(MovementType.Move, 4, 2);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(6));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(7));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(6));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(0));
        }

        [Test]
        public void Knight_Move_IllegalCoordinates_Back1_Right1_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 5, 5);
            _chessBoard.Add(_whiteKnight, 5, 2);
            _blackKnight.Move(MovementType.Move, 6, 6);
            _whiteKnight.Move(MovementType.Move, 6, 1);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(5));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(5));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(5));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(2));
        }

        [Test]
        public void Knight_Move_LegalCoordinates_Forward2_Left1_UpdatesCoordinates()
        {
            _chessBoard.Add(_blackKnight, 6, 7);
            _chessBoard.Add(_whiteKnight, 6, 0);
            _blackKnight.Move(MovementType.Move, 5, 5);
            _whiteKnight.Move(MovementType.Move, 5, 2);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(5));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(5));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(5));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(2));
        }

        [Test]
        public void Knight_Move_LegalCoordinates_Back1_Right2_UpdatesCoordinates()
        {
            _chessBoard.Add(_blackKnight, 5, 5);
            _chessBoard.Add(_whiteKnight, 5, 2);
            _blackKnight.Move(MovementType.Move, 7, 6);
            _whiteKnight.Move(MovementType.Move, 7, 1);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(7));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(6));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(7));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(1));
        }

        [Test]
        public void Knight_Capture_IllegalCoordinates_Right_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 4, 3);
            _chessBoard.Add(_whiteKnight, 5, 3);
            _blackKnight.Move(MovementType.Capture, 5, 3);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(4));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(3));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(5));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void Knight_Capture_IllegalCoordinates_Left_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 4, 3);
            _chessBoard.Add(_whiteKnight, 5, 3);
            _whiteKnight.Move(MovementType.Capture, 4, 3);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(4));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(3));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(5));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void Knight_Capture_IllegalCoordinates_Front_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 4, 4);
            _chessBoard.Add(_whiteKnight, 4, 3);
            _blackKnight.Move(MovementType.Capture, 4, 3);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(4));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(4));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(4));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void Knight_Capture_IllegalCoordinates_Back_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 4, 4);
            _chessBoard.Add(_whiteKnight, 4, 5);
            _whiteKnight.Move(MovementType.Capture, 4, 4);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(4));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(4));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(4));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(5));
        }

        [Test]
        public void Knight_Capture_IllegalCoordinates_Forward2_Left2_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 6, 4);
            _chessBoard.Add(_whiteKnight, 4, 2);
            _blackKnight.Move(MovementType.Capture, 4, 2);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(6));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(4));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(4));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(2));
        }

        [Test]
        public void Knight_Capture_IllegalCoordinates_Back1_Right1_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 4, 5);
            _chessBoard.Add(_whiteKnight, 5, 4);
            _whiteKnight.Move(MovementType.Capture, 4, 5);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(4));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(5));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(5));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(4));
        }

        [Test]
        public void Knight_Capture_LegalCoordinates_NoEnemyToCapture_Forward2_Left1_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 6, 7);
            _blackKnight.Move(MovementType.Capture, 5, 5);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(6));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(7));
        }

        [Test]
        public void Knight_Capture_LegalCoordinates_NoEnemyToCapture_Back1_Right2_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 5, 5);
            _blackKnight.Move(MovementType.Capture, 7, 6);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(5));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(5));
        }

        [Test]
        public void Knight_Capture_LegalCoordinates_OwnKnight_Forward2_Left1_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 6, 7);
            _chessBoard.Add(_blackKnight2, 5, 5);
            _blackKnight.Move(MovementType.Capture, 5, 5);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(6));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(7));
            Assert.That(_blackKnight2.XCoordinate, Is.EqualTo(5));
            Assert.That(_blackKnight2.YCoordinate, Is.EqualTo(5));
        }

        [Test]
        public void Knight_Capture_LegalCoordinates_OwnKnight_Back1_Right2_DoesNotMove()
        {
            _chessBoard.Add(_blackKnight, 7, 1);
            _chessBoard.Add(_blackKnight2, 5, 2);
            _blackKnight2.Move(MovementType.Capture, 7, 1);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(7));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(1));
            Assert.That(_blackKnight2.XCoordinate, Is.EqualTo(5));
            Assert.That(_blackKnight2.YCoordinate, Is.EqualTo(2));
        }

        [Test]
        public void Knight_Capture_LegalCoordinates_Forward2_Left1_UpdatesCoordinates()
        {
            _chessBoard.Add(_blackKnight, 6, 7);
            _chessBoard.Add(_whiteKnight, 5, 5);
            _blackKnight.Move(MovementType.Capture, 5, 5);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(5));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(5));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(-1));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(-1));
        }

        [Test]
        public void Knight_Capture_LegalCoordinates_Back1_Right2_UpdatesCoordinates()
        {
            _chessBoard.Add(_blackKnight, 7, 1);
            _chessBoard.Add(_whiteKnight, 5, 2);
            _whiteKnight.Move(MovementType.Capture, 7, 1);
            Assert.That(_blackKnight.XCoordinate, Is.EqualTo(-1));
            Assert.That(_blackKnight.YCoordinate, Is.EqualTo(-1));
            Assert.That(_whiteKnight.XCoordinate, Is.EqualTo(7));
            Assert.That(_whiteKnight.YCoordinate, Is.EqualTo(1));
        }

    }
}
