using System.Windows;
using System.Windows.Input;

using Phoenix.Mvvm;
using Phoenix.Services.Interfaces;

using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace Phoenix.ViewModels
{
    internal class ShellViewModel : ViewModel
    {
        private readonly IConfigurationService _configurationService;
        public InteractionRequest<IConfirmation> ConfigurationRequest { get; }

        public ShellViewModel(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
            _configurationService.Load();

            ConfigurationRequest = new InteractionRequest<IConfirmation>();
        }

        #region OpenConfigurationCommand

        private ICommand _openConfigurationCommand;

        public ICommand OpenConfigurationCommand => _openConfigurationCommand ?? (_openConfigurationCommand = new DelegateCommand(OpenConfiguration));

        private void OpenConfiguration() => ConfigurationRequest.Raise(new Confirmation {Title = "Phoenix 設定"});

        #endregion

        #region ExitCommand

        private ICommand _exitCommand;
        public ICommand ExitCommand => _exitCommand ?? (_exitCommand = new DelegateCommand(Exit));

        private void Exit()
        {
            _configurationService.Save();
            Application.Current.Shutdown();
        }

        #endregion
    }
}