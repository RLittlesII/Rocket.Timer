using System.Diagnostics.CodeAnalysis;
using System.Reactive.Disposables;
using ReactiveUI;
using Splat;

namespace UI
{
    /// <summary>
    /// Base view model implementation.
    /// </summary>
    /// <seealso cref="ReactiveUI.ReactiveObject" />
    /// <seealso cref="Splat.IEnableLogger" />
    [SuppressMessage("Microsoft.Usage", "CA2214", Justification = "Verified")]
    public abstract class ViewModelBase : ReactiveObject, IEnableLogger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        protected ViewModelBase()
        {
            ComposeObservables();
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public virtual string Id { get; }

        /// <summary>
        /// Gets the view model registrations.
        /// </summary>
        protected CompositeDisposable ViewModelRegistrations { get; } = new CompositeDisposable();

        /// <summary>
        /// Composes the observables.
        /// </summary>
        protected abstract void ComposeObservables();
    }
}