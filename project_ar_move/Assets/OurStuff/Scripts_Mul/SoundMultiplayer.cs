using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SoundMultiplayer : MonoBehaviourPunCallbacks
{

    private Rigidbody rb;
    public AudioSource audio_wall;
    public AudioSource audio_player;
    public AudioSource audio_goal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "walls")
        {
            Debug.Log("wall");
            audio_wall.Play();

        }
        else if (coll.gameObject.tag == "Player1")
        {
            Debug.Log("player1");
            audio_player.Play();
        }
        else if (coll.gameObject.tag == "PlayerAI")
        {
            Debug.Log("player2");
            audio_player.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine)
        {
            if (other.tag == "Goal1" || other.tag == "Goal2")
            {
                Debug.Log("GOAL");
                photonView.RPC("Sound_Goal", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    void Sound_Goal()
    {
        audio_goal.Play();
    }

}
