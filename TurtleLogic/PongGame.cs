using System;
using TurtleInterface;

namespace TurtleLogic
{
	public class PongGame : ITurtleGame
	{
		int PlayerOneScore = 0;
		int PlayerTwoScore = 0;
		Point BallPosition;
		Size BallSize = new Size (26, 26);
		const int LeftPaddleX = 20;
		int RightPaddleX;
		const int PaddleHeight = 75;
		const int PaddleWidth = 15;
		int LeftPaddleY;
		int RightPaddleY;
		bool IsInitialized = false;
		Size PlayArea;
		const int PaddleSpeed = 8;

		Random Random = new Random ();
		int BallVelocityX = 0;
		int BallVelocityY = 0;

		public PongGame ()
		{
		}

		public void OnDraw (long frame, ITurtleDrawing drawing)
		{
			if (!IsInitialized)
			{
				PlayArea = new Size ((int)drawing.ScreenWidth, (int)drawing.ScreenHeight);
				RightPaddleX = (int)(drawing.ScreenWidth - 40);

				LeftPaddleY = (int)((drawing.ScreenHeight * .5) - (PaddleHeight * .5));
				RightPaddleY = LeftPaddleY;

				SetupBall ();

				IsInitialized = true;
			}

			drawing.Fill (Colors.Black);
			drawing.DrawSquare (new Color (128, 128, 128), new Point (0, 0), PlayArea);

			DrawPaddle (drawing);
			DrawBall (drawing);
			DrawScore (drawing);
			HandlePhysics ();
			HandleRules ();
		}

		void SetupBall ()
		{
			int midX = (int)(PlayArea.Width * .5) - (BallSize.Width / 2);
			int midY = (int)(PlayArea.Height * .5) - (BallSize.Height / 2);

			BallPosition = new Point (midX, midY);

			int isLeft = Random.Next (0, 2);
			if (isLeft == 0)
				BallVelocityX = -5;
			else
				BallVelocityX = 5;
			BallVelocityY = Random.Next (-4, 4);
		}

		void DrawScore (ITurtleDrawing drawing)
		{
			double scoreOneX = drawing.ScreenWidth * .25;
			double scoreTwoX = drawing.ScreenWidth * .75;
			drawing.DrawText (Colors.White, new Point ((int)scoreOneX, 20), PlayerOneScore.ToString ());
			drawing.DrawText (Colors.White, new Point ((int)scoreTwoX, 20), PlayerTwoScore.ToString ());
		}

		void DrawBall (ITurtleDrawing drawing)
		{
			drawing.DrawSquare (Colors.White, BallPosition, BallSize);
		}
	
		void DrawPaddle (ITurtleDrawing drawing)
		{
			drawing.DrawSquare (Colors.White, new Point (LeftPaddleX, LeftPaddleY), new Size (PaddleWidth, PaddleHeight));
			drawing.DrawSquare (Colors.White, new Point (RightPaddleX, RightPaddleY), new Size (PaddleWidth, PaddleHeight));
		}

		void HandlePhysics ()
		{
			BallPosition = new Point (BallPosition.X + BallVelocityX,
									BallPosition.Y + BallVelocityY);

			if (BallPosition.Y <= 0)
			{
				Bounce ();
			}
			else if (BallPosition.Y + BallSize.Height >= PlayArea.Height)
			{
				Bounce ();
			}

			if (SquareContainsSquare (BallPosition, BallSize,
				new Point (LeftPaddleX, LeftPaddleY),
				new Size (PaddleWidth, PaddleHeight)))
			{
				HandleCollision ();
			}
			else if (SquareContainsSquare (BallPosition, BallSize,
				new Point (RightPaddleX, RightPaddleY),
			 	new Size (PaddleWidth, PaddleHeight)))
			{
				HandleCollision ();
			}
		}

		void Bounce ()
		{
			BallVelocityY *= -1;
		}

		void HandleCollision ()
		{
			BallVelocityX *= -1;
			BallVelocityY *= -1;

			// BUG - Able to spear the ball
		}

		public void Die (bool ballWasLeft)
		{
			SetupBall ();
			if (ballWasLeft)
				PlayerTwoScore += 1;
			else
				PlayerOneScore += 1;
			if (PlayerOneScore >= 11 ||
				PlayerTwoScore >= 11 ||
				PlayerOneScore + PlayerTwoScore >= 21)
			{
				PlayerOneScore = 0;
				PlayerTwoScore = 0;
			}
		}

		bool SquareContainsSquare (Point squareOne, Size sizeOne, Point squareTwo, Size sizeTwo)
		{
			Point upperLeft = squareOne;
			Point upperRight = new Point (squareOne.X + sizeOne.Width, squareOne.Y);
			Point lowerLeft = new Point (squareOne.X, squareOne.Y + sizeOne.Height);
			Point lowerRight = new Point (squareOne.X + sizeOne.Width, squareOne.Y + sizeOne.Height);

			if (SquareContainsPoint (squareTwo, sizeTwo, upperLeft))
			{
				return true;
			}
			else if (SquareContainsPoint (squareTwo, sizeTwo, upperRight))
			{
				return true;
			}
			else if (SquareContainsPoint (squareTwo, sizeTwo, lowerLeft))
			{
				return true;
			}
			else if (SquareContainsPoint (squareTwo, sizeTwo, lowerRight))
			{
				return true;
			}
			return false;
		}

		bool SquareContainsPoint (Point square, Size size, Point p)
		{
			int left = square.X;
			int right = left + size.Width;
			int top = square.Y;
			int bottom = top + size.Height;
			return left <= p.X && p.X <= right && top <= p.Y && p.Y <= bottom;
		}

		void HandleRules ()
		{
			if (BallPosition.X + BallSize.Width <= 0)
			{
				Die (true);
			}
			else if (BallPosition.X >= PlayArea.Width)
			{
				Die (false);
			}
			// TODO - Add ball wiggle somehow
		}

		void HandleInput (string direction)
		{
			// TODO - Need to handle off screen
			// TODO - Make the paddle faster
			// TODO - Make input smooth
			// TODO - Add pause
			switch (direction)
			{
				case "w":
					LeftPaddleY -= PaddleSpeed;
					break;
				case "s":
					LeftPaddleY += PaddleSpeed;
					break;
				case "o":
					RightPaddleY -= PaddleSpeed;
					break;
				case "l":
					RightPaddleY += PaddleSpeed;
					break;
				default:
					break;
			}
		}

		public void OnKeyboard (string key)
		{
			HandleInput (key);
		}

		public void OnClick (Point position)
		{
		}
	}
}
