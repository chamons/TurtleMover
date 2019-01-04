using System;
	
namespace TurtleInterface
{
	public interface ITurtleGame
	{
		void OnDraw (long frame, ITurtleDrawing drawing);
		void OnKeyboard (string key);
		void OnClick (Point position);
	}
}
