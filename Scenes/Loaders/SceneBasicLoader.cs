using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Scenes
{
    internal class SceneBasicLoader : ISceneLoader
    {
        int ISceneLoader.SceneCount => SceneManager.sceneCount;
        int ISceneLoader.SceneCountInBuildSettings => SceneManager.sceneCountInBuildSettings;

        void ISceneLoader.LoadScene(string name, SceneLoadMode loadMode = SceneLoadMode.Single)
        {
            SceneManager.LoadScene(name, (LoadSceneMode)loadMode);
        }

        void ISceneLoader.LoadSceneAsync(string name, Action callback, SceneLoadMode loadMode = SceneLoadMode.Single)
        {
            var op = SceneManager.LoadSceneAsync(name, (LoadSceneMode)loadMode);
            op.completed += _ =>
            {
                if (op.isDone)
                {
                    callback?.Invoke();
                }
            };
        }

        void ISceneLoader.UnloadScene(string name, Action callback = null)
        {
            var op = SceneManager.UnloadSceneAsync(name);
            op.completed += _ =>
            {
                if (op.isDone)
                {
                    callback?.Invoke();
                }
            };
        }
        
        void ISceneLoader.UnloadScene(Scene scene, Action callback = null)
        {
            var op = SceneManager.UnloadSceneAsync(scene);
            op.completed += _ =>
            {
                if (op.isDone)
                {
                    callback?.Invoke();
                }
            };
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
