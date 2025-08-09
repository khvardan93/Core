using UnityEngine;

namespace Core.Resources
{
    public interface ILoader
    {
        public bool TryLoad<T>(string path, out T loadedObject) where T : Object;
        public bool TryLoadAll<T>(string path, out T[] loadedObject) where T : Object;
        public void TryLoadAsync<T>(string path, System.Action<T> callback) where T : Object;
        public void TryLoadAllAsync<T>(string path, System.Action<T[]> callback) where T : Object;

    }
}
