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
		}

		public void OnKeyboard (string key)
		{
		}

		public void OnClick (Point position)
		{
		}
	}
}
