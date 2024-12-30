using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ContentManagement.Services
{
    public interface IContentProvider
    {
        UniTask InitializeAsync();
        UniTask<string> LoadTextAsync(string key);
        UniTask<T> LoadAsync<T>(string key) where T : Object;
        UniTask<GameObject> InstantiateAsync(string key, Transform parent);
        void Release<T>(T asset);
        void ReleaseInstance(GameObject instance);
        UniTask RemoveAsync(string key);
        UniTask RemoveAsync(IEnumerable<string> keys);
        UniTask ClearAllAsync();
    }
}