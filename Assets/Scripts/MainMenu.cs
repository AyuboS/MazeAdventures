using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
   }
   public void QuitGame()
   {
        Application.Quit();
   }
}
