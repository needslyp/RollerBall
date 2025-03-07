using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollerBall.Inputs {
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField, Range(0,400)] private float sensitivity = 300f;
        private Vector3 cameraOffset;
        private float rotationInput;

        void Start()
        {
            cameraOffset = transform.position - playerTransform.position;
        }

        void Update()
        {
            rotationInput = Input.GetAxis(RollerBallInputs.HORIZONTAL_AXIS) * sensitivity * Time.deltaTime;
        }

        void FixedUpdate()
        {
            cameraOffset = Quaternion.AngleAxis(rotationInput, Vector3.up) * cameraOffset;
            transform.position = playerTransform.position + cameraOffset;
            transform.LookAt(playerTransform.position);
        }   
    }
}