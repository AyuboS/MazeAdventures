using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonsManager : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void B_Setting()
    {
        PausePanel.SetActive(true);

    }

    public void B_Resume()
    {
        animator.Play("Pause1");  
        StartCoroutine(FadeOut());
    }

    public void B_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void Back2MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(0.2f);

        PausePanel.SetActive(false);


    }
}
