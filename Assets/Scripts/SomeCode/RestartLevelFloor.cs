using System.Collections;
using PlayerInputs_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SomeCode
{
    public class RestartLevelFloor : MonoBehaviour
    {   
        [SerializeField] private float restartLevelTime = 2.0f;
        // Restart Level If Player Touches Ground
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            
            var player = collision.gameObject.GetComponent<PlayerMovement>();
            player.PlayDeathEffect();

            Debug.Log("Player touched");

            StartCoroutine(RestartLevel(restartLevelTime));
        }

        private IEnumerator RestartLevel(float delay){
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
