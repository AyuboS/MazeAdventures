using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_PillowManager : MonoBehaviour
{
    public float Angle = 2f;
    public float speed = 0.5f;
    public Vector3 pointA = new Vector3(-15f, 0.65f, 9.5f);
    public Vector3 pointB = new Vector3(-15f, 0.65f, 10.8f);

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * Time.fixedDeltaTime, Angle);

        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}


