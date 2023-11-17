using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_PillowManager : MonoBehaviour
{
    private const float Angle = 2f;
    public float speed = 1.19f;
    Vector3 pointA;
    Vector3 pointB;

    void Start()
    {
        pointA = new Vector3(-9.5f, -0.4f, 23.75f);
        pointB = new Vector3(-9.5f, -0.4f, 24.5f);
    }
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * Time.fixedDeltaTime, Angle);

        //float time = Mathf.PingPong(Time.time * speed, 1);
        //transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}


