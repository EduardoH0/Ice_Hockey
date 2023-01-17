using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueObject : MonoBehaviour
{
    // Variables to handle the change of disk
    public string value;
    public bool change_disk;

    void Start()
    {
        value = "Disk";
        change_disk = false;
    }

}
