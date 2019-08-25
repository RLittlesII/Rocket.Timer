using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using AppKit;
using CoreGraphics;
using Foundation;
using ReactiveUI;
using Splat;
using static AppKit.NSApplication;

namespace UI
{
    /// <summary>
    /// The view controller entry point.
    /// </summary>
    /// <seealso cref="UI.ViewControllerBase{UI.MainViewModel}" />
    public partial class ViewController : ViewControllerBase<MainViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewController"/> class.
        /// </summary>
        /// <param name="handle">The pointer.</param>
        public ViewController(IntPtr handle)
            : base(handle)
        {
            ViewModel = new MainViewModel();
        }

        /// <inheritdoc/>
        public override void PrepareForSegue(NSStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            // Take action based on the segue name
            switch (segue.Identifier)
            {
                case "TimerModalSegue":
                    var dialog = segue.DestinationController as TimerModal;
                    dialog.Presenter = this;
                    dialog.ViewModel.TimerValue = ViewModel.TimerValue;
                    break;
            }
        }

        /// <inheritdoc/>
        protected override void ComposeObservables()
        {
            this.WhenAnyObservable(x => x.ViewModel.StartTimerCommand)
                .Do(_ => this.Log().Debug(Constants.TimerModalSegue))
                .Subscribe(_ => PerformSegue(Constants.TimerModalSegue, this))
                .DisposeWith(Bindings);
        }

        /// <inheritdoc/>
        protected override void BindControls()
        {
            // TODO: See if Bind will work here
            this.WhenAnyValue(x => x.TimeEntryField.StringValue)
                .Throttle(TimeSpan.FromSeconds(.35))
                .Subscribe(x => ViewModel.TimerValue = x)
                .DisposeWith(Bindings);

            this.OneWayBind(ViewModel, vm => vm.Id, controller => controller.Title)
                .DisposeWith(Bindings);

            this.OneWayBind(ViewModel, vm => vm.ButtonText, controller => controller.TimerButton.Title)
                .DisposeWith(Bindings);

            this.BindCommand(ViewModel, vm => vm.StartTimerCommand, controller => controller.TimerButton)
                .DisposeWith(Bindings);
        }
    }
}
