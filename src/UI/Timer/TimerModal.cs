using System;

namespace UI
{
    public class TimerModal : ViewControllerBase<TimerModalViewModel>
    {
        public TimerModal(IntPtr intPtr)
            : base(intPtr)
        {
            ViewModel = new TimerModalViewModel();
        }

        protected override void ComposeObservable()
        {
        }

        protected override void BindControls()
        {
        }
    }

    public class TimerModalViewModel : ViewModelBase
    {
        protected override void ComposeObservables()
        {
        }
    }
}