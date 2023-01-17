using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;


public class PauseGameMultiplayer : MonoBehaviourPunCallbacks
{

    [SerializeField] GameObject pauseMenu;


    public void EnterPause()
    {
        Debug.Log("Pause mode");
        photonView.RPC("RpcShowPause", RpcTarget.All);
    }

    public void LeavePause()
    {
        Debug.Log("Resuming game");
        photonView.RPC("RpcShowResume", RpcTarget.All);
    }

    public void Home()
    {
        Debug.Log("Loading Home Scene");
        GameManager.player1Score = 0;
        GameManager.player2Score = 0;
        photonView.RPC("RpcShowHome", RpcTarget.All);
    }


    [PunRPC]
    void RpcShowPause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        // Needed to maintain alive the communication between the host and client
        PhotonNetwork.MinimalTimeScaleToDispatchInFixedUpdate = 0;
    }

    [PunRPC]
    void RpcShowResume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    [PunRPC]
    void RpcShowHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FirstScene");
        PhotonNetwork.Disconnect();
    }

}
