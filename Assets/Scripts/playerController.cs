using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    private const float impulseVelocity = 25f;
    public float speed;
    public Camera cam;
    public Collider planeCollider;
    RaycastHit hit;
    Ray ray;
    public Rigidbody rb;
    Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit))
        {
            if (hit.collider == planeCollider)
            {
                // Calculate the force to apply to the ball.
                Vector3 force = (hit.point - transform.position).normalized * speed;

                // Add the force to the ball's rigidbody.
                GetComponent<Rigidbody>().AddForce(force);
            }
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            animator.enabled = false;
            Debug.Log("isStartAnimDone set 2, 1 ");
        }
    }

}