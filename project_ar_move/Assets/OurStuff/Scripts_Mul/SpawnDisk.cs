using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnDisk : MonoBehaviourPunCallbacks
{

    private Vector3 vel_disk;
    private Vector3 pos_disk;
    // declare static to access via the class (no need to generate instance)
    public static string current_disk;

    public void Start()
    {
        current_disk = "Disk";
    }

    // Spawn blue disk (destroy the current)
    public void spawnbluedisk()
    {
        try
        {
            GameObject donutGO = GameObject.FindWithTag ("Donut");
            pos_disk = donutGO.GetComponent<Rigidbody>().position;
            vel_disk = donutGO.GetComponent<Rigidbody>().velocity;

            PhotonNetwork.Destroy(donutGO);

            var obj_disk = Resources.Load("disk") as GameObject;
            PhotonNetwork.Instantiate(obj_disk.name, pos_disk, Quaternion.identity);
            obj_disk.GetComponent<Rigidbody>().velocity = vel_disk;

            current_disk = "Disk";

        }
        finally
        {

        }
        
    }
    // Spawn the donut (destry current disk)
    public void SpawnDonut()
    {
        try
        {
            GameObject blue_diskGO = GameObject.FindWithTag ("Disk");
            pos_disk = blue_diskGO.GetComponent<Rigidbody>().position;
            vel_disk = blue_diskGO.GetComponent<Rigidbody>().velocity;

            PhotonNetwork.Destroy(blue_diskGO);

            var obj_disk = Resources.Load("donut") as GameObject;
            PhotonNetwork.Instantiate(obj_disk.name, pos_disk, Quaternion.identity);
            obj_disk.GetComponent<Rigidbody>().velocity = vel_disk; 

            current_disk = "Donut";

        }
        finally
        {

        }
        
    }



}
