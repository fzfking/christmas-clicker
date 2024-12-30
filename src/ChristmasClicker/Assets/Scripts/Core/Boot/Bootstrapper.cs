using System.Threading;
using Configuration.Services;
using Cysharp.Threading.Tasks;
using Progress;
using VContainer.Unity;

namespace Core.Boot
{
    public class Bootstrapper : IAsyncStartable
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IProgressProvider _progressProvider;

        public Bootstrapper(IConfigurationProvider configurationProvider, 
            IProgressProvider progressProvider)
        {
            _configurationProvider = configurationProvider;
            _progressProvider = progressProvider;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await _configurationProvider.LoadAsync();
            await _progressProvider.FetchAsync(_configurationProvider.GameConfiguration);
        }
    }
}