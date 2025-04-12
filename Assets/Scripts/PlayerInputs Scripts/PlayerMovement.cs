using UnityEngine;

namespace PlayerInputs_Scripts {
    
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float speed = 4f;
        [SerializeField, Range(0, 20)] private float jumpPower = 10f;
        private Rigidbody _playerRigidbody;
        private bool _isGrounded = true;

        private ParticleSystem _deathBoom;

        private ParticleSystem _buttonBoom;
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
            
            _deathBoom = transform.Find("DeathBoom").GetComponent<ParticleSystem>();
            _buttonBoom = transform.Find("ButtonBoom").GetComponent<ParticleSystem>();

            _meshRenderer = GetComponent<MeshRenderer>();
            _meshRenderer.enabled = true;
        }

        private void OnCollisionEnter(Collision collision){
            if (collision.gameObject.CompareTag("Ground")){
                _isGrounded = true;
            }
        }

        public void MoveCharacter(Vector3 movement){
            _playerRigidbody.AddForce(movement * speed);
        }

        public void JumpCharacter(){
            _playerRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            _isGrounded = false;
        }

        public void StopCharacter(){
            _playerRigidbody.velocity = Vector3.zero;
        }

        public bool IsGrounded(){
            return _isGrounded;
        }

        public void PlayDeathEffect()
        {
            if (_deathBoom != null)
            {
                _deathBoom.Play();

                Destroy(_deathBoom.gameObject, _deathBoom.main.duration);
            }

            if (_meshRenderer != null)
            {
                _meshRenderer.enabled = false;
            }
        }

        public void PlayButtonEffect()
        {
            if (_buttonBoom != null)
            {
                _buttonBoom.Play();

                Destroy(_buttonBoom.gameObject, _buttonBoom.main.duration);
            }
        }

    #if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues(){
            speed = 4f;
            jumpPower = 10f;
        }
    #endif
    }
}
