using System;
using TurtleInterface;

namespace TurtleLogic
{
	public class MyTurtleGame
	{
		public void OnDraw (long frame, ITurtleDrawing drawing)
		{
			drawing.Fill (new Color (128, 0, 0));

			int position = 50 + (int)(frame * 2 % 300);
			drawing.DrawTurtle (new Point (position, 100));

			//drawing.DrawSquare (new Color (0, 255, 255), , new Size (50, 50));

			drawing.DrawText (new Color (255, 255, 255), new Point (200, 200), "Hello World");
		}
	}
}
