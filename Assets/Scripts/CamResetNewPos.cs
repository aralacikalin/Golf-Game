using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamResetNewPos : MonoBehaviour {
    public Camera Main;
    public Camera Secondary;
    public Transform Ground;
    public Transform MainCam;
    private bool Istrigger = false;
    public Vector3 Offset;
    	
	
	void Update () {
        if (Istrigger)
        {
            Secondary.enabled = false;
            Main.enabled = true;
            //yeni haritanın yerine camera resetlernir.
            MainCam.position = Ground.position + Offset;

        }
	}
    void OnTriggerEnter(Collider other)
    {
        Istrigger = true; 
    }
    void OnTriggerExit(Collider other)
    {
        Istrigger = false;   
    }
}
