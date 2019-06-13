using System;
using System.Reactive.Disposables;
using Foundation;
using ReactiveUI;

namespace UI
{
    public partial class TimerModal : ViewControllerBase<TimerModalViewModel>
    {
        public TimerModal(IntPtr intPtr)
            : base(intPtr)
        {
            ViewModel = new TimerModalViewModel();
        }

        public ViewController Presenter { get; set; }

        protected override void ComposeObservable()
        {
            this.WhenAnyObservable(x => x.ViewModel.Dismiss)
                .Subscribe(_ =>
                {
                    Presenter?.DismissViewController(this);
                })
                .DisposeWith(Bindings);
        }

        protected override void BindControls()
        {
            this.OneWayBind(ViewModel, vm => vm.Timer, view => view.TimerLabel.StringValue)
                .DisposeWith(Bindings);

            this.BindCommand(ViewModel, vm => vm.Dismiss, modal => modal.DismissButton)
                .DisposeWith(Bindings);
        }

        public event Action<object, object> DialogAccepted;
    }
}