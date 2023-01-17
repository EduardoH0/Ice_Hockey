using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameModeScript : MonoBehaviour
{
    // Select game mode (on button clicked)
    public void SinglePlayerMode()
    {
        Debug.Log("SinglePlayer clicked");
        SceneManager.LoadScene("SinglePlayer");
    }

    public void MultiPlayerMode()
    {
        Debug.Log("MultiPlayer clicked");
        SceneManager.LoadScene("Loading");
    }

    public void CreditsMode()
    {
        Debug.Log("Credits clicked");
        SceneManager.LoadScene("Credits");
    }

}
