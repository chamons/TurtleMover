using AppKit;
using Foundation;

namespace TurtleMover
{
	[Register ("AppDelegate")]
	public class AppDelegate : NSApplicationDelegate
	{
		public override bool ApplicationShouldTerminateAfterLastWindowClosed (NSApplication sender) => true;
	}
}
