using System.Windows.Input;

using Phoenix.Models;
using Phoenix.Models.Vaio;

using Prism.Commands;

namespace Phoenix.ViewModels
{
    internal class ConfigurationContentViewModel : ViewModel
    {
        #region ParseCommand

        private ICommand _parseCommand;

        public ICommand ParseCommand => _parseCommand ?? (_parseCommand = new DelegateCommand(Parse));

        private async void Parse()
        {
            var vaio = new S111(Windows.Windows81);
            await vaio.Parse();
        }

        #endregion
    }
}