using System.Reactive;
using ReactiveUI;
using Splat;

namespace UI
{
    public class TimerModalViewModel : ViewModelBase
    {
        private string _dialogDescription;
        private string _dialogTitle;

        public string DialogDescription
        {
            get => _dialogDescription;
            set => this.RaiseAndSetIfChanged(ref _dialogDescription, value);
        }

        public string DialogTitle
        {
            get => _dialogTitle;
            set => this.RaiseAndSetIfChanged(ref _dialogTitle, value);
        }

        public ReactiveCommand<Unit, Unit> Dismiss { get; private set; }
        
        protected override void ComposeObservables()
        {
            Dismiss = ReactiveCommand.Create(() => { this.Log().Debug(nameof(Dismiss)); });
        }
    }
}