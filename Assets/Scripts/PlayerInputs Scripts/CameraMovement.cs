using UnityEngine;

namespace PlayerInputs_Scripts {
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField, Range(0,400)] private float sensitivity = 300f;
        private Vector3 _cameraOffset;
        private float _rotationInput;

        void Start()
        {
            _cameraOffset = transform.position - playerTransform.position;
        }

        void Update()
        {
            _rotationInput = Input.GetAxis(RollerBallInputs.HORIZONTAL_AXIS) * sensitivity * Time.deltaTime;
        }

        void FixedUpdate()
        {
            _cameraOffset = Quaternion.AngleAxis(_rotationInput, Vector3.up) * _cameraOffset;
            transform.position = playerTransform.position + _cameraOffset;
            transform.LookAt(playerTransform.position);
        }   
    }
}