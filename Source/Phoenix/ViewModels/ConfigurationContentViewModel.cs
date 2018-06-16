using System;

using Phoenix.Models;
using Phoenix.Models.Vaio;
using Phoenix.Mvvm;
using Phoenix.Services.Interfaces;

using Reactive.Bindings;

namespace Phoenix.ViewModels
{
    internal class ConfigurationContentViewModel : ViewModel
    {
        private readonly Product _product;
        public ReactiveProperty<int> Interval { get; }
        public ReactiveProperty<bool> IsRegistered { get; }

        public string Name => _product.Name;
        public string ModelNumber => _product.ModelNumber;
        public string Windows => _product.Windows.ToWinStr();

        public ConfigurationContentViewModel(IConfigurationService configurationService)
        {
            var configuration = configurationService.Configuration;

            _product = Product.Find(configurationService.Configuration.ModelNumber, configurationService.Configuration.Windows);
            Interval = ReactiveProperty.FromObject(configuration, w => w.Interval, w => (int) w, IntervalExt.ToInterval);
            IsRegistered = new ReactiveProperty<bool>(AppStartup.IsRegistered);
            IsRegistered.Subscribe(w =>
            {
                if (AppStartup.IsRegistered == IsRegistered.Value)
                    return;
                if (AppStartup.IsRegistered)
                    AppStartup.Unregister();
                else
                    AppStartup.Register();
            }).AddTo(this);
        }
    }
}