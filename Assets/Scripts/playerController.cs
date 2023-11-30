using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;




public class playerController : MonoBehaviour
{

    private const float impulseVelocity = 7f;

    public float speed = 2f;
    public float rotationSpeed = 400f;
    //public float speed;
    public Camera cam;
    //public Collider planeCollider;
    //RaycastHit hit;
    //Ray ray;
    public Rigidbody rb;
    Animator animator;
    bool isMovable;
    protected Joystick Joystick;
    //protected JoystickManager JoyManager;

    protected bool Jump;


    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        Joystick = FindObjectOfType<Joystick>();
        Invoke("setMovableTrue", 1f);
    }

    //void FixedUpdate()
    //{
    //    ray = cam.ScreenPointToRay(Input.mousePosition);

    //    if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit))
    //    {
    //        if (hit.collider == planeCollider)
    //        {
    //            // Calculate the force to apply to the ball.
    //            Vector3 force = (hit.point - transform.position).normalized * speed;

    //            // Add the force to the ball's rigidbody.
    //            GetComponent<Rigidbody>().AddForce(force);
    //        }
    //    }


    //}

    //void Update()
    //{
    //    // Apply movement based on joystick input
    //    Vector3 movementDirection = new Vector3(Joystick.Horizontal, 0, Joystick.Vertical);

    //    // Normalize movement direction to prevent diagonal movement speedup
    //    movementDirection.Normalize();

    //    // Multiply normalized movement direction by a suitable speed
    //    movementDirection *= 3f;

    //    // Update rigidbody velocity
    //    rb.velocity = movementDirection;

    //    //// Handle jumping logic
    //    //if (!Jump && JoyManager.Pressed)
    //    //{
    //    //    Jump = true;
    //    //    rb.velocity += Vector3.up * 8f;
    //    //}
    //    //else if (Jump && !JoyManager.Pressed)
    //    //{
    //    //    Jump = false;
    //    //}
    //}

    void setMovableTrue()
    {
        isMovable = true;
    }
    void FixedUpdate()
    {
        if (isMovable)
        {
            Vector3 movementDirection = new Vector3(Joystick.Horizontal, 0, Joystick.Vertical);

            if (movementDirection.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                transform.Translate(moveDirection.normalized * speed * Time.deltaTime, Space.World);
            }
            else
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spring"))
        {
            rb.AddForce(Vector3.up * impulseVelocity, ForceMode.Impulse);
        }
    }

}