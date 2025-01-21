using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollerBall.Inputs {
    
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInputs : MonoBehaviour
    {
        private Vector3 movement;
        private bool jump;
        private PlayerMovement playerMovement;
        
        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
        
        void Update()
        {
            float horizontal = Input.GetAxis(RollerBallInputs.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(RollerBallInputs.VERTICAL_AXIS);

            jump = Input.GetButton(RollerBallInputs.JUMP_BUTTON);

            movement = new Vector3(horizontal,0, vertical).normalized;
        }

        private void FixedUpdate(){
            playerMovement.MoveCharacter(movement);
            
            if (jump && playerMovement.IsGrounded()) {
                playerMovement.JumpCharacter();
            }
        }
    }
}
