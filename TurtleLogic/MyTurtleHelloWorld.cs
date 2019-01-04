using System;
using TurtleInterface;

namespace TurtleLogic
{
	public class MyTurtleHelloWorld : ITurtleGame
	{
		Point Position = new Point (350, 200);
		public void OnDraw (long frame, ITurtleDrawing drawing)
		{
			drawing.Fill (Colors.Red);
			drawing.DrawText (Colors.White, new Point (200, 200), "Hello World");
			drawing.DrawSquare (Colors.Green, new Point (75, 75), new Size (75, 75));
			drawing.DrawTriangle (Colors.White, new Point (250, 50), ((int)frame * 2) % 360);
			drawing.DrawTurtle (Position);
		}

		public void OnKeyboard (string key)
		{
			switch (key) {
			case "Left":
				Position = new Point (Position.X - 5, Position.Y);
				break;
			case "Right":
				Position = new Point (Position.X + 5, Position.Y);
				break;
			case "Up":
				Position = new Point (Position.X, Position.Y - 5);
				break;
			case "Down":
				Position = new Point (Position.X, Position.Y + 5);
				break;
			}
		}

		public void OnClick (Point position)
		{

		}
	}
}
