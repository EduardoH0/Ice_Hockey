using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;


public class manage_goals : MonoBehaviourPunCallbacks
{

    public static bool WasGoal {get; private set;}
    public Rigidbody rb;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        WasGoal = false;
    }  

    // Increment goals when trigger
    private void OnTriggerEnter(Collider other)
    {
        if (!WasGoal)
        {
            if (photonView.IsMine)
            {
                Debug.Log("GOAL");

                if (other.tag == "Goal2")
                {
                    photonView.RPC("Increment_goal", RpcTarget.All, 2);
                    WasGoal = true;
                    StartCoroutine(ResetGame());
                }
                else if (other.tag == "Goal1")
                {
                    photonView.RPC("Increment_goal", RpcTarget.All, 1);
                    WasGoal = true;
                    StartCoroutine(ResetGame());
                }
            }

    
        }
    }


    private IEnumerator ResetGame()
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;

        // Instantiate disk in the middle of the table when there's a goal
        // Cannot just reset position of current bc of issues when changing the disk in the synchronisation
        if (SpawnDisk.current_disk == "Disk")
        {
            Debug.Log("Disk goal");
            GameObject diskGO = GameObject.FindWithTag ("Disk");

            PhotonNetwork.Destroy(diskGO);

            var obj_disk = Resources.Load("disk") as GameObject;
            PhotonNetwork.Instantiate(obj_disk.name, new Vector3(0.0f,0.25f,0.0f), Quaternion.identity);
            obj_disk.GetComponent<Rigidbody>().velocity = new Vector3(0.0f,0.0f,0.0f);

        }
        else if (SpawnDisk.current_disk == "Donut")
        {
            Debug.Log("Donut goal");
            GameObject donutGO = GameObject.FindWithTag ("Donut");

            PhotonNetwork.Destroy(donutGO);

            var obj_disk = Resources.Load("donut") as GameObject;
            PhotonNetwork.Instantiate(obj_disk.name, new Vector3(0.0f,0.25f,0.0f), Quaternion.identity);
            obj_disk.GetComponent<Rigidbody>().velocity = new Vector3(0.0f,0.0f,0.0f);

        }

        // Easiest way to do it if we had only one disk
        // rb.velocity = new Vector3(0.0f,0.0f,0.0f);   
        // rb.position = new Vector3(0.0f,0.25f,0.0f);

        // Reset velocity and position of both strikers to original after each goal
        GameObject obj_player1 = GameObject.FindWithTag ("Player1");
        Rigidbody rbPl1 = obj_player1.GetComponent<Rigidbody>();
        rbPl1.velocity = new Vector3(0.0f,0.0f,0.0f);
        rbPl1.position = new Vector3(0.0f,0.35f,-14.0f);

        GameObject obj_player2 = GameObject.FindWithTag ("PlayerAI");
        Rigidbody rbPl2 = obj_player2.GetComponent<Rigidbody>();
        rbPl2.velocity = new Vector3(0.0f,0.0f,0.0f);
        rbPl2.position = new Vector3(0.0f,0.35f,14.0f);

    }

    [PunRPC]
    void Increment_goal(int whichScore)
    {
        if (whichScore == 1)
        {
            GameManager.player1Score++;
        }
        else
        {
            GameManager.player2Score++;
        }

    }
}
