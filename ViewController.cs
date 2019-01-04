using System;

using AppKit;
using Foundation;
using SkiaSharp;
using SkiaSharp.Views.Mac;
using TurtleInterface;
using TurtleLogic;

namespace TurtleMover
{
	public partial class ViewController : NSViewController, ITurtleDrawing
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		SKGLView SkiaView;
		SKCanvas CurrentCanvas;
		MyTurtleGame Game;
		NSTimer Timer;
		public long Frame { get; private set; } = 0;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SkiaView = new SKGLView (View.Frame);
			SkiaView.AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable;
			View.AddSubview (SkiaView);

			SkiaView.PaintSurface += OnPaint;

			Game = new MyTurtleGame ();

			StartAnimationTimer ();
		}

		void OnPaint (object sender, SKPaintGLSurfaceEventArgs e)
		{
			CurrentCanvas = e.Surface.Canvas;
			CurrentCanvas.Clear (SKColors.Black);

			Game.OnDraw (Frame, this);
		}

		public void Invalidate ()
		{
			if (SkiaView != null)
				SkiaView.NeedsDisplay = true;
		}

		public void StartAnimationTimer ()
		{
			Timer = NSTimer.CreateRepeatingScheduledTimer (new TimeSpan (0, 0, 0, 0, 33), t => {
				Frame++;
				Invalidate (); // This is a bit lazy				
			});
		}

		SKColor FromColor (Color color) => new SKColor (color.Red, color.Green, color.Blue);

		public void Fill (Color color)
		{
			CurrentCanvas.Clear (FromColor (color));
		}

		public void DrawSquare (Color color, Point point, Size size)
		{
			SKPaint paint = new SKPaint { Color = FromColor (color) };
			CurrentCanvas.DrawRect (new SKRect (point.X, point.Y, point.X + size.Width, point.Y + size.Height), paint);
		}

		public void DrawText (Color color, Point point, string text)
		{
			SKPaint paint = new SKPaint { Color = FromColor (color), TextSize = 18, IsAntialias = true };
			CurrentCanvas.DrawText (text, new SKPoint (point.X, point.Y), paint);
		}
	}
}
