using Phoenix.Models;
using Phoenix.Models.Vaio;
using Phoenix.Mvvm;
using Phoenix.Services.Interfaces;

using Reactive.Bindings;

namespace Phoenix.ViewModels
{
    internal class ConfigurationContentViewModel : ViewModel
    {
        private readonly IConfigurationService _configurationService;
        private readonly Product _product;
        public ReactiveProperty<int> Interval { get; private set; }

        public string Name => _product.Name;

        public string Windows => _product.Windows.ToWinStr();

        public string ModelNumber => _product.ModelNumber;

        public ConfigurationContentViewModel(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
            var configuration = _configurationService.Configuration;

            _product = Product.Find(_configurationService.Configuration.ModelNumber, _configurationService.Configuration.Windows);
            Interval = ReactiveProperty.FromObject(configuration, w => w.Interval, w => (int) w, IntervalExt.ToInterval);
        }
    }
}