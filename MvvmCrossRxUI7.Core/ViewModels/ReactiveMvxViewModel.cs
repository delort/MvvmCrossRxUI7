using MvvmCross.Core.ViewModels;
using ReactiveUI;

namespace MvvmCrossRxUI7.Core.ViewModels
{
    public abstract class ReactiveMvxViewModel : MvxViewModel, IReactiveObject
    {
        public event PropertyChangingEventHandler PropertyChanging;
        void IReactiveObject.RaisePropertyChanging(PropertyChangingEventArgs args)
        {
            PropertyChanging?.Invoke(this, args);
        }
    }
}