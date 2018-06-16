using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

using Phoenix.Models.Vaio;
using Phoenix.Services.Interfaces;

namespace Phoenix.Models
{
    internal class UpdateChecker : IDisposable
    {
        private readonly IConfigurationService _configurationService;
        private readonly IDisposable _disposable;
        private readonly Product _product;

        public ObservableCollection<Program> Softwares { get; }

        public UpdateChecker(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
            Softwares = new ObservableCollection<Program>();

            _product = Product.Find(configurationService.Configuration.ModelNumber, configurationService.Configuration.Windows);
            _disposable = Observable.Timer(TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(10)).Subscribe(async w => await CheckUpdate());
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        private async Task CheckUpdate()
        {
            var configuration = _configurationService.Configuration;
            if (configuration.CheckedAt.AddDays(configuration.Interval.ToDays()) > DateTime.Now)
                return;

            try
            {
                await _product.Parse();

                var d = configuration.CheckedAt == DateTime.MinValue ? DateTime.Now : configuration.CheckedAt;

                configuration.CheckedAt = DateTime.Now;
                _configurationService.Save();

                if (_product.Softwares.Count(w => w.Date >= d) == 0)
                    return;

                Softwares.Clear();
                Debug.WriteLine("Updates found");
                foreach (var program in _product.Softwares.Where(w => w.Date >= d))
                    Softwares.Add(program);
            }
            catch (Exception e)
            {
                // Network issue
                Debug.WriteLine(e);
            }
        }
    }
}