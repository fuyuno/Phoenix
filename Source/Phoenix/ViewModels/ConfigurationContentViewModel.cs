using Phoenix.Models;
using Phoenix.Mvvm;
using Phoenix.Services.Interfaces;

using Reactive.Bindings;

namespace Phoenix.ViewModels
{
    internal class ConfigurationContentViewModel : ViewModel
    {
        private readonly IConfigurationService _configurationService;

        public ReactiveProperty<int> Interval { get; private set; }

        public ConfigurationContentViewModel(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
            var configuration = _configurationService.Configuration;

            Interval = ReactiveProperty.FromObject(configuration, w => w.Interval, w => (int) w, IntervalExt.ToInterval);
        }
    }
}