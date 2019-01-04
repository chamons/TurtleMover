using System;
using System.IO;
using SkiaSharp;
using TurtleInterface;

namespace TurtleMover
{
	public class TurtleDrawer : ITurtleDrawing
	{
		SKBitmap TurtleImage;
		public TurtleDrawer (Stream turtleData)
		{
			TurtleImage = SKBitmap.Decode (turtleData);
		}

		public SKCanvas CurrentCanvas { get; set; }

		SKColor FromColor (Color color) => new SKColor (color.Red, color.Green, color.Blue);
		SKPoint FromPoint (Point point) => new SKPoint (point.X, point.Y);

		public void Fill (Color color)
		{
			CurrentCanvas.Clear (FromColor (color));
		}

		public void DrawSquare (Color color, Point point, Size size)
		{
			SKPaint paint = new SKPaint { Color = FromColor (color) };
			CurrentCanvas.DrawRect (new SKRect (point.X, point.Y, point.X + size.Width, point.Y + size.Height), paint);
		}

		public void DrawTurtle (Point point)
		{
			CurrentCanvas.DrawBitmap (TurtleImage, FromPoint (point));
		}

		public void DrawText (Color color, Point point, string text)
		{
			SKPaint paint = new SKPaint { Color = FromColor (color), TextSize = 18, IsAntialias = true };
			CurrentCanvas.DrawText (text, FromPoint(point),  paint);
		}
	}
}
