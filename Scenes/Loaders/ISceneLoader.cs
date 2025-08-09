using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Scenes
{
    public enum SceneLoadMode
    {
        Single,
        Additive,
    }
    
    internal interface ISceneLoader 
    {
        public int SceneCount { get; }
        public int SceneCountInBuildSettings { get; }

        public void LoadScene(string name, SceneLoadMode loadMode = SceneLoadMode.Single);
        public void LoadSceneAsync(string name, Action callback, SceneLoadMode loadMode = SceneLoadMode.Single);
        public void UnloadScene(string name, Action callback = null);
        public void UnloadScene(Scene scene, Action callback = null);
        public Scene GetActiveScene();
        public bool SetActiveScene(Scene scene);
        public Scene GetSceneByName(string name);
        public Scene GetSceneByPath(string path);
        public Scene GetSceneByBuildIndex(int index);
        public void MoveGameObjectToScene(GameObject go, Scene scene);
    }
}
