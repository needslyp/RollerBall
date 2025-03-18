using UnityEditor.MPE;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameObject messageUI;
    public Animator platformAnimator;

    private bool isAnimate = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            messageUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageUI.SetActive(false);
        }
    }

    // Animate Platform if player press action button
    void Update()
    {
        if (messageUI.activeSelf && Input.GetKey(RollerBallInputs.ACTION_BUTTON) && !isAnimate) {
            RollerBall.Inputs.PlayerMovement player = GameObject.Find("Player").GetComponent<RollerBall.Inputs.PlayerMovement>();
            player.PlayButtonEffect();
            
            platformAnimator.SetTrigger("MovePlatform");
            messageUI.SetActive(false);
            isAnimate = true;
        }
    }
}
