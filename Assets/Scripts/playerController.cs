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


    private void Awake()
    {
        Time.timeScale = 1;
        //Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        Joystick = FindObjectOfType<Joystick>();
        //JoyManager = FindObjectOfType<JoystickManager>();
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

    void Update()
    {

        if (Screen.orientation == ScreenOrientation.Portrait)
        {
            // Set up portrait layout
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            // Set up landscape layout
        }
        Vector3 movementDirection = new Vector3(Joystick.Horizontal, 0, Joystick.Vertical);

        // Apply movement directly to transform position
        transform.position += movementDirection * speed * Time.deltaTime;
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