using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystick_movement : MonoBehaviour
{

    Transform cam;
    public Joystick joystickMove;
    public Rigidbody rb;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }
    
    void Move()
    {
        // rb.velocity = new Vector3(joystickMove.Horizontal * speed, rb.velocity.y, joystickMove.Vertical *speed);
        rb.velocity = new Vector3(joystickMove.Horizontal * speed, 0, joystickMove.Vertical *speed);

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
