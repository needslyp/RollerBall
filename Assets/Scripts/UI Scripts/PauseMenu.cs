using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI_Scripts
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject pausePanel;

        public void TogglePause(){
            bool isPaused = Time.timeScale == 0f;
            Time.timeScale = isPaused ? 1f : 0f;
            pausePanel.SetActive(!isPaused);
        }

        public void RestartLevel(){
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadMenu(){
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}
