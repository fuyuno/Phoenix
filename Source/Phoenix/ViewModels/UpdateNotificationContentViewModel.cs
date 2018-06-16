using System.Collections.ObjectModel;

using Phoenix.Mvvm;

namespace Phoenix.ViewModels
{
    internal class UpdateNotificationContentViewModel : ViewModel
    {
        public ObservableCollection<ProgramViewModel> Content { get; set; }
    }
}