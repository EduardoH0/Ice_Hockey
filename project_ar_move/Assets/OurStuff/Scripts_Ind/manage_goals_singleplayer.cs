using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manage_goals_singleplayer : MonoBehaviour
{
    public score_script ScoreScriptInstance;
    public static bool WasGoal {get; private set;}
    private Rigidbody rb;
    public Rigidbody player;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        WasGoal = false;
    }

    // Increase score when disk collides with the goals
    private void OnTriggerEnter(Collider other)
    {
        if (!WasGoal)
        {
            if (other.tag == "Goal1")
            {
                ScoreScriptInstance.Increment(score_script.Score.Goal1);
                WasGoal = true;
                StartCoroutine(ResetGame());
            }
            else if (other.tag == "Goal2")
            {
                ScoreScriptInstance.Increment(score_script.Score.Goal2);
                WasGoal = true;
                StartCoroutine(ResetGame());

            }
        }
    }

    // Coroutine, reset disk in the middle 1 second after the goal
    private IEnumerator ResetGame()
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.velocity = rb.position = new Vector3(0,0.25f,0);
        player.position = new Vector3(0.0f, 0.35f, -14.0f);
    
    }

}
