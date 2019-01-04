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

	public static class Colors
	{
		public static readonly Color Red = new Color (255, 0, 0);
		public static readonly Color Green = new Color (0, 255, 0);
		public static readonly Color Blue = new Color (0, 0, 255);
		public static readonly Color White = new Color (255, 255, 255);
		public static readonly Color Black = new Color (0, 0, 0);
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
		void DrawTriangle (Color color, Point point, int rotationDegrees);
		void DrawText (Color color, Point point, string text);
		void DrawTurtle (Point point);
	}
}
