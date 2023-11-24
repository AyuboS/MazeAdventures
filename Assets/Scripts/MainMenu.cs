using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject S_L;
    [SerializeField] GameObject L;
    void Update()
    {
        if (Screen.orientation == ScreenOrientation.Portrait)
        {
            // Set up portrait layout
        }
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            // Set up landscape layout
        }
    }
    public void PlayGame()
   {
        foreach (GameObject button in buttons)
        {
            buttons[0].SetActive(false);
            buttons[1].SetActive(false);
        }

        S_L.SetActive(true);
        L.SetActive(true);
   }
   public void QuitGame()
   {
        Application.Quit();
   }
}
