using Phoenix.Mvvm;

using Reactive.Bindings;

namespace Phoenix.ViewModels
{
    internal class ConfigurationContentViewModel : ViewModel
    {
        public ReactiveProperty<int> Interval { get; private set; }

        public ConfigurationContentViewModel()
        {
            Interval = new ReactiveProperty<int>(0);
        }
    }
}