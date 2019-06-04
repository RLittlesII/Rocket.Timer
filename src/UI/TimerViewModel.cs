using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using ReactiveUI;

namespace UI
{
    public class TimerViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<TimeSpan> _timer;

        public TimerViewModel(IScheduler scheduler = null)
        {
            var mainScheduler = scheduler ?? RxApp.MainThreadScheduler;

            _timer =
                Observable
                    .Interval(TimeSpan.FromSeconds(1), mainScheduler)
                    .Select(x => TimeSpan.FromSeconds(x))
                    .ToProperty(this, x => x.Timer, TimeSpan.Zero);
        }

        public TimeSpan Timer => _timer.Value;
    }
}