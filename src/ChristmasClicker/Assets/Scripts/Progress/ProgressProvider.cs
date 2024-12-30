using System.Linq;
using Configuration.Models;
using Core.GameResources;
using Core.Managers;
using Core.Producers;
using Cysharp.Threading.Tasks;

namespace Progress
{
    public interface IProgressProvider
    {
        PlayerProgress Progress { get; }
        UniTask FetchAsync(GameConfiguration configuration);
    }

    public class ProgressProvider : IProgressProvider
    {
        private static readonly string ProgressKey = "progress";
        private readonly IPersistentStorage _persistentStorage;

        public PlayerProgress Progress { get; private set; }

        public ProgressProvider(IPersistentStorage persistentStorage)
        {
            _persistentStorage = persistentStorage;
        }

        public async UniTask FetchAsync(GameConfiguration configuration)
        {
            Progress = await _persistentStorage.LoadAsync(ProgressKey, new PlayerProgress());
            var hasChanges = FillMissingProgressItems(Progress, configuration);
            if (hasChanges) 
                await _persistentStorage.SaveAsync(ProgressKey, Progress);
        }

        private bool FillMissingProgressItems(PlayerProgress progress, GameConfiguration gameConfiguration)
        {
            var isChanged = false;
            
            foreach (var resourceConfiguration in gameConfiguration.Resources)
            {
                if (progress.Resources.Any(p => p.Id == resourceConfiguration.Id)) 
                    continue;
                
                progress.Resources.Add(new ResourceData()
                {
                    Id = resourceConfiguration.Id,
                    Value = 0
                });
                isChanged = true;
            }

            foreach (var producerConfiguration in gameConfiguration.Producers)
            {
                if (progress.Producers.Any(p => p.Id == producerConfiguration.Id)) 
                    continue;
                
                progress.Producers.Add(new ProducerData()
                {
                    Id = producerConfiguration.Id,
                    Level = producerConfiguration.UnlockedByDefault
                        ? 1
                        : 0
                });
                isChanged = true;
            }

            foreach (var managerConfiguration in gameConfiguration.Managers)
            {
                if (progress.Managers.Any(p => p.Id == managerConfiguration.Id)) 
                    continue;
                
                progress.Managers.Add(new ManagerData()
                {
                    Id = managerConfiguration.Id,
                    Bought = false
                });
                isChanged = true;
            }

            return isChanged;
        }
    }
}