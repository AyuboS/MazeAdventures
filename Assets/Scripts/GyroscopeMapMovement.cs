using UnityEngine;

public class GyroscopeMapRotation : MonoBehaviour
{
    public float rotationSpeed = 1f;  // Adjust the speed of rotation

    void Update()
    {
        // Check if gyroscope is available
        if (SystemInfo.supportsGyroscope)
        {
            // Get the gyroscope input
            Vector3 gyroInput = -Input.gyro.rotationRateUnbiased; // Negate the values to match phone movement

            // Adjust sensitivity
            gyroInput *= rotationSpeed;

            // Apply the rotation to the map around its center
            transform.Rotate(Vector3.up, gyroInput.x, Space.World);
            transform.Rotate(Vector3.right, gyroInput.y, Space.World);
        }
        else
        {
            Debug.LogWarning("Gyroscope not supported on this device.");
        }
    }
}
