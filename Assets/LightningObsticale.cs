using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningObsticale : MonoBehaviour
{
    public GameObject lightning;
    public GameObject cubeGate;
    public float lightningRate = 3f;
    private bool turnedOff = false;
    void Start()
    {
        StartCoroutine(turnLightning());
    }

    IEnumerator turnLightning()
    {
       while (true)
        {
            changeLightningVision();
            yield return new WaitForSeconds(lightningRate);
        }
    }

    private void changeLightningVision()
    {
        turnedOff = !turnedOff;
        lightning.SetActive(turnedOff);
        cubeGate.SetActive(turnedOff);
    }
}
