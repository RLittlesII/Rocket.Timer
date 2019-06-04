using System;
using System.Reactive.Disposables;
using ReactiveUI;

namespace UI
{
    public abstract class ViewControllerBase<T> : ReactiveViewController<T>
        where T : class
    {
        protected CompositeDisposable Bindings { get; } = new CompositeDisposable();
        
        protected ViewControllerBase(IntPtr intPtr)
            : base(intPtr)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            BindControls();
        }

        protected abstract void BindControls();
    }
}
