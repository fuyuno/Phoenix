using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;

using Phoenix.Models;
using Phoenix.Mvvm;
using Phoenix.Services.Interfaces;

using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

using Reactive.Bindings.Extensions;

namespace Phoenix.ViewModels
{
    internal class ShellViewModel : ViewModel
    {
        private readonly UpdateChecker _checker;
        private readonly IConfigurationService _configurationService;
        public InteractionRequest<IConfirmation> ConfigurationRequest { get; }
        public InteractionRequest<IConfirmation> UpdateNotificationRequest { get; }

        public ShellViewModel(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
            _configurationService.Load();

            ConfigurationRequest = new InteractionRequest<IConfirmation>();
            UpdateNotificationRequest = new InteractionRequest<IConfirmation>();

            _checker = new UpdateChecker(configurationService).AddTo(this);
            _checker.Softwares
                    .ObserveAddChanged()
                    .Throttle(TimeSpan.FromSeconds(1))
                    .Subscribe(w => OpenNotification());
        }

        private void OpenNotification()
        {
            var softwares = _checker.Softwares.Select(w => new ProgramViewModel(w)).ToList();
            Observable.Return(1)
                      .SubscribeOnUIDispatcher()
                      .Subscribe(w => UpdateNotificationRequest.Raise(new Confirmation {Title = "ソフトウェアアップデート", Content = softwares}));
        }

        #region OpenConfigurationCommand

        private ICommand _openConfigurationCommand;

        public ICommand OpenConfigurationCommand => _openConfigurationCommand ?? (_openConfigurationCommand = new DelegateCommand(OpenConfiguration));

        private void OpenConfiguration()
        {
            ConfigurationRequest.Raise(new Confirmation {Title = "Phoenix 設定"});
        }

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