using System;
using System.Reactive.Disposables;
using AppKit;
using Foundation;
using ReactiveUI;

namespace UI
{
    public partial class ViewController : ViewControllerBase<TimerViewModel>
    {
        public ViewController(IntPtr handle)
            : base(handle)
        {
            ViewModel = new TimerViewModel();
        }

        protected override void ComposeObservable()
        {
            this.WhenAnyObservable(x => x.ViewModel.GetTimerCommand)
                .Subscribe(_ => PresentViewControllerAsModalWindow(new TimerModal(Handle)))
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
