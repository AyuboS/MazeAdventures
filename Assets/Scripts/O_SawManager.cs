using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_SawManager : MonoBehaviour
{
    public float Angle = 2f;
    public float speed = 0.25f;
    public Vector3 pointA = new Vector3(-14.5f, 0.5f, -2.3f);
    public Vector3 pointB = new Vector3(-16.3f, 0.5f, -2.3f);

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * Time.fixedDeltaTime, Angle);

        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}


