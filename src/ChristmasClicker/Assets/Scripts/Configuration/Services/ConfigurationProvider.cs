using Configuration.Models;
using ContentManagement.Services;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;

namespace Configuration.Services
{
    public interface IConfigurationProvider
    {
        GameConfiguration GameConfiguration { get; }
        UniTask LoadAsync();
    }

    public class ConfigurationProvider : IConfigurationProvider
    {
        private static readonly string ConfigurationAddress = "gameConfig";
        private readonly IContentProvider _contentProvider;
        public GameConfiguration GameConfiguration { get; private set; }

        public ConfigurationProvider(IContentProvider contentProvider)
        {
            _contentProvider = contentProvider;
        }

        public async UniTask LoadAsync()
        {
            var serializedConfiguration = await _contentProvider.LoadTextAsync(ConfigurationAddress);
            GameConfiguration = JsonConvert.DeserializeObject<GameConfiguration>(serializedConfiguration);
        }
    }
}