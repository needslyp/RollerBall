using UnityEngine;
using UnityEngine.SceneManagement;

namespace SomeCode
{
    public class NextLevelFloor : MonoBehaviour
    {
        // Next Level If Player Touches Finish 
        private void OnCollisionEnter(Collision collision){
            if (collision.gameObject.CompareTag("Player")){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
