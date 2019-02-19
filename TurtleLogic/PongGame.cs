using System;
using TurtleInterface;

namespace TurtleLogic
{
	public class PongGame : ITurtleGame
	{
		public PongGame ()
		{
		}

		public void OnDraw (long frame, ITurtleDrawing drawing)
		{
			drawing.Fill (Colors.Black);

			DrawPaddle (drawing);
			DrawBall (drawing);
			DrawScore (drawing);
			HandlePhysics ();
			HandleRules ();
		}

		void DrawScore (ITurtleDrawing drawing)
		{
			// Variable - two score variable
			// Position to draw
			// Do drawing
		}

		void DrawBall (ITurtleDrawing drawing)
		{
			// Variable - Ball Rectangle
			// Do drawing
		}
	
		void DrawPaddle (ITurtleDrawing drawing)
		{
			// Varible - Paddle Rectangle x 2
			// Do drawing
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
			// The paddle for that direction moves
			// Prevent paddles going off screen
		}

		public void OnKeyboard (string key)
		{
			switch (key)
			{
				case "w":
				case "s":
				case "Up":
				case "Down":
					HandleInput (key);
					return;
			}
		}

		public void OnClick (Point position)
		{
		}
	}
}
