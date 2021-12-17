using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("RyanTest");
    }
    
    public void QuitGame(){
        Application.Quit();
    }

    public void GoToSettings(){
        Time.timeScale = 0f;
    }

    public void GoBack(){
        Time.timeScale = 1f;
    }
}
