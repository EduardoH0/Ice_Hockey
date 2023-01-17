using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class touch_screen : MonoBehaviour
{

    private Touch touch;
    public float speedModifier;
    public Rigidbody rb;
    private float new_x, new_y;

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    void Move()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                var ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out var hit))   
                {
                    var hitPos = hit.point;
                    new_x = hitPos.x;
                    new_y = hitPos.z;

                    // Compute velocity by position displacement
                    rb.velocity = new Vector3((new_x - rb.position.x) * speedModifier, 0.0f, (new_y - rb.position.z) * speedModifier);
                }
            }

            // Reset velocity when the finger is raised
            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                rb.position = new Vector3(rb.position.x, 0.35f, rb.position.z);

            }
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (view.IsMine)
        {
            Move();
        }
    }
}
