using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollerBall.Inputs {
    
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float speed = 2f;
        [SerializeField, Range(0, 20)] private float jumpPower = 10f;
        private Rigidbody playerRigidbody;
        private bool isGrounded = true;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision){
            if (collision.gameObject.CompareTag("Ground")){
                isGrounded = true;
            }
        }

        public void MoveCharacter(Vector3 movement){
            playerRigidbody.AddForce(movement * speed);
        }

        public void JumpCharacter(){
            playerRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isGrounded = false;
        }

        public bool IsGrounded(){
            return isGrounded;
        }

    #if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues(){
            speed = 2f;
            jumpPower = 10f;
        }
    #endif
    }
}
