using System.Reactive;
using ReactiveUI;
using Splat;

namespace UI
{
    public class MainViewModel : ViewModelBase
    {
        private string _timerValue;
        private string _buttonText;

        public MainViewModel()
        {
            ButtonText = "Start";
        }

        public override string Id => "Rocket Timer";

        public string TimerValue
        {
            get => _timerValue;
            set => this.RaiseAndSetIfChanged(ref _timerValue, value);
        }

        public string ButtonText
        {
            get => _buttonText;
            set => this.RaiseAndSetIfChanged(ref _buttonText, value);
        }

        public ReactiveCommand<Unit, Unit> StartTimerCommand { get; private set; }

        protected override void ComposeObservables()
        {
            StartTimerCommand = ReactiveCommand.Create(() =>
            {
                this.Log().Debug($"Execute {nameof(StartTimerCommand)}");
            });
        }
    }
}