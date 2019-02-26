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

		public PongGame ()
		{
		}

		public void OnDraw (long frame, ITurtleDrawing drawing)
		{
			if (!IsInitialized)
			{
				int midX = (int)(drawing.ScreenWidth * .5) - (BallSize.Width / 2);
				int midY = (int)(drawing.ScreenHeight * .5) - (BallSize.Height / 2);

				BallPosition = new Point (midX, midY);
				PlayArea = new Size ((int)drawing.ScreenWidth, (int)drawing.ScreenHeight);
				RightPaddleX = (int)(drawing.ScreenWidth - 40);

				LeftPaddleY = (int)((drawing.ScreenHeight * .5) - (PaddleHeight * .5));
				RightPaddleY = LeftPaddleY;

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
			// Variable - ball velocity
			// Compute a new ball position
			// Compute possible collision (top, bottom, P1, P2)
			// Compute new velocity on collsion
		}

		void HandleRules ()
		{
			// Best x of y
			// Handle Reset
				// Ball Pos, Ball Velocity, Paddle Position
			// Handle ball off screen
		}

		void HandleInput (string direction)
		{
			// Need to handle off screen
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
