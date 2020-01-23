using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider : MonoBehaviour {
    [Range(0F,100F)]
    public float Value;
    public Slider a;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GameObject thePlayer = GameObject.Find("ball");
        ballmove BallMove = thePlayer.GetComponent<ballmove>();
        if (Input.GetButtonDown("Fire1")&&Time.timeScale==1)//time.timescale eklendi
        {
            a.gameObject.SetActive(true);
            
        }

        Value = BallMove.Force;
        a.value = Value;
        if (Input.GetButtonUp("Fire1"))
        {
            a.gameObject.SetActive(false);
            
        }

        
    }
}
