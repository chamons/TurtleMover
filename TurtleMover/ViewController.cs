using System;
using System.IO;
using AppKit;
using Foundation;
using SkiaSharp;
using SkiaSharp.Views.Mac;
using TurtleInterface;
using TurtleLogic;

namespace TurtleMover
{
	public partial class ViewController : NSViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		SKGLView SkiaView;
		MyTurtleGame Game;
		TurtleDrawer Drawer;
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

			var turtleStream = File.OpenRead (Path.Combine (NSBundle.MainBundle.ResourcePath, "Turtle.png"));
			Drawer = new TurtleDrawer (turtleStream);
			StartAnimationTimer ();
		}

		void OnPaint (object sender, SKPaintGLSurfaceEventArgs e)
		{
			Drawer.CurrentCanvas = e.Surface.Canvas;
			Drawer.CurrentCanvas.Clear (SKColors.Black);

			Game.OnDraw (Frame, Drawer);
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
	}
}
