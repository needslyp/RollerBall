using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollerBall.Inputs {
    
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float speed = 4f;
        [SerializeField, Range(0, 20)] private float jumpPower = 10f;
        private Rigidbody playerRigidbody;
        private bool isGrounded = true;

        private ParticleSystem deathBoom;

        private ParticleSystem buttonBoom;
        private MeshRenderer meshRenderer;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            
            deathBoom = transform.Find("DeathBoom").GetComponent<ParticleSystem>();
            buttonBoom = transform.Find("ButtonBoom").GetComponent<ParticleSystem>();

            meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.enabled = true;
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

        public void StopCharacter(){
            playerRigidbody.velocity = Vector3.zero;
        }

        public bool IsGrounded(){
            return isGrounded;
        }

        public void PlayDeathEffect()
        {
            if (deathBoom != null)
            {
                deathBoom.Play();

                Destroy(deathBoom.gameObject, deathBoom.main.duration);
            }

            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }
        }

        public void PlayButtonEffect()
        {
            if (buttonBoom != null)
            {
                buttonBoom.Play();

                Destroy(buttonBoom.gameObject, buttonBoom.main.duration);
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
