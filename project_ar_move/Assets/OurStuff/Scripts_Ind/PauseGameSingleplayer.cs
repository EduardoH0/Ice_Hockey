using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Pause menu handler
public class PauseGameSingleplayer : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void EnterPause()
    {
        Debug.Log("Pause mode");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LeavePause()
    {
        Debug.Log("Resuming game");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;      
    }
    
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FirstScene");
    }

}
