using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_screen_singleplayer : MonoBehaviour
{

    private Touch touch;
    public float speedModifier;
    public Rigidbody rb;
    private float new_x, new_y;


    void Move()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            // If we move the finger along the screen or just leave it on the screen
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                var ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out var hit))   
                {
                    var hitPos = hit.point;
                    new_x = hitPos.x;
                    new_y = hitPos.z;

                    // Compute velocity of the striker (based on displacement of positions)
                    // New position is automatically computed by unity through the update
                    rb.velocity = new Vector3((new_x - rb.position.x) * speedModifier, 0.0f, (new_y - rb.position.z) * speedModifier);
                }
            }

            // The moment we raise our finger from the screen (reset movement)
            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                rb.position = new Vector3(rb.position.x, 0.35f, rb.position.z);

            }
        }

    }
    // Fixed Update for physics
    void FixedUpdate()
    {
        Move();
    }
}
