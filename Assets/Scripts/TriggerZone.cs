using PlayerInputs_Scripts;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameObject messageUI;
    public Animator platformAnimator;

    private bool _isAnimate = false;
    private GameObject _gameObject;
    private PlayerMovement _player;

    private void Start()
    {
        _player = _gameObject.GetComponent<PlayerMovement>();
        _gameObject = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
        if (messageUI.activeSelf && Input.GetKey(RollerBallInputs.ACTION_BUTTON) && !_isAnimate) {
            _player.PlayButtonEffect();
            
            platformAnimator.SetTrigger("MovePlatform");
            messageUI.SetActive(false);
            _isAnimate = true;
        }
    }
}
