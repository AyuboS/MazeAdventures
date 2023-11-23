using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    enum CamPosition
    {
        Initial,
        Alternative
    }
    public Transform playerTransform;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public float rotationSpeed = 1.5f;
    public Quaternion targetRotation = Quaternion.Euler(30, 120, 0);

    private Quaternion initialRotation;
    private CamPosition camPosition = CamPosition.Initial;
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

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (camPosition == CamPosition.Initial)
            {
                camPosition = CamPosition.Alternative;
            }
            else
            {
                camPosition = CamPosition.Initial;   
            }   
        }
        if (camPosition == CamPosition.Alternative)
        {
            UpdateRotation(targetRotation);
        }
        else
        {
            UpdateRotation(initialRotation);
        }
        
    }

    //private void FixedUpdate()
    //{
    //    transform.Rotate(Vector3.up * Time.deltaTime * 50f);
    //}
    private void UpdateRotation(Quaternion rotation)
    {
        if (Quaternion.Angle(transform.rotation, rotation) < 0.1f){
            transform.rotation = rotation; 
            return;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
