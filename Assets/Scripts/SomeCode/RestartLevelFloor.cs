using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelFloor : MonoBehaviour
{
    // Restart Level If Player Touches Ground
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player touched");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
