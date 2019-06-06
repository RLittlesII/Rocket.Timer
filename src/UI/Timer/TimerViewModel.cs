using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;

namespace UI
{
    public class TimerViewModel : ViewModelBase
    {
        private ObservableAsPropertyHelper<TimeSpan> _timer;
        private IScheduler _mainScheduler;

        public TimerViewModel(IScheduler scheduler = null)
        {
            _mainScheduler = scheduler ?? RxApp.MainThreadScheduler;
        }

        public TimeSpan Timer => _timer.Value;
        
        public ReactiveCommand<Unit, Unit> GetTimerCommand { get; private set; }
        
        protected override void ComposeObservables()
        {
            _timer =
                Observable
                    .Interval(TimeSpan.FromSeconds(1), RxApp.MainThreadScheduler)
                    .Select(x => TimeSpan.FromSeconds(x))
                    .ToProperty(this, x => x.Timer, TimeSpan.Zero)
                    .DisposeWith(ViewModelRegistrations);

            GetTimerCommand = ReactiveCommand.Create(() => { });
        }
    }
}