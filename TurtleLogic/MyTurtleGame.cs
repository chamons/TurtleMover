using System;
using TurtleInterface;

namespace TurtleLogic
{
	public class MyTurtleGame
	{
		Point TurtlePosition;

		const int GroundLevel = 100;
		const int AreaWidth = 300;

		public MyTurtleGame ()
		{
			TurtlePosition = new Point (50, GroundLevel);
		}

		public void OnDraw (long frame, ITurtleDrawing drawing)
		{
			HandlePhysics (frame);

			drawing.Fill (Colors.Red);

			drawing.DrawTurtle (TurtlePosition);

			drawing.DrawText (Colors.White, new Point (200, 200), "Hello World");
		}

		void HandlePhysics (long frame)
		{
			int xPos = 50 + (int)(frame * 2 % AreaWidth);
			int yPos = TurtlePosition.Y;
			if (TurtlePosition.Y < GroundLevel)
				yPos += 1;
			TurtlePosition = new Point (xPos, yPos);
		}

		public void OnKeyboard (string key)
		{
			if (key == " ") {
				if (TurtlePosition.Y == GroundLevel)
					TurtlePosition = new Point (TurtlePosition.X, GroundLevel - 50);
			}
		}

		public void OnClick (Point position)
		{

		}
	}
}
