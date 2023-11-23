using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonManager : MonoBehaviour
{

    [SerializeField] GameObject cannonBallPrefab;
    [SerializeField] Transform cannonBallSpawnPoint;

    public float cannonBallSpeed = 20f;
    public float fireRate = 4f; // Adjust this value to change the firing interval

    private void Start()
    {
        StartCoroutine(FireCannonBalls());
    }

    IEnumerator FireCannonBalls()
    {
        while (true)
        {
            FireCannonBall();
            yield return new WaitForSeconds(fireRate);
        }
    }

    void FireCannonBall()
    {
        GameObject cannonBall = Instantiate(cannonBallPrefab, cannonBallSpawnPoint.position, cannonBallSpawnPoint.rotation);
        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();

        if (!rb)
        {
            rb = cannonBall.AddComponent<Rigidbody>();
        }

        rb.velocity = cannonBallSpeed * cannonBallSpawnPoint.forward;

        StartCoroutine(DestroyCannonBall(cannonBall));
    }

    IEnumerator DestroyCannonBall(GameObject ball)
    {
        yield return new WaitForSeconds(2f);
        Destroy(ball);
    }
}
