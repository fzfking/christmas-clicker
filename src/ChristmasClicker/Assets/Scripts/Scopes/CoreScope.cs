using Common.Services;
using Configuration.Services;
using ContentManagement.Services;
using Core;
using Progress;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class CoreScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        { 
            BindCommonServices(builder);
            BindConfigurationServices(builder);
            BindProgressServices(builder);
        }

        private void BindCommonServices(IContainerBuilder builder)
        {
            builder
                .Register<TimeService>(Lifetime.Singleton)
                .AsImplementedInterfaces();

            builder
                .Register<AddressableContentProvider>(Lifetime.Scoped)
                .AsImplementedInterfaces();
        }

        private void BindConfigurationServices(IContainerBuilder builder)
        {
            builder
                .Register<ConfigurationProvider>(Lifetime.Scoped)
                .AsImplementedInterfaces();
        }

        private void BindProgressServices(IContainerBuilder builder)
        {
            builder
                .Register<PlayerPrefsPersistentStorage>(Lifetime.Scoped)
                .AsImplementedInterfaces();

            builder
                .Register<ProgressProvider>(Lifetime.Scoped)
                .AsImplementedInterfaces();
        }
    }
}