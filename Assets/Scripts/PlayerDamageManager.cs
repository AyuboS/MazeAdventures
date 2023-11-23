using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerDamageManager : MonoBehaviour
{
    [SerializeField] playerController PlayerController;
    [SerializeField] GameObject P_GameOver;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {

            Renderer playerRenderer = GetComponent<Renderer>();
            StartCoroutine(DissolvePlayer(playerRenderer));
            PlayerController.enabled = false;
            P_GameOver.SetActive(true);

        }
    }

    private IEnumerator DissolvePlayer(Renderer playerRenderer)
    {
        // Get the current dissolve value
        float dissolveValue = playerRenderer.material.GetFloat("_Dissolve");

        // Increase the dissolve value by 0.01 each frame until it reaches 1.0f
        while (dissolveValue < 1.0f)
        {
            dissolveValue += 0.01f;
            playerRenderer.material.SetFloat("_Dissolve", dissolveValue);

            yield return new WaitForSeconds(0.01f); // Wait for a small amount of time before increasing the dissolve value again
        }

        Time.timeScale = 0;
    }

}
