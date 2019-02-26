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
		public SKSizeI CurrentCanvasSize { get; set; }

		public double ScreenWidth => CurrentCanvasSize.Width;
		public double ScreenHeight => CurrentCanvasSize.Height;

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

		public void DrawTriangle (Color color, Point point, int rotationDegrees = 0)
		{
			SKPaint paint = new SKPaint { Color = FromColor (color), Style = SKPaintStyle.Fill, IsAntialias = true };

			SKPath path = new SKPath ();

			// TODO - Make the triangle variable size
			path.MoveTo (new SKPoint (point.X, point.Y));
			path.LineTo (new SKPoint (point.X + 100, point.Y));
			path.LineTo (new SKPoint (point.X + 50f, point.Y + 86.6f));
			path.MoveTo (new SKPoint (point.X, point.Y));
			path.Close ();
			CurrentCanvas.Save ();
			CurrentCanvas.RotateDegrees (rotationDegrees, point.X + 50, point.Y + 28.86f);
			CurrentCanvas.DrawPath (path, paint);
			CurrentCanvas.Restore ();
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
