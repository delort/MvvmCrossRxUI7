using System.Reactive.Concurrency;
using ReactiveUI;

namespace MvvmCrossRxUI7.Core.ViewModels
{
    public class FirstViewModel : ReactiveMvxViewModel
    {
        private string _hello = "Hello MvvmCross";

        private readonly ObservableAsPropertyHelper<bool> _isValid;

        public FirstViewModel()
        {
            this.WhenAnyValue(x => x.Hello, str => !string.IsNullOrWhiteSpace(str))
                .ToProperty(this, x => x.IsValid, out this._isValid);
        }

        public string Hello
        { 
            get { return _hello; }
            set { SetProperty (ref _hello, value); }
        }

        public bool IsValid => _isValid.Value;
    }
}
