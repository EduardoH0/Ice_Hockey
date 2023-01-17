using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Connect to the server
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    // Join the lobby
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    // Load the lobby scene
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    } 
    // Back to home (on button clicked) => Disconnect from the server if already connected
    public void back_home()
    {
        SceneManager.LoadScene("FirstScene");
        try
        {
            PhotonNetwork.Disconnect();
        }
        finally
        {
            Debug.Log("Back to Home");
        }
    }

}
