using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourtTexture : MonoBehaviour
{


    public Material BlackCourt;
    public Material ZebraCourt;
    public Material OrangeCourt;
    public Material FlowerCourt;



    // Load materials (on button clicked)
    public void black_texture()
    {
        GameObject CourtGameObject = GameObject.FindWithTag ("CourtBoard");
        CourtGameObject.GetComponent<Renderer>().material = BlackCourt;
    }

    public void zebra_texture()
    {
        GameObject CourtGameObject = GameObject.FindWithTag ("CourtBoard");
        CourtGameObject.GetComponent<Renderer>().material = ZebraCourt;
    }

    public void flower_texture()
    {
        GameObject CourtGameObject = GameObject.FindWithTag ("CourtBoard");
        CourtGameObject.GetComponent<Renderer>().material = FlowerCourt;
    }

    public void orange_texture()
    {
        GameObject CourtGameObject = GameObject.FindWithTag ("CourtBoard");
        CourtGameObject.GetComponent<Renderer>().material = OrangeCourt;
    }

}
