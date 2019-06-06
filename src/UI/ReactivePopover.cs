using System;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;
using AppKit;
using ReactiveUI;
using PropertyChangingEventArgs = ReactiveUI.PropertyChangingEventArgs;
using PropertyChangingEventHandler = ReactiveUI.PropertyChangingEventHandler;

namespace UI
{
    public abstract class ReactivePopover : NSPopover, IViewFor, IReactiveNotifyPropertyChanged<ReactivePopover>,
        IHandleObservableErrors, IReactiveObject, ICanActivate
    {
        private IObservable<EventPattern<PropertyChangedEventArgs>> _propertyChanged;

        public ReactivePopover()
        {
            _propertyChanged = Observable
                .FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    handler => PropertyChanged += handler,
                    handler => PropertyChanged -= handler);
        }
        public object ViewModel { get; set; }
        public IDisposable SuppressChangeNotifications() => throw new NotImplementedException();

        public IObservable<IReactivePropertyChangedEventArgs<ReactivePopover>> Changing { get; }
        public IObservable<IReactivePropertyChangedEventArgs<ReactivePopover>> Changed { get; }
        public IObservable<Exception> ThrownExceptions { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
        public void RaisePropertyChanging(PropertyChangingEventArgs args)
        {
            throw new NotImplementedException();
        }

        public void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            throw new NotImplementedException();
        }

        public IObservable<Unit> Activated { get; }
        public IObservable<Unit> Deactivated { get; }
    }
}