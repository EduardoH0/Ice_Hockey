using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    // public GameObject playerPrefab;
    List<string> name_players = new List<string> {"player", "player2"};
    private List<Vector3> spawnposition = new List<Vector3>() {new Vector3(0.0f, 0.35f, -14.0f), new Vector3(0.0f, 0.35f, 14.0f)};

    public void Start()
    {   
        int numberofP = PhotonNetwork.PlayerList.Length;
        var obj_player = Resources.Load(name_players[numberofP - 1]) as GameObject;
        PhotonNetwork.Instantiate(obj_player.name, spawnposition[numberofP - 1] ,Quaternion.identity);

        // Spawn disk when the host joins the room
        if (numberofP == 1)
        {
            var obj_disk = Resources.Load("disk") as GameObject;
            PhotonNetwork.Instantiate(obj_disk.name, new Vector3(0.0f, 0.25f, 0.0f), Quaternion.identity);
        }
    }
}

