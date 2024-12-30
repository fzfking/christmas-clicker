using Cysharp.Threading.Tasks;

namespace Progress
{
    public interface IPersistentStorage
    {
        UniTask<T> LoadAsync<T>(string key, T defaultValue);
        UniTask SaveAsync<T>(string key, T value);
    }
}