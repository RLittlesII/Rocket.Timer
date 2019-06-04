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

        protected override void BindControls()
        {
            this.OneWayBind(ViewModel, vm => vm.Timer, controller => controller.TimerLabel.StringValue)
                .DisposeWith(Bindings);
        }
    }
}
