using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace ContentManagement.Services
{
    public class AddressableContentProvider : IContentProvider
    {
        public async UniTask InitializeAsync()
        {
            await Addressables.InitializeAsync(true);
        }

        public async UniTask<string> LoadTextAsync(string key)
        {
            var operationHandle = Addressables.LoadAssetAsync<TextAsset>(key);
            var textAsset = await operationHandle;
            var content = textAsset.text;
            Addressables.Release(operationHandle);
            return content;
        }

        public async UniTask<T> LoadAsync<T>(string key) where T : Object
        {
            T result = null;
            var keyExists = false;

            try
            {
                foreach (var resourceLocator in Addressables.ResourceLocators)
                    if (resourceLocator.Keys.Contains(key)) 
                        keyExists = true;

                if (!keyExists)
                {
                    Debug.LogWarning($"Error: key {key} not found");
                    return null;
                }

                var operationHandle = Addressables.LoadAssetAsync<T>(key);
                result = await operationHandle;
                return result;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return result;
            }
        }

        public UniTask<GameObject> InstantiateAsync(string key, Transform parent)
        {
            return Addressables
                .InstantiateAsync(key, parent)
                .ToUniTask();
        }

        public void Release<T>(T asset)
        {
            if (asset == null)
            {
                Debug.LogWarning("Asset was null. Nothing to Release.");
                return;
            }

            Addressables.Release(asset);
        }

        public void ReleaseInstance(GameObject instance)
        {
            if (instance == null)
            {
                Debug.LogWarning("Instance was null. Nothing to Release.");
                return;
            }

            Addressables.ReleaseInstance(instance);
        }

        public async UniTask RemoveAsync(string key)
        {
            var operation = Addressables.ClearDependencyCacheAsync(new List<string>() { key }, true);
            await operation.ToUniTask();
        }

        public async UniTask RemoveAsync(IEnumerable<string> keys)
        {
            var operation = Addressables.ClearDependencyCacheAsync(keys, true);
            await operation.ToUniTask();
        }

        public async UniTask ClearAllAsync()
        {
            var handle = Addressables.CleanBundleCache();
            var isSuccess = await handle.ToUniTask();
            Debug.Log($"Bundle cache cleared: {isSuccess}");

            var keysHandle = Addressables.LoadResourceLocationsAsync(string.Empty);
            var result = await keysHandle.Task;
            if (keysHandle.Status == AsyncOperationStatus.Succeeded)
            {
                foreach (var resourceLocation in result)
                {
                    var itemResult = await Addressables.ClearDependencyCacheAsync(resourceLocation, true);
                    var resultText = itemResult ? "successful" : "failed";
                    Debug.Log($"Clear of {resourceLocation.InternalId}|{resourceLocation.PrimaryKey} was {resultText}");
                }
            }
        }
    }
}