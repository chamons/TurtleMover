﻿using System;
using TurtleInterface;

namespace TurtleLogic
{
	public class MyTurtleHelloWorld : ITurtleGame
	{
		Point TurtlePosition = new Point (350, 200);
		Point SquarePosition = new Point (75, 75);

		Random random = new Random ();

		public void OnDraw (long frame, ITurtleDrawing drawing)
		{
			// Notice when bump into square
			// when that happens, generate new location for square
			// Bonus: Add counter number times caught
			Color color = Colors.Red; //new Color ((byte)(random.Next () % 256), (byte)(random.Next () % 256), (byte)(random.Next () % 256));
			drawing.Fill (color);
			drawing.DrawText (Colors.White, new Point (200, 200), "Hello World");

			drawing.DrawSquare (Colors.Green, SquarePosition, new Size (75, 75));

			drawing.DrawTriangle (Colors.White, new Point (250, 50), ((int)frame) % 360);

			drawing.DrawTurtle (TurtlePosition);
		}

		public void OnKeyboard (string key)
		{
			switch (key) {
			case "Left":
				TurtlePosition = new Point (TurtlePosition.X - 5, TurtlePosition.Y);
				break;
			case "Right":
				TurtlePosition = new Point (TurtlePosition.X + 5, TurtlePosition.Y);
				break;
			case "Up":
				TurtlePosition = new Point (TurtlePosition.X, TurtlePosition.Y - 5);
				break;
			case "Down":
				TurtlePosition = new Point (TurtlePosition.X, TurtlePosition.Y + 5);
				break;
			}

			CheckForCollision ();
		}

		void CheckForCollision ()
		{
			if (SquareContainsPoint (SquarePosition, new Size (75, 75), TurtlePosition))
			{
				System.Diagnostics.Debug.WriteLine ("Hit!");
			}
			// For each corner of the square
			// If it is within the turtle box
			// collision
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
