using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hades
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField] private GameObject gameOver;

        public void StartGame()
        {
            gameObject.SetActive(true);
        }

        public void ExitGame()
        {
            SceneManager.LoadSceneAsync("SampleScene");
        }

        public void GameOver()
        {
            gameOver.SetActive(true);
        }
    }
}
