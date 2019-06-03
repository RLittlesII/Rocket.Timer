using System;

using AppKit;
using Foundation;
using ReactiveUI;

namespace UI
{
    public partial class ViewController : ViewControllerBase<MainViewModel>
    {
        public ViewController(IntPtr handle)
            : base(handle)
        {
            ViewModel = new MainViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        protected override void BindControls()
        {
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }

    public class MainViewModel : ReactiveObject
    {
        private string _timer;

        public string Timer
        {
            get => _timer;
            set => this.RaiseAndSetIfChanged(ref _timer, value);
        }
    }
}
