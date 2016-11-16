using System.Windows;

using Microsoft.Practices.Unity;

using Phoenix.Services;
using Phoenix.Services.Interfaces;
using Phoenix.Views;

using Prism.Unity;

namespace Phoenix
{
    internal class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<IConfigurationService, ConfigurationService>(new ContainerControlledLifetimeManager());
        }

        protected override DependencyObject CreateShell() => Container.Resolve<Shell>();
    }
}