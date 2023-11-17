using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Scrpt : MonoBehaviour
{
    public Light light;
    public float lightIntencity = 5;
    public float lightRadius = 5;
    private void OnTriggerEnter(Collider other)
    {
        PlayerTrigger colisionTriggered = other.GetComponent<PlayerTrigger>();

        if (colisionTriggered != null)
        {
            light.intensity += lightIntencity;
            light.range += lightRadius;

            colisionTriggered.CubeCollected();
            gameObject.SetActive(false);
        }
    }
}
