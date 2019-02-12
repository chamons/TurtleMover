using System;
using TurtleInterface;

namespace TurtleLogic
{
	public class MyTurtleHelloWorld : ITurtleGame
	{
		Point TurtlePosition = new Point (350, 200);
		Point SquarePosition = new Point (75, 75);
		Size SquareSize = new Size (75, 75);
		Size TurtleSize = new Size (64, 64);
		int CaughtCount = 0;

		Random random = new Random ();

		public void OnDraw (long frame, ITurtleDrawing drawing)
		{
			// when that happens, generate new location for square
			// Bonus: Add counter number times caught
			Color color = Colors.Red; //new Color ((byte)(random.Next () % 256), (byte)(random.Next () % 256), (byte)(random.Next () % 256));
			drawing.Fill (color);

			drawing.DrawSquare (Colors.Green, SquarePosition, SquareSize);
			drawing.DrawText (Colors.White, new Point (16, 16), CaughtCount.ToString ());
			drawing.DrawTurtle (TurtlePosition);
		}

		public void OnKeyboard (string key)
		{
			switch (key) {
			case "Left":
				TurtlePosition = new Point (TurtlePosition.X - 10, TurtlePosition.Y);
				break;
			case "Right":
				TurtlePosition = new Point (TurtlePosition.X + 10, TurtlePosition.Y);
				break;
			case "Up":
				TurtlePosition = new Point (TurtlePosition.X, TurtlePosition.Y - 10);
				break;
			case "Down":
				TurtlePosition = new Point (TurtlePosition.X, TurtlePosition.Y + 10);
				break;
			}

			CheckForCollision ();
		}

		void CheckForCollision ()
		{
			Point upperLeft = TurtlePosition;
			Point upperRight = new Point (TurtlePosition.X + TurtleSize.Width, TurtlePosition.Y);
			Point lowerLeft = new Point (TurtlePosition.X, TurtlePosition.Y + TurtleSize.Height);
			Point lowerRight = new Point (TurtlePosition.X + TurtleSize.Width, TurtlePosition.Y + TurtleSize.Height);

			if (SquareContainsPoint (SquarePosition, SquareSize, upperLeft))
			{
				OnHit ();
			}
			else if (SquareContainsPoint (SquarePosition, SquareSize, upperRight))
			{
				OnHit ();
			}
			else if (SquareContainsPoint (SquarePosition, SquareSize, lowerLeft))
			{
				OnHit ();
			}
			else if (SquareContainsPoint (SquarePosition, SquareSize, lowerRight))
			{
				OnHit ();
			}
			// For each corner of the square
			// If it is within the turtle box
			// collision

			// Create new location for box
			// Increment score
			// Show Score
		}

		void OnHit ()
		{
			CaughtCount += 1;
			SquarePosition = new Point (random.Next (0, 400), random.Next (0, 400));
		}

		bool SquareContainsPoint (Point square, Size size, Point p)
		{
			int left = square.X;
			int right = left + size.Width;
			int top = square.Y;
			int bottom = top + size.Height;
			return left <= p.X && p.X <= right && top <= p.Y && p.Y <= bottom;
		}

		public void OnClick (Point position)
		{

		}
	}
}
