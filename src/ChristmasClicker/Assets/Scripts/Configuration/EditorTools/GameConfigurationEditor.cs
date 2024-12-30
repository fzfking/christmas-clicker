#if UNITY_EDITOR
using System.IO;
using Configuration.Models;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using TriInspector;
using UnityEngine;

namespace Configuration.EditorTools
{
    public class GameConfigurationEditor : MonoBehaviour
    {
        public string configurationPath;
        public GameConfiguration gameConfiguration;
        private string Path => Application.dataPath + "/" + configurationPath;

        [Button]
        public async UniTaskVoid FetchOrCreateAsync()
        {
            if (File.Exists(Path))
            {
                gameConfiguration = JsonConvert.DeserializeObject<GameConfiguration>(await File.ReadAllTextAsync(Path));
                Debug.Log($"Fetched configuration from {Path}");
            }
            else
            {
                gameConfiguration = new GameConfiguration();
                Debug.Log($"Created configuration");
                await SaveAsync();
            }
        }

        [Button]
        public async UniTask SaveAsync()
        {
            await File.WriteAllTextAsync(Path, JsonConvert.SerializeObject(gameConfiguration, Formatting.Indented));
            Debug.Log($"Saved {Path}");
        }
    }
}
#endif