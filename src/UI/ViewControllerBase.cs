using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Foundation;
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
            ComposeObservable();
        }

        protected abstract void ComposeObservable();

        protected abstract void BindControls();
    }

    public abstract class ViewBase<T> : ReactiveView<T>
        where T : class, IReactiveObject
    {
        protected CompositeDisposable Bindings { get; } = new CompositeDisposable();

        protected ViewBase(IntPtr intPtr)
            : base(intPtr)
        {
        }

        protected abstract void BindControls();
    }
}
