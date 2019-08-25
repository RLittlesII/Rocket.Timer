using System;
using System.Reactive.Disposables;
using ReactiveUI;

namespace UI
{
    /// <summary>
    /// Base view representation.
    /// </summary>
    /// <typeparam name="T">The view model type.</typeparam>
    /// <seealso cref="ReactiveUI.ReactiveView{T}" />
    public abstract class ViewBase<T> : ReactiveView<T>
        where T : class, IReactiveObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewBase{T}"/> class.
        /// </summary>
        /// <param name="intPtr">The int PTR.</param>
        protected ViewBase(IntPtr intPtr)
            : base(intPtr)
        {
        }

        /// <summary>
        /// Gets the bindings.
        /// </summary>
        protected CompositeDisposable Bindings { get; } = new CompositeDisposable();

        /// <summary>
        /// Binds the controls.
        /// </summary>
        protected abstract void BindControls();
    }
}