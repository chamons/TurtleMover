using System;
using System.IO;
using AppKit;
using CoreGraphics;
using Foundation;
using SkiaSharp;
using SkiaSharp.Views.Mac;
using TurtleInterface;
using TurtleLogic;

namespace TurtleMover
{
	public class CanvasView : SKCanvasView
	{
		public CanvasView (IntPtr p) : base (p)
		{
		}

		public CanvasView (CGRect r) : base (r)
		{
		}

		public override bool AcceptsFirstResponder ()
		{
			return true;
		}
	}

	public partial class ViewController : NSViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		CanvasView SkiaView;
		ITurtleGame Game;
		TurtleDrawer Drawer;
		NSTimer Timer;
		public long Frame { get; private set; } = 0;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SkiaView = new CanvasView (View.Frame);
			SkiaView.AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable;
			View.AddSubview (SkiaView);

			SkiaView.PaintSurface += OnPaint;

			Game = CurrentGame.Game;

			var turtleStream = File.OpenRead (Path.Combine (NSBundle.MainBundle.ResourcePath, "Turtle.png"));
			Drawer = new TurtleDrawer (turtleStream);
			StartAnimationTimer ();
		}

		void OnPaint (object sender, SKPaintSurfaceEventArgs e)
		{
			Drawer.CurrentCanvas = e.Surface.Canvas;

			Drawer.CurrentCanvas.Scale ((float)View.Layer.ContentsScale);
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

		public override void KeyDown (NSEvent theEvent)
		{
			Game.OnKeyboard (ConvertNSEventToKeyString (theEvent));
		}

		string ConvertNSEventToKeyString (NSEvent theEvent)
		{
			switch (theEvent.KeyCode) {
				case (ushort)NSKey.UpArrow:
					return "Up";
				case (ushort)NSKey.DownArrow:
					return "Down";
				case (ushort)NSKey.LeftArrow:
					return "Left";
				case (ushort)NSKey.RightArrow:
					return "Right";
				case (ushort)NSKey.Keypad1:
					return "NumPad1";
				case (ushort)NSKey.Keypad2:
					return "NumPad2";
				case (ushort)NSKey.Keypad3:
					return "NumPad3";
				case (ushort)NSKey.Keypad4:
					return "NumPad4";
				case (ushort)NSKey.Keypad5:
					return "NumPad5";
				case (ushort)NSKey.Keypad6:
					return "NumPad6";
				case (ushort)NSKey.Keypad7:
					return "NumPad7";
				case (ushort)NSKey.Keypad8:
					return "NumPad8";
				case (ushort)NSKey.Keypad9:
					return "NumPad9";
				default:
					return theEvent.Characters;
			}
		}

		Point GetPositionFromEvent (NSEvent theEvent)
		{
			CGPoint p = theEvent.LocationInWindow;
			return new Point ((int)p.X, (int)View.Frame.Height - (int)p.Y);
		}

		public override void MouseDown (NSEvent theEvent)
		{
			Game.OnClick (GetPositionFromEvent (theEvent));
		}

		public override void RightMouseDown (NSEvent theEvent)
		{
			Game.OnClick (GetPositionFromEvent (theEvent));
		}
	}
}
