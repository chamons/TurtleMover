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
			drawing.DrawSquare (new Color (0, 255, 255), new Point (position, 50), new Size (50, 50));
			drawing.DrawText (new Color (255, 255, 255), new Point (200, 200), "Hello World");
		}
	}
}
