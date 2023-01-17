using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;


public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{   
    // need to declare with TMP b4 (Text Mesh Pro)
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    
    // when we create a room we automatically joind the room
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }
    // join the room for the second player
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }
    // have to use this special construction to load the scene of a multiplayer game, instead of LoadScene
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
    // back to home (on button clicked)
    public void BackHome()
    {
        SceneManager.LoadScene("FirstScene");
        PhotonNetwork.Disconnect();
    }
}