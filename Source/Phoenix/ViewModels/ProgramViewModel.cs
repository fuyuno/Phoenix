using System.Diagnostics;
using System.Windows.Input;

using Phoenix.Models;
using Phoenix.Mvvm;

using Prism.Commands;

namespace Phoenix.ViewModels
{
    internal class ProgramViewModel : ViewModel
    {
        private readonly Program _program;

        public string Name => _program.Name;
        public string Description => _program.Description;
        public string Date => _program.Date.ToString("d");

        public ProgramViewModel(Program program)
        {
            _program = program;
        }

        #region ClickCommand

        private ICommand _clickCommand;
        public ICommand ClickCommand => _clickCommand ?? (_clickCommand = new DelegateCommand(Click));

        private void Click() => Process.Start(_program.Url);

        #endregion
    }
}