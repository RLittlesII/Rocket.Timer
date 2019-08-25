using System.Reflection;
using AppKit;
using Foundation;

[assembly: AssemblyVersion("0.0.0.0")]

namespace UI
{
    /// <summary>
    /// The application delegate.
    /// </summary>
    /// <seealso cref="AppKit.NSApplicationDelegate" />
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        /// <inheritdoc/>
        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
        }

        /// <inheritdoc/>
        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
