using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class RestartLevelFloor : MonoBehaviour
{   
    private float restartLevelTime = 2.0f;
    // Restart Level If Player Touches Ground
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RollerBall.Inputs.PlayerMovement player = collision.gameObject.GetComponent<RollerBall.Inputs.PlayerMovement>();
            player.PlayDeathEffect();

            Debug.Log("Player touched");

            StartCoroutine(RestartLevel(restartLevelTime));
        }
    }

    private IEnumerator RestartLevel(float delay){
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
