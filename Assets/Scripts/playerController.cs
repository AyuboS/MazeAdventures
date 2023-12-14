using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;




public class playerController : MonoBehaviour
{

    private const float impulseVelocity = 25f;

    public float speed = 2f;

    //public float speed;
    public Camera cam;
    //public Collider planeCollider;
    RaycastHit hit;
    Ray ray;
    public Rigidbody rb;
    Animator animator;

    protected Joystick Joystick;
    //protected JoystickManager JoyManager;

    protected bool Jump;
    private Vector3 moveDirection = Vector3.zero;

    private void Awake()
    {
        Time.timeScale = 1;

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        Joystick = FindObjectOfType<Joystick>();

    }

    private void Update()
    {
        Application.targetFrameRate = 90;
    }

    void FixedUpdate()
    {
        //Vector3 movementDirection = new Vector3(Joystick.Horizontal, 0, Joystick.Vertical);
        //ray = new Ray(transform.position, movementDirection);
        //if (Physics.Raycast(ray, out hit))
        //{
        //    Vector3 force = (hit.point - transform.position).normalized * speed;
        //    rb.AddForce(force);
        //}

        rb.AddForce(moveDirection * speed);
    }


    public void MoveLeft(bool isPressed)
    {
        moveDirection = isPressed ? Vector3.left : Vector3.zero;
    }

    public void MoveRight(bool isPressed)
    {
        moveDirection = isPressed ? Vector3.right : Vector3.zero;
    }

    public void MoveUp(bool isPressed)
    {
        moveDirection = isPressed ? Vector3.forward : Vector3.zero;
    }

    public void MoveDown(bool isPressed)
    {
        moveDirection = isPressed ? Vector3.back : Vector3.zero;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            animator.enabled = false;
            Debug.Log("isStartAnimDone set 2, 1 ");
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = Vector3.zero; // Set velocity to zero to prevent further movement
            rb.angularVelocity = Vector3.zero; // Set angular velocity to zero to prevent rotation
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spring"))
        {
            rb.AddForce(Vector3.up * 7f, ForceMode.Impulse);
        }
    }

}