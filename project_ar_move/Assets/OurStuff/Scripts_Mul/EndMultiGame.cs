using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;


public class EndMultiGame : MonoBehaviourPunCallbacks
{

    [SerializeField] GameObject endMenu;
    [SerializeField] GameObject endMenuLoss;
    [SerializeField] GameObject GoalScored;


    private int goalsPlayer1 = 0;
    private int goalsPlayer2 = 0;
    private int maxGoal = 2;


    // Display goal text 
    public void goalScreen()
    {
        Debug.Log("Goaaaaaal");
        photonView.RPC("RpcGoal", RpcTarget.All);
    }
    // End game screen
    public void gameEnded()
    {
        Debug.Log("End mode");
        photonView.RPC("RpcShowEnd", RpcTarget.All);
    }
    // End game screen (loss)
    public void gameEndedLoss()
    {
        Debug.Log("End mode");
        photonView.RPC("RpcShowEndLoss", RpcTarget.All);
    }
    // Reset game
    public void playAgain()
    {
        Debug.Log("Playing again game");
        GameManager.player1Score = 0;
        GameManager.player2Score = 0;
        photonView.RPC("RpcShowPlayAgain", RpcTarget.All);
    }
    // Back to home (reset score b4 leaving)
    public void Home()
    {
        Debug.Log("Loading Home Scene");
        GameManager.player1Score = 0;
        GameManager.player2Score = 0;
        photonView.RPC("RpcShowHome", RpcTarget.All);
    }


    void FixedUpdate()
    {   
        // if goal
        if (GameManager.player1Score > goalsPlayer1 || GameManager.player2Score > goalsPlayer2)
        {
            goalScreen();
        }
        // Update score
        goalsPlayer1 = GameManager.player1Score;
        goalsPlayer2 = GameManager.player2Score;
        // If max goals reached
        if (GameManager.player1Score == maxGoal || GameManager.player2Score == maxGoal)
        {
            Debug.Log("End Menu");

            goalsPlayer1 = GameManager.player1Score;
            goalsPlayer2 = GameManager.player2Score;
            
            // Handle win/loss menu loading
            if (photonView.IsMine)
            {
                if (goalsPlayer1>goalsPlayer2)
                {
                    gameEnded();
                    endMenuLoss.SetActive(false);
                    endMenu.SetActive(true);
                }
                else
                {
                    gameEndedLoss();
                    endMenu.SetActive(false);
                    endMenuLoss.SetActive(true);
                }
                
            }
            // Reset score
            GameManager.player1Score = 0;
            GameManager.player2Score = 0;
        }
    }

    [PunRPC]
    IEnumerator RpcGoal()
    {
        GoalScored.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        GoalScored.SetActive(false);

    }

    [PunRPC]
    void RpcShowEnd()
    {
        endMenuLoss.SetActive(true);
        Time.timeScale = 0f;
        // Needed to mantain active the server/client communication (when timeScale = 0)
        // Otherwise, changes made in Pause menu (for instance resuming) would not syncronize with the second player
        PhotonNetwork.MinimalTimeScaleToDispatchInFixedUpdate = 0;
    }

    [PunRPC]
    void RpcShowEndLoss()
    {
        endMenu.SetActive(true);;
        Time.timeScale = 0f;
        // Needed to mantain active the server/client communication (when timeScale = 0)
        PhotonNetwork.MinimalTimeScaleToDispatchInFixedUpdate = 0;
    }

    [PunRPC]
    void RpcShowPlayAgain()
    {
        Time.timeScale = 1f;

        endMenu.SetActive(false);
        endMenuLoss.SetActive(false);

    }

    [PunRPC]
    void RpcShowHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FirstScene");
        PhotonNetwork.Disconnect();
    }

}
