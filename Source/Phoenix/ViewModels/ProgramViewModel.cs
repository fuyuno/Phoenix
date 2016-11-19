using Phoenix.Models;
using Phoenix.Mvvm;

namespace Phoenix.ViewModels
{
    internal class ProgramViewModel : ViewModel
    {
        private readonly Program _program;

        public ProgramViewModel(Program program)
        {
            _program = program;
        }
    }
}