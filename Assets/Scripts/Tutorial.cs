using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public GameObject Tut;
    public Text tutorialText;
    private int touchCount=0;
    private int touchDonw = 0;
    public Text tip;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        GameObject thePlayer = GameObject.Find("ball");
        ballmove BallMove = thePlayer.GetComponent<ballmove>();
        if (Input.GetButtonUp("Fire1"))
        {
            touchCount++;
        }
        switch(touchCount){
            case 0:
                tutorialText.text = "In order to move the ball touch in the opposite direction of the desired one.";
                
                break;
            case 1:
                Tut.SetActive(false);
                break;
            case 2:
                Tut.SetActive(true);
                tip.text = "";
                tutorialText.text = "The force of the push is determined by the power bar in the up left corner of the screen which can be seen when holding the touch.";
                
                break;
            case 3:
                Tut.SetActive(false);
                break;
            case 4:
                Tut.SetActive(true);
                tutorialText.text = "You cant push the ball again before it stops completly.";
                
                break;
            case 5:
                Tut.SetActive(false);
                break;

        }
        if (Input.GetButtonDown("Fire1"))
        {
            touchDonw++;
        }
        switch (touchDonw)
        {
            case 0:
                
                break;
            case 1:
                BallMove.Force = BallMove.Force * 0;
                BallMove.increasing = false;
                BallMove.Decreasing = false;
                break;
            case 2:
                
                
                break;
            case 3:
                BallMove.Force = BallMove.Force * 0;
                BallMove.increasing = false;
                BallMove.Decreasing = false;
                break;
            case 4:
                
                
                break;
            case 5:
                BallMove.Force = BallMove.Force * 0;
                BallMove.increasing = false;
                BallMove.Decreasing = false;
                break;
        }
	}
}
