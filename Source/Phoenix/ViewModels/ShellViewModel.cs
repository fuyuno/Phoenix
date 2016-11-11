using System.Windows;
using System.Windows.Input;

using Prism.Commands;

namespace Phoenix.ViewModels
{
    internal class ShellViewModel : ViewModel
    {
        #region ExitCommand

        private ICommand _exitCommand;
        public ICommand ExitCommand => _exitCommand ?? (_exitCommand = new DelegateCommand(Exit));

        private void Exit() => Application.Current.Shutdown();

        #endregion
    }
}