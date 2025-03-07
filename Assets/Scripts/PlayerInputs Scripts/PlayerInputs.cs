using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace RollerBall.Inputs {
    
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInputs : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        private Vector3 movement;
        private bool jump;
        private bool stop;
        private PlayerMovement playerMovement;
        
        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
        
        void Update()
        {
            float vertical = Input.GetAxis(RollerBallInputs.VERTICAL_AXIS);

            jump = Input.GetButton(RollerBallInputs.JUMP_BUTTON);

            stop = Input.GetKey(RollerBallInputs.STOP_BUTTON);

            Vector3 forward = cameraTransform.forward;

            forward.y = 0f;
            forward.Normalize();

            movement = forward * vertical;
        }

        private void FixedUpdate(){
            playerMovement.MoveCharacter(movement);
            
            if (jump && playerMovement.IsGrounded()) {
                playerMovement.JumpCharacter();
            }

            if (stop && playerMovement.IsGrounded()) {
                playerMovement.StopCharacter();
            }
        }
    }
}
