using System.Windows;

using Microsoft.Practices.Unity;

using Phoenix.Services;
using Phoenix.Services.Interfaces;
using Phoenix.Views;

using Prism.Unity;

using Reactive.Bindings;

namespace Phoenix
{
    internal class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            UIDispatcherScheduler.Initialize();

            Container.RegisterType<IConfigurationService, ConfigurationService>(new ContainerControlledLifetimeManager());
        }

        protected override DependencyObject CreateShell() => Container.Resolve<Shell>();
    }
}