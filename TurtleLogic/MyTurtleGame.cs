using System;
using TurtleInterface;

namespace TurtleLogic
{
	public class MyTurtleGame : ITurtleGame
	{
		const int GroundLevel = 200;
		const int AreaWidth = 400;

		Point TurtlePosition;
		double TurtleVelocity;

		public MyTurtleGame ()
		{
			TurtlePosition = new Point (0, GroundLevel);
			TurtleVelocity = 0;
		}

		public void OnDraw (long frame, ITurtleDrawing drawing)
		{
			HandlePhysics ();

			drawing.Fill (Colors.Black);

			// Pool
			drawing.DrawSquare (Colors.Blue, new Point (200, 250), new Size (70, 25));

			// Ground
			drawing.DrawSquare (new Color (139, 69, 19), new Point (0, 260), new Size (500, 25));

			// Hero
			drawing.DrawTurtle (TurtlePosition);
		}

		public void OnKeyboard (string key)
		{
			if (key == " ") 
				Jump ();
		}

		public void OnClick (Point position)
		{
			Jump ();
		}

		void Jump ()
		{
			// No double jumping
			if (TurtlePosition.Y == GroundLevel)
				TurtleVelocity = 20;
		}

		void HandlePhysics ()
		{
			// Move based on velocity
			TurtlePosition = new Point (TurtlePosition.X + 7, (int)Math.Floor (TurtlePosition.Y - TurtleVelocity));

			// Ground stops them
			if (TurtlePosition.Y > GroundLevel)
				TurtlePosition = new Point (TurtlePosition.X, GroundLevel);

			// Teleport to left size at edge
			if (TurtlePosition.X > AreaWidth)
				TurtlePosition = new Point (0, TurtlePosition.Y);

			// If we're touching ground stop velocity so we don't bounce
			if (TurtlePosition.Y == GroundLevel)
				TurtleVelocity = 0;
			else
				TurtleVelocity -= 2;
		}
	}
}
