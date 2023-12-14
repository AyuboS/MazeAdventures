using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset = new Vector3(0, 2, -5);
    public float smoothFollowSpeed = 5f;
    public float smoothRotationSpeed = 5f;

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;

        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void FixedUpdate()
    {
        if (playerTransform == null)
        {
            return; // Return early if playerTransform is not assigned
        }

        // Smoothly follow the player position
        Vector3 desiredPosition = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.fixedDeltaTime * smoothFollowSpeed);

        // Prevent camera rotation by setting it back to its initial rotation
        transform.rotation = initialRotation;
    }

}
