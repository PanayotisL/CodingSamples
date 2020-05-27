using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody rigid;
    public float speed = 5;
    public GameObject GameOver;
  
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rigid.velocity = new Vector2(0, speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Missile"))
        {

            if (GameObject.Find("healthText").GetComponent<Health>().health > 0)
            {
                GameObject.Find("healthText").GetComponent<Health>().RemoveHealth(1);
                Destroy(other.gameObject);
                print("Health Was Removed");
            }

            if (GameObject.Find("healthText").GetComponent<Health>().health == 0)
            {
               
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                Time.timeScale = 0;
                GameOver.SetActive(true);
                

            }


        }

        if (other.gameObject.name.Contains("TopBarrier"))
        {

            if (GameObject.Find("healthText").GetComponent<Health>().health > 0)
            {
                GameObject.Find("healthText").GetComponent<Health>().RemoveHealth(1);
                print("Health Was Removed");
            }

            if (GameObject.Find("healthText").GetComponent<Health>().health == 0)
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                Time.timeScale = 0;
                GameOver.SetActive(true);

            }
        }


        if (other.gameObject.name.Contains("BottomBarrier"))
        {

            if (GameObject.Find("healthText").GetComponent<Health>().health > 0)
            {
                GameObject.Find("healthText").GetComponent<Health>().RemoveHealth(1);
                print("Health Was Removed");
            }

            if (GameObject.Find("healthText").GetComponent<Health>().health == 0)
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                Time.timeScale = 0;
                GameOver.SetActive(true);

            }
        }

        if (other.gameObject.name.Contains("LimitBarrier"))
        {

            if (GameObject.Find("healthText").GetComponent<Health>().health > 0)
            {

                Destroy(this.gameObject);
                Destroy(other.gameObject);
                Time.timeScale = 0;
                GameOver.SetActive(true);

            }
        }

    }

}
