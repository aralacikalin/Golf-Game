using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {
    public Camera Main;
    public Camera Secondary;
    public Transform Camera;
    public Vector3 Offset;
    public Transform Ball;
    private bool Istrigger = false;
	// Update is called once per frame
	void Update () {
        if (Istrigger) {
            
            Main.enabled = false;
            Secondary.enabled = true;
            Camera.position = Ball.position + Offset;
            
        }
	}
    void OnTriggerEnter(Collider other)
    {
        Istrigger = true;
        GM.instance.levels--;
        GM.instance.CheckLastLevel();
    }
    void OnTriggerExit(Collider other)
    {
        Istrigger = false;    
    }
}
