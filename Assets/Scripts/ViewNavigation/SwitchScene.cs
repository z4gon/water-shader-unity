using UnityEngine;
using UnityEngine.SceneManagement;

namespace ViewNavigation
{
    public class SwitchScene : MonoBehaviour
    {
        public int sceneIndex;

        public void LoadScene()
        {
            var asyncOp = SceneManager.LoadSceneAsync(sceneIndex);
        }
    }
}
