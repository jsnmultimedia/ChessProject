using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{
	[TestFixture]
	public class Pawn_Tests
	{
		private ChessBoard _chessBoard;
		private Pawn _blackPawn;
        private Pawn _blackPawn2;
        private Pawn _whitePawn;

		[SetUp]
		public void SetUp()
		{
			_chessBoard = new ChessBoard();
			_blackPawn = new Pawn(PieceColor.Black);
            _blackPawn2 = new Pawn(PieceColor.Black);
            _whitePawn = new Pawn(PieceColor.White);
		}

		[Test]
		public void ChessBoard_Add_Sets_XCoordinate()
		{
			_chessBoard.Add(_blackPawn, 3, 6);
            _chessBoard.Add(_whitePawn, 4, 1);
			Assert.That(_blackPawn.XCoordinate, Is.EqualTo(3));
            Assert.That(_whitePawn.XCoordinate, Is.EqualTo(4));
		}

		[Test]
		public void ChessBoard_Add_Sets_YCoordinate()
		{
			_chessBoard.Add(_blackPawn, 3, 6);
            _chessBoard.Add(_whitePawn, 4, 1);
			Assert.That(_blackPawn.YCoordinate, Is.EqualTo(6));
            Assert.That(_whitePawn.YCoordinate, Is.EqualTo(1));
		}

		[Test]
		public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove()
		{
			_chessBoard.Add(_blackPawn, 3, 6);
            _chessBoard.Add(_whitePawn, 4, 1);
			_blackPawn.Move(MovementType.Move, 4, 6);
            _whitePawn.Move(MovementType.Move, 5, 1);
			Assert.That(_blackPawn.XCoordinate, Is.EqualTo(3));
			Assert.That(_blackPawn.YCoordinate, Is.EqualTo(6));
            Assert.That(_whitePawn.XCoordinate, Is.EqualTo(4));
            Assert.That(_whitePawn.YCoordinate, Is.EqualTo(1));
		}

		[Test]
		public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove()
		{
			_chessBoard.Add(_blackPawn, 3, 6);
            _chessBoard.Add(_whitePawn, 4, 1);
			_blackPawn.Move(MovementType.Move, 2, 6);
            _whitePawn.Move(MovementType.Move, 3, 1);
			Assert.That(_blackPawn.XCoordinate, Is.EqualTo(3));
			Assert.That(_blackPawn.YCoordinate, Is.EqualTo(6));
            Assert.That(_whitePawn.XCoordinate, Is.EqualTo(4));
            Assert.That(_whitePawn.YCoordinate, Is.EqualTo(1));
		}

        [Test]
        public void Pawn_Move_IllegalCoordinates_BlockedByEnemy_DoesNotMove()
        {
            _chessBoard.Add(_blackPawn, 3, 5);
            _chessBoard.Add(_whitePawn, 3, 4);
            _blackPawn.Move(MovementType.Move, 3, 4);
            Assert.That(_blackPawn.XCoordinate, Is.EqualTo(3));
            Assert.That(_blackPawn.YCoordinate, Is.EqualTo(5));
            Assert.That(_whitePawn.XCoordinate, Is.EqualTo(3));
            Assert.That(_whitePawn.YCoordinate, Is.EqualTo(4));
        }

		[Test]
		public void Pawn_Move_LegalCoordinates_Forward_UpdatesCoordinates()
		{
			_chessBoard.Add(_blackPawn, 3, 6);
            _chessBoard.Add(_whitePawn, 4, 1);
			_blackPawn.Move(MovementType.Move, 3, 5);
            _whitePawn.Move(MovementType.Move, 4, 2);
			Assert.That(_blackPawn.XCoordinate, Is.EqualTo(3));
			Assert.That(_blackPawn.YCoordinate, Is.EqualTo(5));
            Assert.That(_whitePawn.XCoordinate, Is.EqualTo(4));
            Assert.That(_whitePawn.YCoordinate, Is.EqualTo(2));
		}

        [Test]
        public void Pawn_Capture_IllegalCoordinates_Left_DoesNotMove()
        {
            _chessBoard.Add(_blackPawn, 4, 4);
            _chessBoard.Add(_whitePawn, 3, 4);
            _blackPawn.Move(MovementType.Capture, 3, 4);
            Assert.That(_blackPawn.XCoordinate, Is.EqualTo(4));
            Assert.That(_blackPawn.YCoordinate, Is.EqualTo(4));
            Assert.That(_whitePawn.XCoordinate, Is.EqualTo(3));
            Assert.That(_whitePawn.YCoordinate, Is.EqualTo(4));
        }

        [Test]
        public void Pawn_Capture_IllegalCoordinates_Right_DoesNotMove()
        {
            _chessBoard.Add(_blackPawn, 3, 4);
            _chessBoard.Add(_whitePawn, 4, 4);
            _blackPawn.Move(MovementType.Capture, 4, 4);
            Assert.That(_blackPawn.XCoordinate, Is.EqualTo(3));
            Assert.That(_blackPawn.YCoordinate, Is.EqualTo(4));
            Assert.That(_whitePawn.XCoordinate, Is.EqualTo(4));
            Assert.That(_whitePawn.YCoordinate, Is.EqualTo(4));
        }

        [Test]
        public void Pawn_Capture_IllegalCoordinates_Forward_DoesNotMove()
        {
            _chessBoard.Add(_blackPawn, 4, 5);
            _chessBoard.Add(_whitePawn, 4, 4);
            _blackPawn.Move(MovementType.Capture, 4, 4);
            Assert.That(_blackPawn.XCoordinate, Is.EqualTo(4));
            Assert.That(_blackPawn.YCoordinate, Is.EqualTo(5));
            Assert.That(_whitePawn.XCoordinate, Is.EqualTo(4));
            Assert.That(_whitePawn.YCoordinate, Is.EqualTo(4));
        }

        [Test]
        public void Pawn_Capture_LegalCoordinates_NoEnemyToCapture_DoesNotMove()
        {
            _chessBoard.Add(_blackPawn, 4, 4);
            _blackPawn.Move(MovementType.Capture, 3, 3);
            Assert.That(_blackPawn.XCoordinate, Is.EqualTo(4));
            Assert.That(_blackPawn.YCoordinate, Is.EqualTo(4));
        }

        [Test]
        public void Pawn_Capture_LegalCoordinates_OwnPawn_DoesNotMove()
        {
            _chessBoard.Add(_blackPawn, 4, 5);
            _chessBoard.Add(_blackPawn2, 3, 4);
            _blackPawn.Move(MovementType.Capture, 3, 4);
            Assert.That(_blackPawn.XCoordinate, Is.EqualTo(4));
            Assert.That(_blackPawn.YCoordinate, Is.EqualTo(5));
            Assert.That(_blackPawn2.XCoordinate, Is.EqualTo(3));
            Assert.That(_blackPawn2.YCoordinate, Is.EqualTo(4));
        }

        [Test]
        public void Pawn_Capture_LegalCoordinates_ForwardLeftDiagonal_UpdatesCoordinates()
        {
            _chessBoard.Add(_blackPawn, 4, 5);
            _chessBoard.Add(_whitePawn, 3, 4);
            _blackPawn.Move(MovementType.Capture, 3, 4);
            Assert.That(_blackPawn.XCoordinate, Is.EqualTo(3));
            Assert.That(_blackPawn.YCoordinate, Is.EqualTo(4));
            Assert.That(_whitePawn.XCoordinate, Is.EqualTo(-1));
            Assert.That(_whitePawn.YCoordinate, Is.EqualTo(-1));
        }

        [Test]
        public void Pawn_Capture_LegalCoordinates_ForwardRightDiagonal_UpdatesCoordinates()
        {
            _chessBoard.Add(_blackPawn, 4, 5);
            _chessBoard.Add(_whitePawn, 3, 4);
            _whitePawn.Move(MovementType.Capture, 4, 5);
            Assert.That(_blackPawn.XCoordinate, Is.EqualTo(-1));
            Assert.That(_blackPawn.YCoordinate, Is.EqualTo(-1));
            Assert.That(_whitePawn.XCoordinate, Is.EqualTo(4));
            Assert.That(_whitePawn.YCoordinate, Is.EqualTo(5));
        }
	}
}
