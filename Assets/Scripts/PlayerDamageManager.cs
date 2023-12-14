using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class PlayerDamageManager : MonoBehaviour
{
    [SerializeField] private playerController PlayerController;
    [SerializeField] private GameObject P_GameOver;
    [SerializeField] private List<GameObject> _lifes;

    int life = 3;
    bool isDead = false;
    float currentTime = 0f, startingTime = 2f;
    int collisionCount = 0; // Added variable to track collision count

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collisionCount++; // Increment collision count

            if (_lifes.Count > 0)
            {
                Destroy(_lifes[0]);
                _lifes.RemoveAt(0);
            }

            if (collisionCount < 3) // Teleport for first and second collision
            {
                toDefaultPos();
                life--;
                Debug.Log("Life is decreasing");

                if (life == 0)
                {
                    isDead = true;
                    Debug.Log("isDead is true");
                }

                if (isDead)
                {
                    Renderer playerRenderer = GetComponent<Renderer>();
                    StartCoroutine(DissolvePlayer(playerRenderer));
                    PlayerController.enabled = false;
                    P_GameOver.SetActive(true);

                    life = 3;
                    Debug.Log("U r dead");
                }
            }
            else // Game over on third collision
            {
                isDead = true;
                Renderer playerRenderer = GetComponent<Renderer>();
                StartCoroutine(DissolvePlayer(playerRenderer));
                PlayerController.enabled = false;
                P_GameOver.SetActive(true);

                life = 3;
                Debug.Log("You have lost all your lives. Game over!");
            }
        }
    }

    public void toDefaultPos()
    {
        transform.position = new Vector3(-17, 2, 15);
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