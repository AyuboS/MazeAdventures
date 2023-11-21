using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerDamageManager : MonoBehaviour
{
    [SerializeField] playerController PlayerController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            PlayerController.enabled = false;
            Renderer playerRenderer = GetComponent<Renderer>();
            StartCoroutine(DissolvePlayer(playerRenderer));
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
    }

}
