using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Core.Scenes
{
    internal class SceneAddressableLoader : ISceneLoader
    {
        private struct SceneInfo
        {
            public string SceneName;
            public Scene Scene;
            public AsyncOperationHandle<SceneInstance> SceneHandle;
        }

        private readonly List<SceneInfo> _sceneInfos = new();
        
        int ISceneLoader.SceneCount => SceneManager.sceneCount;
        int ISceneLoader.SceneCountInBuildSettings => SceneManager.sceneCountInBuildSettings;

        void ISceneLoader.LoadScene(string name, SceneLoadMode loadMode = SceneLoadMode.Single)
        {
            var op = Addressables.LoadSceneAsync(name, (LoadSceneMode)loadMode);
            
            _sceneInfos.Add(new SceneInfo
            {
                SceneName = name, 
                Scene = SceneManager.GetSceneByName(name), 
                SceneHandle = op
            });
        }

        void ISceneLoader.LoadSceneAsync(string name, Action callback, SceneLoadMode loadMode = SceneLoadMode.Single)
        {
            var op = Addressables.LoadSceneAsync(name, (LoadSceneMode)loadMode);
            
            op.Completed += _ =>
            {
                callback?.Invoke();
            };
            
            _sceneInfos.Add(new SceneInfo
            {
                SceneName = name, 
                Scene = SceneManager.GetSceneByName(name), 
                SceneHandle = op
            });
        }

        void ISceneLoader.UnloadScene(string name, Action callback = null)
        {
            var sceneInfo = _sceneInfos.Find(x => x.SceneName == name);
            
            if(string.IsNullOrEmpty(sceneInfo.SceneName)) return;
            
            Addressables.UnloadSceneAsync(sceneInfo.SceneHandle).Completed += _ => { callback?.Invoke(); };
        }

        void ISceneLoader.UnloadScene(Scene scene, Action callback = null)
        {
            var sceneInfo = _sceneInfos.Find(x => x.Scene == scene);
            
            if(string.IsNullOrEmpty(sceneInfo.SceneName)) return;
            
            Addressables.UnloadSceneAsync(sceneInfo.SceneHandle).Completed += _ => { callback?.Invoke(); };
        }

        Scene ISceneLoader.GetActiveScene()
        {
            return SceneManager.GetActiveScene();
        }

        bool ISceneLoader.SetActiveScene(Scene scene)
        {
            return SceneManager.SetActiveScene(scene);
        }

        Scene ISceneLoader.GetSceneByName(string name)
        {
            return SceneManager.GetSceneByName(name);
        }
        
        Scene ISceneLoader.GetSceneByPath(string path)
        {
            return SceneManager.GetSceneByPath(path);
        }

        Scene ISceneLoader.GetSceneByBuildIndex(int index)
        {
            return SceneManager.GetSceneByBuildIndex(index);
        }

        void ISceneLoader.MoveGameObjectToScene(GameObject go, Scene scene)
        {
            SceneManager.MoveGameObjectToScene(go, scene);
        }
    }
}