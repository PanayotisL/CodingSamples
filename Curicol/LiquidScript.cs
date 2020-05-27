using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;




public class LiquidScript : MonoBehaviour
{
    //variables for the freezing and warming indicators
    public GameObject freezeim;
    public GameObject warmim;

    //bug fixer to get the actual script from the manager.
    public LiquidScript liq;

    //gravity and movement variables
    public Transform Liquid;
    public float normalgrav = -9.81f;


    //warming variables
    public float temperature;
    private float moved1, moved2, difference;
  

    //a static variable for the form of liquid
    public static int form;

    //variables to use for micTesting/blowing mechanic
    public micTest mic;
    public int test;
    public int formtype;

    //variables for freezing
    public bool bl=false;
    public bool af=true;

    public manager Manager;
    public int counter;

    // Use this for initialization
    void Start()
    {

        temperature = 2;
        form = 0;
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Manager = GameObject.FindWithTag("Manager").GetComponent<manager>();
        counter = Manager.counter;


        if (counter >= 9)//use this so the user can't change the temperature before all the liquids spawn
        {
            warming();//run warming function on update
            if (bl == true)//if blowing function is active
            {
                //Get the variable of the micTest script and store it
                mic = GameObject.FindWithTag("Manager").GetComponent<micTest>();
                test = mic.test;
                //if its set on 1(true) then decrease temperature
                if (test == 1)
                {

                    temperature = temperature - 1f;
                    if (temperature <= -6)
                    {
                        temperature = -6;
                    }
                }

            }

            if (af == true)//if autofreeze function is active
            {
                //decrease temperature over time
                temperature -= Time.deltaTime;


            }
        }
        //if temperature is less than -6 or bigger than 12 make it equal to each respectively
        if (temperature <= -6)
        {
            temperature = -6;
        }
        if (temperature >= 12)

        {
            temperature = 12;
        }


        //make the screen orientation into landscape only
        Screen.orientation = ScreenOrientation.Landscape;
        //get the gyrocsope's input in x axis and update gravity in y axis depending if steam or liquid is used
        Vector3 newGravg = Input.gyro.gravity;
        newGravg.z = 0;
        newGravg.y = normalgrav;
        newGravg.x = newGravg.x * 9;
        //use the vector we created with the 3 variables above to edit our gravity's direction
        Physics.gravity = Vector3.Lerp(newGravg, Physics.gravity, Time.deltaTime);



        {
           

            //If the temperature is higher or equal to 6 then use function steam
            if (temperature >= 6)
            {
                warmim.SetActive(true);//activate warm image
                freezeim.SetActive(false);//deactivate freeze image
                steam();
            }
            //If the temperature is lower than 6 and higher or equal to 0 then use function liquid
            if ((temperature < 6) && (temperature >= 0))
            {
                warmim.SetActive(false);//deactivate warm image
                freezeim.SetActive(false);//deactivate freeze image
                liquid();
            }
            //If the temperature is  lower than 0 then use function ice
            if (temperature < 0)
            {
                warmim.SetActive(false);//deactivate warm image
                freezeim.SetActive(true);//activate freeze image
                ice();
            }


            //if the form is equal to 0 then change the color and gravity to make it look like liquid
            if (form == 0)

            {
                GameObject.FindWithTag("Blur").GetComponent<Blur>().enabled = true;

                normalgrav = -5f;
                GetComponent<SpriteRenderer>().color = new Color(0F, 0.5F, 0.7F, 1F);
            }

            //if the form is equal to 1 then change the color and gravity to make it look like steam
            if (form == 1)

            {
                GameObject.FindWithTag("Blur").GetComponent<Blur>().enabled = true;
                normalgrav = 2f;

                GetComponent<SpriteRenderer>().color = new Color(1F, 1F, 1F, 1F);
            }
            //if the form is equal to 1 then change the color and gravity to make it look like ice
            if (form == 2)

            {
                GameObject.FindWithTag("Blur").GetComponent<Blur>().enabled=false;
                normalgrav = -9.81f;

                GetComponent<SpriteRenderer>().color = new Color(0F, 1F, 1F, 1F);
            }


        }


        formtype = form;//make another variable of form that is non static, to use on other scripts
        
        //use this to update every object's temperature variable
        liq = GameObject.FindWithTag("Manager").GetComponent<LiquidScript>();
        temperature = liq.temperature;


    }



    public void liquid()
    {
        //change form to 0
        form = 0;
    }

    public void steam()
    {
        //change form to 1
        form = 1;
    }

    public void ice()
    {
        //change form to 2
        form = 2;
    }

    public void warming()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);//Detecting any touches if they are more than one


            switch (touch.phase)
            {

                case TouchPhase.Began:

                    moved2 = Input.GetTouch(0).position.x;// get the position of the finger in the x axis and store it in moved2



                    break;

                case TouchPhase.Moved:

                    moved1 = Input.GetTouch(0).position.x;//get the position of the finger in the x axis and store it in moved1

                    //If moved1 or moved2 are different then increase the temperature by the difference between them divided by 800.
                    if (moved2 > moved1)
                    {
                        difference = moved2 - moved1;
                        temperature = temperature + (difference / 800);

                    }
                    if (moved1 > moved2)
                    {
                        difference = moved1 - moved2;
                        temperature = temperature + (difference / 800);

                    }

                    moved2 = Input.GetTouch(0).position.x;//get the position of the finger in the x axis and store it in moved2

                    break;

                case TouchPhase.Stationary:
                    //Do nothing if the finger doesn't move.
                    break;

                case TouchPhase.Ended:

                    //Do nothing if the finger stops touching.

                    break;


            }
        }
    }



    //void OnCollisionEnter(Collision collision)
    //{
    //if the form of the liquid is ice and any of the LiquidTag objects collide, then make the one parent of the other.(combine them)
        //if (form == 2)
          //  {
          //    if (collision.gameObject.tag == "LiquidTag")
           // {   
          //    collision.transform.parent = gameObject.transform;
           // }
          //  }
          //CODE REMOVED BECAUSE OF BUGS
  //  }

    public void blowing()
    {
        bl = true;
        af = false;
    }

    public void auto()
    {
        bl = false;
        af = true;
    }

}
