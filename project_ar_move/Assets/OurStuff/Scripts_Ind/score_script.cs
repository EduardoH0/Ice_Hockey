using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class score_script : MonoBehaviour
{

    [SerializeField] GameObject endMenu;
    [SerializeField] GameObject endMenuLoss;
    [SerializeField] GameObject goalScreen;


    private int maxGoal = 2;

    public enum Score
    {
        Goal1, Goal2
    }

    public TextMeshProUGUI Goal1txt, Goal2Txt;
    private int goal1, goal2;


    public void Increment(Score whichScore)
    {   
        // Display goal message in the coart
        if (whichScore == Score.Goal1)
        {
            Goal1txt.text = (++goal1).ToString();
            StartCoroutine(GoalScored());
        }
        else
        {
            Goal2Txt.text = (++goal2).ToString();
            StartCoroutine(GoalScored());
        }

        // Activate end menu when we reach the max goals
        if (goal1 == maxGoal)
        {
            Debug.Log("GameEnded");
            // Reset score
            Goal1txt.text = "0";
            Goal2Txt.text = "0";
            goal1 = 0;
            goal2 = 0;
            endMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (goal2 == maxGoal)
        {
            Debug.Log("GameEnded");
            // Reset score
            Goal1txt.text = "0";
            Goal2Txt.text = "0";
            goal1 = 0;
            goal2 = 0;
            endMenuLoss.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void playAgain()
    {
        Debug.Log("Playing again game");
        endMenu.SetActive(false);
        endMenuLoss.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home()
    {
        Debug.Log("Loading Home Scene");
        Time.timeScale = 1f;
        SceneManager.LoadScene("FirstScene");
    }

    // Activate goal message for few seconds
    private IEnumerator GoalScored()
    {
        Debug.Log("Goaaaaaaal");
        goalScreen.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        goalScreen.SetActive(false);
    }

    
}
