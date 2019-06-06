using System.Reactive.Disposables;
using ReactiveUI;

namespace UI
{
    public abstract class ViewModelBase : ReactiveObject
    {
        protected ViewModelBase()
        {
            ComposeObservables();
        }

        protected CompositeDisposable ViewModelRegistrations { get; } = new CompositeDisposable();

        protected abstract void ComposeObservables();
    }
}