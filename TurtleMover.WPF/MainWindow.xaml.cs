using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SkiaSharp;
using TurtleMover;
using TurtleInterface;
using TurtleLogic;

namespace TurtleMover.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		TurtleDrawer Drawer;
		ITurtleGame Game;
		System.Windows.Threading.DispatcherTimer Timer;
		public long Frame { get; private set; } = 0;

		public MainWindow ()
		{
			InitializeComponent ();
			KeyDown += OnPlatformKeyDown;

			Game = CurrentGame.Game;

			var turtleStream = Application.GetResourceStream (new Uri ("pack://application:,,,/Turtle.png"));
			Drawer = new TurtleDrawer (turtleStream.Stream);
			StartAnimationTimer ();
		}

		public void Invalidate ()
		{
			SkiaView.InvalidateVisual ();
		}

		public void StartAnimationTimer ()
		{
			Timer = new System.Windows.Threading.DispatcherTimer ();
			Timer.Tick += (o, e) =>
			{
				Frame++;
				Invalidate (); // This is a bit lazy				
			};
			Timer.Interval = new TimeSpan (0, 0, 0, 0, 33);
			Timer.Start ();
		}

		void OnPlatformPaint (object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
		{
			Drawer.CurrentCanvas = e.Surface.Canvas;
			Drawer.CurrentCanvasSize = e.Info.Size;
			Drawer.CurrentCanvas.Clear (SKColors.Black);

			Game.OnDraw (Frame, Drawer);
		}

		void OnPlatformMouseDown (object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			System.Windows.Point p = e.GetPosition (null);
			Game.OnClick (new TurtleInterface.Point ((int)p.X, (int)p.Y));
		}

		void OnPlatformKeyDown (object sender, System.Windows.Input.KeyEventArgs e)
		{
			Game.OnKeyboard (e.Key.ToString ());
		}
	}
}
