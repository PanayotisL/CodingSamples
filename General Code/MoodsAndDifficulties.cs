using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoodsAndDifficulties : MonoBehaviour
{


    public float hunger, physique, entertainment, cleanliness, confidence;
    public float cookingdif, gymdif, workdif, chatdif, bathdif, cinemadif;


    public Image hungerim, physiqueim, entertainmentim, cleanlinessim, confidenceim;

    public GameObject moodcanvas;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
        gymdif = PlayerPrefs.GetFloat("gymdif");
        workdif = PlayerPrefs.GetFloat("workdif");
        chatdif = PlayerPrefs.GetFloat("chatdif");
        bathdif = PlayerPrefs.GetFloat("bathdif");
        cinemadif = PlayerPrefs.GetFloat("cinemadif");
        cookingdif = PlayerPrefs.GetFloat("cookingdif");
        physique = PlayerPrefs.GetFloat("physique");
        confidence = PlayerPrefs.GetFloat("confidence");
        cleanliness = PlayerPrefs.GetFloat("cleanliness");
        hunger = PlayerPrefs.GetFloat("hunger");
        entertainment = PlayerPrefs.GetFloat("entertainment");

        StartCoroutine(decrease());
	}
	
	// Update is called once per frame
	void Update () {

        if(hunger<=0)
        {
            hunger = 0;
        }
        if(physique<=0)
        {
            physique = 0;
        }
        if(entertainment<=0)
        {
            entertainment = 0;

        }
        if(cleanliness<=0)
        {
            cleanliness = 0;
        }
        if(confidence<=0)
        {
            confidence = 0;
        }


        if (hunger >= 100)
        {
            hunger = 100;
        }
        if (physique >= 100)
        {
            physique = 100;
        }
        if (entertainment >= 100)
        {
            entertainment = 100;

        }
        if (cleanliness >= 100)
        {
            cleanliness = 100;
        }
        if (confidence >= 100)
        {
            confidence = 100;
        }



        hungerim.fillAmount = hunger / 100;
        physiqueim.fillAmount = physique / 100;
        entertainmentim.fillAmount = entertainment / 100;
        cleanlinessim.fillAmount = cleanliness / 100;
        confidenceim.fillAmount = cleanliness / 100;


        cookingdif = Mathf.Abs((100-physique) / 20);
        gymdif = Mathf.Abs(((((100 - hunger) * 0.4f) + ((100 - confidence) * 0.35f) + ((100 - entertainment) * 0.25f) / 3)/5));
        workdif = Mathf.Abs(((((100 - hunger) * 0.4f) + ((100 - entertainment) * 0.3f) + ((100 - confidence) * 0.2f) + ((100 - cleanliness) * 0.1f) / 4)/5));
        bathdif = Mathf.Abs((100 - hunger) / 20);
        cinemadif = Mathf.Abs((100 - hunger) / 20);
        chatdif = Mathf.Abs(((((100 - cleanliness) * 0.4f) + ((100 - physique) * 0.3f) + ((100 - entertainment) * 0.2f) + ((100 - hunger) * 0.1f) / 4) / 5));


        if (Input.GetKeyDown(KeyCode.M))
        {
            moodcanvas.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.M))
        {     
            moodcanvas.SetActive(false);
        }

    }

    IEnumerator decrease()
    {
        yield return new WaitForSeconds(1);
        hunger -= 0.05f;
        physique -= 0.05f;
        cleanliness -= 0.05f;
        entertainment -= 0.05f;
        confidence -= 0.05f;
        StartCoroutine(decrease());
    }
}
