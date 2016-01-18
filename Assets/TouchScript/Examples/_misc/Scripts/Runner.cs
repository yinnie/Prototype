/*
 * @author Valentin Simonov / http://va.lent.in/
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using TouchScript.Layers;

namespace TouchScript.Examples
{
    public class Runner : MonoBehaviour
    {
        private static Runner instance;
        private UILayer layer;

        public void LoadNextLevel()
        {
//			SceneManager.LoadScene((SceneManager.GetActiveScene + 1)% SceneManager.sceneCoun);
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }

            layer = GetComponent<UILayer>();

//            if (Application.loadedLevelName == "Examples" && Application.levelCount > 1)
//            {
//                LoadNextLevel();
//            }
        }

        private void OnLevelWasLoaded(int num)
        {
            TouchManager.Instance.AddLayer(layer);
        }
    }
}