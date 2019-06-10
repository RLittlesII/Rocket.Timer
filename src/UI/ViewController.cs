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
    public partial class ViewController : ViewControllerBase<TimerViewModel>
    {
        public ViewController(IntPtr handle)
            : base(handle)
        {
            ViewModel = new TimerViewModel();
        }

        public override void PrepareForSegue(NSStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            // Take action based on the segue name
            switch (segue.Identifier)
            {
                case "TimerModalSegue":
                    var dialog = segue.DestinationController as TimerModal;
                    dialog.DialogAccepted += (s, e) =>
                    {
                        Console.WriteLine("Dialog accepted");
                        DismissViewController(dialog);
                    };
                    dialog.Presenter = this;
                    break;
            }
        }
        protected override void ComposeObservable()
        {
            this.WhenAnyObservable(x => x.ViewModel.GetTimerCommand)
                .Do(_ => this.Log().Debug(Constants.TimerModalSegue))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(_ => PerformSegue(Constants.TimerModalSegue, this))
                .DisposeWith(Bindings);
        }

        protected override void BindControls()
        {
            this.OneWayBind(ViewModel, vm => vm.Timer, controller => controller.TimerLabel.StringValue)
                .DisposeWith(Bindings);

            this.BindCommand(ViewModel, vm => vm.GetTimerCommand, controller => controller.TimerButton)
                .DisposeWith(Bindings);
        }
    }
}
