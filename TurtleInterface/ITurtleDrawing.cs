using System;

namespace TurtleInterface
{
	public struct Color
	{
		public byte Red { get; private set; }
		public byte Green { get; private set; }
		public byte Blue { get; private set; }

		public Color (byte red, byte green, byte blue)
		{
			Red = red;
			Green = green;
			Blue = blue;
		}
	}

	public struct Point
	{
		public int X { get; private set; }
		public int Y { get; private set; }

		public Point (int x, int y)
		{
			X = x;
			Y = y;
		}
	}

	public struct Size
	{
		public int Width { get; private set; }
		public int Height { get; private set; }

		public Size (int width, int height)
		{
			Width = width;
			Height = height;
		}
	}

	public interface ITurtleDrawing
	{
		void Fill (Color color);
		void DrawSquare (Color color, Point point, Size size);
		void DrawText (Color color, Point point, string text);
		void DrawTurtle (Point point);
	}
}
