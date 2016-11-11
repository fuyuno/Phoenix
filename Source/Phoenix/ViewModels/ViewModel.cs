using System;

using Prism.Mvvm;

namespace Phoenix.ViewModels
{
    internal class ViewModel : BindableBase, IDisposable
    {
        protected ViewModel() {}

        public void Dispose() {}
    }
}