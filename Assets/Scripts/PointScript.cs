using UnityEngine;

public class PointScript : MonoBehaviour
{
    private Animator _animator;
    private ParticleSystem _collectBoom;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _collectBoom = transform.Find("CollectBoom").GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _animator.SetTrigger("isCollected");
        if (_collectBoom != null)
        {
            _collectBoom.Play();
        }

        Destroy(gameObject, 0.7f);
    }

}
