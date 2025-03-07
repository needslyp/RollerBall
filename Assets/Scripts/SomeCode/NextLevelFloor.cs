using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelFloor : MonoBehaviour
{
    // Next Level If Player Touches Finish 
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player") && SceneManager.GetActiveScene().buildIndex == 3){
            SceneManager.LoadScene(0);
        }
        else if (collision.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
