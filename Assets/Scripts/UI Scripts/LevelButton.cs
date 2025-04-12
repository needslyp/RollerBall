using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI_Scripts
{
    public class LevelButton : MonoBehaviour
    {
        public void LoadLevel(int levelIndex)
        {
            SceneManager.LoadScene(levelIndex);
        }
    }
}
