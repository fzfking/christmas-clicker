using Core.Boot;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class BootScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder
                .RegisterEntryPoint<Bootstrapper>();
        }
    }
}