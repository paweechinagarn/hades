using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hades
{
    public class GameplayUI : MonoBehaviour
    {
        public void StartGame()
        {
            gameObject.SetActive(true);
        }

        public void ExitGame()
        {
            SceneManager.LoadSceneAsync("SampleScene");
        }
    }
}
