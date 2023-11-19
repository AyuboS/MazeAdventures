using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Greetings : MonoBehaviour
{
    private TextMeshProUGUI greet;
    public float fadeSpeed = 0.5f;
    void Start()
    {
        greet = GetComponent<TextMeshProUGUI>();
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
