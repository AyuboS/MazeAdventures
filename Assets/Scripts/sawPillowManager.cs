using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawPillowManager : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform CoM;

    float rotataSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (CoM)
        {
            rb.centerOfMass = CoM.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime, rotataSpeed);
    }
}
