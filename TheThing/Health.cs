using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Health : MonoBehaviour
{

    public Text healthText;
    public float health;

    void Start()
    {

        UpdateHealth();
    }

    void UpdateHealth()
    {
        healthText.text = "Health:" + health;
    }

    public void RemoveHealth(float newhealthValue)
    {
        health -= newhealthValue;
        UpdateHealth();
    }

    public void AddHealth(float newhealthAdd)
    {
        health = 100;
        UpdateHealth();
    }

}
