using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Core.Resources
{
    public class AddressableLoader : ILoader
    {
        public bool TryLoad<T>(string path, out T loadedObject) where T : Object
        {
            // WARNING: Synchronous loading! Not recommended for production use!
            var handle = Addressables.LoadAssetAsync<T>(path);

            handle.WaitForCompletion(); // Blocks the main thread — use only if absolutely necessary

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                loadedObject = handle.Result;
                return true;
            }

            loadedObject = null;
            return false;
        }

        public bool TryLoadAll<T>(string path, out T[] loadedObjects) where T : Object
        {
            var handle = Addressables.LoadAssetsAsync<T>(path, null);

            handle.WaitForCompletion(); // Again, this blocks the main thread

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                loadedObjects = handle.Result as T[];
                return true;
            }

            loadedObjects = null;
            return false;
        }

        public void TryLoadAsync<T>(string path, System.Action<T> callback) where T : Object
        {
            Addressables.LoadAssetAsync<T>(path).Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    callback?.Invoke(handle.Result);
                }
                else
                {
                    Debug.LogError($"Failed to async load: {path} [{typeof(T)}]");
                    callback?.Invoke(null);
                }
            };
        }
        
        public void TryLoadAllAsync<T>(string path, System.Action<T[]> callback) where T : Object
        {
            Addressables.LoadAssetsAsync<T>(path).Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    callback?.Invoke(handle.Result as T[]);
                }
                else
                {
                    Debug.LogError($"Failed to async load: {path} [{typeof(T)}]");
                    callback?.Invoke(null);
                }
            };
        }
    }
}
