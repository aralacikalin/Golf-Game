using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballmove : MonoBehaviour
{
    private Rigidbody rb;
    private LineRenderer lineRenderer;
    public bool increasing = false;
    public bool Decreasing = false;
    private Vector3 lineZ;
    private bool UpInput;
    public bool developer;
    public Vector3 defaultLine;
    private bool sleep;
    

    [SerializeField]
    
    [Tooltip("asd")]
    [Header("HOHOHO")]
    [Range(0.0F, 100.0F)]
    public float Force = 0F;
    private Vector3 dir;



    // Use this for initialization
    void Awake()
    {
        Time.timeScale = 1;
    }
    [ContextMenu("Start")]
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.15f;
        lineRenderer.endWidth = 0.1f;
        
        
        

    }
    void Update()
    {
        
        Vector3 rbPos = rb.position;
        
        rbPos.z = 0;
        Vector3 mausePos = Input.mousePosition;
        mausePos = Camera.main.ScreenToWorldPoint(mausePos);
        mausePos.z = 0;
        dir = rbPos - mausePos;
        dir.Normalize();
        UpInput = Input.GetButtonUp("Fire1");
        //cizgiyi topun hizasına getiriyor
        lineZ.z = -transform.position.z;

        if (Input.GetButtonDown("Fire1"))
        {
            increasing = true;
            
            
        }
        if (Input.GetButton("Fire1")){
            if ((rb.IsSleeping()&& Time.timeScale==1) || developer)//time.timescale eklendi
            {
                
                lineRenderer.SetPosition(0, mausePos - lineZ);
                lineRenderer.SetPosition(1, rbPos - lineZ);
                
            }
            

        }
        if (increasing)
        {
            Force += Time.unscaledDeltaTime + 1;
            Force = Mathf.Clamp(Force, 0, 100);
            if (Force == 100)
            {
                Decreasing = true;
                increasing = false;
                
            }

        }
        if (Decreasing)
        {
            Force -= Time.unscaledDeltaTime + 1;
            Force = Mathf.Clamp(Force, 0, 100);
            if (Force == 0)
            {
                increasing = true;
                Decreasing = false;
            }

        }

        if (sleep && rb.IsSleeping())
        {
            sleep = false;
            GM.instance.AddAttempt();
        }
        if (UpInput)
        {
            sleep = true;
            increasing = false;
            Decreasing = false;
            if (rb.IsSleeping() || developer)
            {
                rb.AddForce(dir * Force * 15);
                
            }
            Force = 0F;
            lineRenderer.SetPosition(0, defaultLine);//mausepos
            lineRenderer.SetPosition(1, defaultLine);//rbpos


        }

        
            
    }

     


}
	
	
