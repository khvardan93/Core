namespace Core.Scenes
{
    public class SceneHolder
    { 
        private ISceneLoader _sceneLoader;

        public SceneHolder()
        {
            _sceneLoader = new SceneBasicLoader();
        }
    }
}
