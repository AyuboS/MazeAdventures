using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Anim_winManager : MonoBehaviour
{
    [SerializeField] Animator animatorWin;
    [SerializeField] GameObject panel;

    [SerializeField] Animator animatorLogo;
    [SerializeField] GameObject Logo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            panel.SetActive(true);
            Logo.SetActive(true);
            animatorWin.Play("winFade");
            animatorLogo.Play("GameLogo");
            Debug.Log("Jumping");
            StartCoroutine(DelayTeleport());
        }
    }

    IEnumerator DelayTeleport()
    {

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Debug.Log("Teleporting");
    }
}
