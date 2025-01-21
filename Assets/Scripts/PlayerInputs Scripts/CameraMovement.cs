using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        transform.position = playerTransform.position + cameraOffset;
    }
}
