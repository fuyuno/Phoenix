using System.Windows;

using Microsoft.Practices.Unity;

using Phoenix.Views;

using Prism.Unity;

namespace Phoenix
{
    internal class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell() => Container.Resolve<Shell>();
    }
}