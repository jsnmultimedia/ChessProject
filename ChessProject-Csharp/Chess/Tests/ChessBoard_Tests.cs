using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{
	[TestFixture]
	public class ChessBoard_Tests
	{
		private ChessBoard _chessBoard;

		[SetUp]
		public void SetUp()
		{
			_chessBoard = new ChessBoard();
		}

		[Test]
		public void Has_MaxBoardWidth_of_7()
		{
			Assert.That(ChessBoard.MaxBoardWidth, Is.EqualTo(7));
		}

		[Test]
		public void Has_MaxBoardHeight_of_7()
		{
			Assert.That(ChessBoard.MaxBoardHeight, Is.EqualTo(7));
		}

		[Test]
		public void IsLegalBoardPosition_True_X_equals_0_Y_equals_0()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(0, 0);
			Assert.That(isValidPosition, Is.True);
		}

		[Test]
		public void IsLegalBoardPosition_True_X_equals_5_Y_equals_5()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(5, 5);
			Assert.That(isValidPosition, Is.True);
		}

		[Test]
		public void IsLegalBoardPosition_False_X_equals_11_Y_equals_5()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(11, 5);
			Assert.That(isValidPosition, Is.False);
		}

		[Test]
		public void IsLegalBoardPosition_False_X_equals_0_Y_equals_9()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(0, 9);
			Assert.That(isValidPosition, Is.False);
		}

		[Test]
		public void IsLegalBoardPosition_False_X_equals_11_Y_equals_0()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(11, 0);
			Assert.That(isValidPosition, Is.False);
		}

		[Test]
		public void IsLegalBoardPosition_False_For_Negative_X_Values()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(-1, 5);
			Assert.That(isValidPosition, Is.False);
		}

		[Test]
		public void IsLegalBoardPosition_False_For_Negative_Y_Values()
		{
			var isValidPosition = _chessBoard.IsLegalBoardPosition(5, -1);
			Assert.That(isValidPosition, Is.False);
		}
		[Test]
		public void Avoids_Duplicate_Positioning()
		{
			Pawn firstPawn = new Pawn(PieceColor.Black);
			Pawn secondPawn = new Pawn(PieceColor.Black);
			_chessBoard.Add(firstPawn, 6, 3);
			_chessBoard.Add(secondPawn, 6, 3);
			Assert.That(firstPawn.XCoordinate, Is.EqualTo(6));
			Assert.That(firstPawn.YCoordinate, Is.EqualTo(3));
			Assert.That(secondPawn.XCoordinate, Is.EqualTo(-1));
			Assert.That(secondPawn.YCoordinate, Is.EqualTo(-1));
		}

        [Test]
        public void Avoids_Adding_To_Enemy_Position()
        {
            Pawn blackPawn = new Pawn(PieceColor.Black);
            Pawn whitePawn = new Pawn(PieceColor.White);
            _chessBoard.Add(blackPawn, 6, 3);
            _chessBoard.Add(whitePawn, 6, 3);
            Assert.That(blackPawn.XCoordinate, Is.EqualTo(6));
            Assert.That(blackPawn.YCoordinate, Is.EqualTo(3));
            Assert.That(whitePawn.XCoordinate, Is.EqualTo(-1));
            Assert.That(whitePawn.YCoordinate, Is.EqualTo(-1));
        }

		[Test]
		public void Limits_The_Number_Of_Pawns()
		{
			for (int i = 0; i < 10; i++)
			{
				Pawn blackPawn = new Pawn(PieceColor.Black);
                Pawn whitePawn = new Pawn(PieceColor.White);
				int row = i / (ChessBoard.MaxBoardHeight + 1);
                _chessBoard.Add(blackPawn, i % (ChessBoard.MaxBoardWidth + 1), 6 + row);
                _chessBoard.Add(whitePawn, i % (ChessBoard.MaxBoardWidth + 1), 1 - row);
				if (row < 1)
				{
					Assert.That(blackPawn.XCoordinate, Is.EqualTo(i % (ChessBoard.MaxBoardWidth + 1)));
                    Assert.That(blackPawn.YCoordinate, Is.EqualTo(6 + row));
                    Assert.That(whitePawn.XCoordinate, Is.EqualTo(i % (ChessBoard.MaxBoardWidth + 1)));
                    Assert.That(whitePawn.YCoordinate, Is.EqualTo(1 - row));
				}
				else
				{
					Assert.That(blackPawn.XCoordinate, Is.EqualTo(-1));
					Assert.That(blackPawn.YCoordinate, Is.EqualTo(-1));
                    Assert.That(whitePawn.XCoordinate, Is.EqualTo(-1));
                    Assert.That(whitePawn.YCoordinate, Is.EqualTo(-1));
				}
			}
		}

        [Test]
        public void Limits_The_Number_Of_Knights()
        {
            for (int i = 0; i < 5; i++)
            {
				Knight blackKnight = new Knight(PieceColor.Black);
                Knight whiteKnight = new Knight(PieceColor.White);
				int row = i / (ChessBoard.MaxBoardHeight + 1);
                int col = i % (ChessBoard.MaxBoardWidth + 1);
                _chessBoard.Add(blackKnight, col, 6 + row);
                _chessBoard.Add(whiteKnight, col, 1 - row);
				if (i < 2)
				{
					Assert.That(blackKnight.XCoordinate, Is.EqualTo(i % (ChessBoard.MaxBoardWidth + 1)));
                    Assert.That(blackKnight.YCoordinate, Is.EqualTo(6 + row));
                    Assert.That(whiteKnight.XCoordinate, Is.EqualTo(i % (ChessBoard.MaxBoardWidth + 1)));
                    Assert.That(whiteKnight.YCoordinate, Is.EqualTo(1 - row));
				}
				else
				{
					Assert.That(blackKnight.XCoordinate, Is.EqualTo(-1));
					Assert.That(blackKnight.YCoordinate, Is.EqualTo(-1));
                    Assert.That(whiteKnight.XCoordinate, Is.EqualTo(-1));
                    Assert.That(whiteKnight.YCoordinate, Is.EqualTo(-1));
				}
			}
        }
	}
}
