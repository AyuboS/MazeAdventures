using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Greetings : MonoBehaviour
{
    public Text greet;
    public float fadeSpeed = 0.5f;
    void Start()
    {

    }

    void Update()
    {
        float newAlpha = Mathf.Clamp01(greet.color.a - fadeSpeed * Time.deltaTime);

        greet.color = new Color(greet.color.r, greet.color.g, greet.color.b, newAlpha);

        if (newAlpha <= 0f)
        {
            // Text is fully transparent, you can add additional actions here
            gameObject.SetActive(false);
        }
    }
}
