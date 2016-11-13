using System.Windows.Input;

using Phoenix.Models;
using Phoenix.Models.Vaio;
using Phoenix.Mvvm;

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
            var vaio = new S131(Windows.Windows7);
            await vaio.Parse();
        }

        #endregion
    }
}