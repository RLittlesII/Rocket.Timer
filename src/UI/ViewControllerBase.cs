using System;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using AppKit;
using Foundation;
using ReactiveUI;
using PropertyChangingEventArgs = ReactiveUI.PropertyChangingEventArgs;
using PropertyChangingEventHandler = ReactiveUI.PropertyChangingEventHandler;

namespace UI
{
    /// <summary>
    /// Base view controller.
    /// </summary>
    /// <typeparam name="T">The view model type.</typeparam>
    /// <seealso cref="ReactiveUI.ReactiveViewController{T}" />
    public abstract class ViewControllerBase<T> : ReactiveViewController<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewControllerBase{T}"/> class.
        /// </summary>
        /// <param name="intPtr">The int PTR.</param>
        protected ViewControllerBase(IntPtr intPtr)
            : base(intPtr)
        {
        }

        /// <summary>
        /// Gets the bindings.
        /// </summary>
        protected CompositeDisposable Bindings { get; } = new CompositeDisposable();

        /// <inheritdoc/>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            BindControls();
            ComposeObservables();
        }

        /// <summary>
        /// Composes the observables.
        /// </summary>
        protected abstract void ComposeObservables();

        /// <summary>
        /// Binds the controls.
        /// </summary>
        protected abstract void BindControls();
    }
}
