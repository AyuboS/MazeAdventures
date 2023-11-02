using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Quaternion initialRotation;

    private void Start()
    {
        // Store the camera's initial rotation
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Apply the initial rotation to maintain camera's original orientation
        transform.rotation = initialRotation;
    }
}
