using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Foundation;
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
        private string _buttonText;

        public TimerModalViewModel()
        {
            ButtonText = nameof(Dismiss);
        }

        public override string Id => "Timer";

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

            var noTicks = timerObservable.Where(x => x.Ticks == 0).Do(_ => this.Log().Debug("Ticks are Zero"));
            
            noTicks
                .Subscribe(_ =>
                {
                    var notification = new NSUserNotification
                    {
                        Title = $"{TimerValue} minute(s) is up!",
                        InformativeText = "Blast off!!!",
                        DeliveryDate = (NSDate) DateTime.Now,
                        SoundName = NSUserNotification.NSUserNotificationDefaultSoundName,
                        HasActionButton = true
                    };

                    // Make sure the notification fires even if the app is TopMost
                    NSUserNotificationCenter.DefaultUserNotificationCenter.ShouldPresentNotification = (c, n) => true;
                    
                    NSUserNotificationCenter.DefaultUserNotificationCenter.ScheduleNotification(notification);
                    
                    Dismiss.Execute().Subscribe();
                })
                .DisposeWith(ViewModelRegistrations);

            Dismiss = ReactiveCommand.Create(() => this.Log().Debug(nameof(Dismiss)))
                .DisposeWith(ViewModelRegistrations);
        }
    }
}