using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform target;
    public Transform topbarrier;
    public Transform bottombarrier;
    public Transform limitbarrier;

    public float speed = 0;
    private float step;
    private float incresespeed = 60;
    private float speedtoincreaceby = 0.1f;
    private float stepup;
    
   

    void Start ()
    {
     
        InvokeRepeating("Timer", 0.001f, incresespeed);
       
	}
	
    
	void Update ()
    {

     

        step = speed * Time.deltaTime;
        stepup = 200 * Time.deltaTime;

        if (topbarrier.transform.position.y >= 1 || bottombarrier.transform.position.y >= 1)
        {

            topbarrier.transform.Translate(0, -step, 0);
            bottombarrier.transform.Translate(0, step, 0);

            if (topbarrier.transform.position.y <= 1 || bottombarrier.transform.position.y >= 1)
            {
                topbarrier.transform.Translate(0, stepup, 0);
                bottombarrier.transform.Translate(0, -stepup, 0);
            }
            
        }

    }


    private void Timer()
    {
        gameObject.SendMessage("IncreaseSpeed", speedtoincreaceby);
    }
    private void IncreaseSpeed(float s)
    {
        speed += s;
    }


}
