using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 2, -5);
    public float smoothRotationSpeed = 0.125f;
    public float targetRotationX = 30f;

    private Transform playerTransform;
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothRotationSpeed);
        Quaternion targetRotation = Quaternion.Euler(targetRotationX, 0f, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothRotationSpeed);
    }
}
