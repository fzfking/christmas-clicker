using Common.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Progress
{
    public class PlayerPrefsPersistentStorage : IPersistentStorage
    {
        public UniTask<T> LoadAsync<T>(string key, T defaultValue)
        {
            return UniTask.FromResult(PlayerPrefs.HasKey(key) 
                ? Load<T>(key) 
                : defaultValue);
        }

        public UniTask SaveAsync<T>(string key, T value)
        {
            var serialized = SerializerStaticService.Serialize(value);
            PlayerPrefs.SetString(key, serialized);
            PlayerPrefs.Save();
            return UniTask.CompletedTask;
        }

        private T Load<T>(string key)
        {
            var serialized = PlayerPrefs.GetString(key);
            return SerializerStaticService.Deserialize<T>(serialized);
        }
    }
}