using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PhantomDragonStudio.LevelManagement
{
    public class SceneUnload
    {
        public float Progress => aSync.progress;
        
        private AsyncOperation aSync;
        public IEnumerator Unload(int sceneToUnload)
        {
            if (SceneManager.GetActiveScene().buildIndex == sceneToUnload && sceneToUnload != 0)
                aSync = SceneManager.UnloadSceneAsync(sceneToUnload);
            else
                Debug.Log("<color=YELLOW> Persistent Scene cannot be unloaded, only disabled. Skipping Unload Process. </color>");
            yield return aSync;
        }
    }
}