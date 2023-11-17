using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winManager1 : MonoBehaviour
{
    [SerializeField] Animator animatorWin;
    [SerializeField] GameObject panel;

    [SerializeField] Animator animatorLogo;
    [SerializeField] GameObject Logo;

    private void Start()
    {
        panel.SetActive(true);
        Logo.SetActive(true);
        animatorWin.Play("winFade");
        animatorLogo.Play("GameLogo");
    }
}
