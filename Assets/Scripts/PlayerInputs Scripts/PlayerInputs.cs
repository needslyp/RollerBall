using UnityEngine;

namespace PlayerInputs_Scripts {
    
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInputs : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        private Vector3 _movement;
        private bool _jump;
        private bool _stop;
        private PlayerMovement _playerMovement;
        
        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }
        
        void Update()
        {
            var vertical = Input.GetAxis(RollerBallInputs.VERTICAL_AXIS);

            _jump = Input.GetButton(RollerBallInputs.JUMP_BUTTON);

            _stop = Input.GetKey(RollerBallInputs.STOP_BUTTON);

            Vector3 forward = cameraTransform.forward;

            forward.y = 0f;
            forward.Normalize();

            _movement = forward * vertical;
        }

        private void FixedUpdate(){
            _playerMovement.MoveCharacter(_movement);
            
            if (_jump && _playerMovement.IsGrounded()) {
                _playerMovement.JumpCharacter();
            }

            if (_stop && _playerMovement.IsGrounded()) {
                _playerMovement.StopCharacter();
            }
        }
    }
}
