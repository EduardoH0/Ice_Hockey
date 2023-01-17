using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_disk : MonoBehaviour
{

    private Rigidbody rb;
    public AudioSource audio_wall;
    public AudioSource audio_player;
    public AudioSource audio_goal;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

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
        if (other.tag == "Goal1" || other.tag == "Goal2")
        {
            Debug.Log("GOAL");
            audio_goal.Play();
        }
    }

}
