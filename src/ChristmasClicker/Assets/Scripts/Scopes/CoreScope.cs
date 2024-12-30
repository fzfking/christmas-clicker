using Common.Services;
using Core;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class CoreScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            BindCommonServices(builder);
        }

        private void BindCommonServices(IContainerBuilder builder)
        {
            builder
                .Register<TimeService>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }
    }
}