using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using Splat;

namespace UI
{
    public class TimerModalViewModel : ViewModelBase
    {
        private ObservableAsPropertyHelper<TimeSpan> _timer;
        private string _dialogDescription;
        private string _dialogTitle;
        private string _timerValue;

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

        public string TimerValue
        {
            get => _timerValue;
            set => this.RaiseAndSetIfChanged(ref _timerValue, value);
        }

        public TimeSpan Timer => _timer.Value;

        public ReactiveCommand<Unit, Unit> Dismiss { get; private set; }

        protected override void ComposeObservables()
        {
            var timerObservable = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Select(x => TimeSpan.FromMinutes(Convert.ToDouble(TimerValue)) - TimeSpan.FromSeconds(x))
                .TakeUntil(x => x.Ticks == 0);

            _timer =
                timerObservable
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .ToProperty(this, x => x.Timer, TimeSpan.FromMinutes(Convert.ToDouble(TimerValue)))
                    .DisposeWith(ViewModelRegistrations);

            timerObservable
                .Where(x => x.Ticks == 0)
                .Do(_ => this.Log().Debug("Ticks are Zero"))
                .Subscribe(_ => { })
                .DisposeWith(ViewModelRegistrations);

            Dismiss = ReactiveCommand.Create(() => this.Log().Debug(nameof(Dismiss)));
        }
    }
}