using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GM : MonoBehaviour {


    public int Attempts = 30;
    public float TimeLeft = 300f;
    public Text TimeLeftText;
    public Text AttemptsText;
    public GameObject TryAgain;
    public static GM instance = null;
    public int levels;
    public GameObject NextLevel;
    public GameObject PauseMenu;
	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        AttemptsText.text= "Attempts Left: " + Attempts;
    }
    public void AddAttempt()
    {
        if (Time.timeScale == 1)//if statement eklendi
        {
            Attempts--;
            AttemptsText.text = "Attempts Left: " + Attempts;
        }
    }
    public void CheckTryAgain()
    {
        if ((TimeLeft < 0 ||Attempts<=0)&&NextLevel.activeInHierarchy==false)
        {
            TryAgain.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void CheckLastLevel()
    {
        if (levels==0)
        {
            NextLevel.SetActive(true);
            

        }
    }
    public void Pause()
    {
        GameObject thePlayer = GameObject.Find("ball");
        ballmove BallMove = thePlayer.GetComponent<ballmove>();
        if (Time.timeScale == 0)
        {
            BallMove.increasing = false;
            BallMove.Decreasing = false;
            BallMove.Force = BallMove.Force * 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1) { 
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
                BallMove.increasing = false;//pause ekranında force eklenmemeisi için eklendi.
                BallMove.Decreasing = false;
                BallMove.Force = BallMove.Force * 0;
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
            }
        }

    }


	
	// Update is called once per frame
	void Update () {
        if (TryAgain.activeInHierarchy == false)
        {
            TimeLeft -= Time.deltaTime;
            TimeLeftText.text = "Time Left: " + Mathf.RoundToInt(TimeLeft);
        }
        CheckTryAgain();
        Pause();
	}
}
