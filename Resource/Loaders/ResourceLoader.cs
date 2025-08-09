using System;
using Object = UnityEngine.Object;

namespace Core.Resources
{
    public class ResourceLoader : ILoader
    {
        public bool TryLoad<T>(string path, out T loadedObject) where T : Object
        {
            loadedObject = UnityEngine.Resources.Load<T>(path);
            return loadedObject;
        }
        
        public bool TryLoadAll<T>(string path, out T[] loadedObject) where T : Object
        {
            loadedObject = UnityEngine.Resources.LoadAll<T>(path);
            return loadedObject != null && loadedObject.Length > 0;
        }
        
        public void TryLoadAsync<T>(string path, Action<T> callback) where T : Object
        {
            var request = UnityEngine.Resources.LoadAsync<T>(path);

            request.completed += _ =>
            {
                if (request.asset is T asset)
                {
                    callback?.Invoke(asset);
                }
                else
                {
                    Logger.Error($"Failed to load resource at path: {path} as type {typeof(T)}");
                    callback?.Invoke(null);
                }
            };
        }

        public void TryLoadAllAsync<T>(string path, Action<T[]> callback) where T : Object
        {
            //couldn't be implemented
        }
    }
}
