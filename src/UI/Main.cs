using System.Diagnostics.CodeAnalysis;
using AppKit;

namespace UI
{
    [SuppressMessage("DocumentationRules", "SA1649", Justification = "Xamarin.Mac")]
    internal static class MainClass
    {
        private static void Main(string[] args)
        {
            NSApplication.Init();
            NSApplication.Main(args);
        }
    }
}
