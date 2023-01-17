using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIscript : MonoBehaviour
{


    public float MaxMovementSpeed;
    private Rigidbody rb;

    public GameObject blue_disk;
    public GameObject donut;

    private Rigidbody disk;

    private Vector3 startingPosition;
    private Vector3 vel_disk;
    private Vector3 pos_disk;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // INIT default disk (blue disk)
        disk = blue_disk.GetComponent<Rigidbody>();
        startingPosition = rb.position;
    }

    // Load blue disk (on button clicked)
    public void load_disk()
    {

        // Store current disk velocity and position
        vel_disk = disk.velocity;
        pos_disk = disk.position;

        // Deactive current disk
        donut.SetActive(false);

        GameObject stop_game = GameObject.FindWithTag ("BoolValue");
        stop_game.GetComponent<ValueObject>().value = "Disk";
        stop_game.GetComponent<ValueObject>().change_disk = true;

    }

    // Load donut disk (on button clicked)
    public void load_donut()
    {
        
        // Store current disk velocity and position
        vel_disk = disk.velocity;
        pos_disk = disk.position;

        // Deactive current disk
        blue_disk.SetActive(false);

        GameObject stop_game = GameObject.FindWithTag ("BoolValue");
        stop_game.GetComponent<ValueObject>().value = "Donut";
        stop_game.GetComponent<ValueObject>().change_disk = true;

    }

    // DISPLAY new disk (on resume button clicked)
    public void display_disk()
    {
        GameObject stop_game = GameObject.FindWithTag ("BoolValue");
        if (stop_game.GetComponent<ValueObject>().change_disk == true)
        {
            if (stop_game.GetComponent<ValueObject>().value == "Disk")
            {
                blue_disk.SetActive(true);
                disk = blue_disk.GetComponent<Rigidbody>();
                disk.position = pos_disk;
                disk.velocity = vel_disk;
            }
            else if (stop_game.GetComponent<ValueObject>().value == "Donut")
            {
                donut.SetActive(true);
                disk = donut.GetComponent<Rigidbody>();
                disk.position = pos_disk;
                disk.velocity = vel_disk;
            }
        }
        
        stop_game.GetComponent<ValueObject>().change_disk = false;

    }

    // AI player 2 code
    private void FixedUpdate()
    { 
        float movementSpeed;
        float randomerror; // introduce some variance in x axis

        movementSpeed = MaxMovementSpeed * Random.Range(1.0f, 1.0f);
        randomerror   = Random.Range(0.0f, 0.3f);

        System.Random rand = new System.Random();
        int r1 = rand.Next(-1, 1);
        int r2 = rand.Next(-1, 1);   

        randomerror = (float)r1 * (float)r2 * randomerror;


        // Avoid striker out of the limits of its table side
        if (disk.position.z > 0.0f && disk.position.z < 20)
        {
            // Compute the velocity of the AI striker
            rb.velocity = new Vector3((disk.position.x - rb.position.x + randomerror) * movementSpeed * 0.7f, 0.0f, (disk.position.z - rb.position.z + 1.5f) * movementSpeed * 0.7f);
        }

        else
        {
            // When the disk is not on its half of the table, move the AI striker to the original position
            rb.velocity = new Vector3((startingPosition.x - rb.position.x) * movementSpeed, 0.0f, (startingPosition.z - rb.position.z) * movementSpeed);
        }
        

    }
}
