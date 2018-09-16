using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Healthbar : MonoBehaviour
{
    public Slider healthBar;

   // [HideInInspector]
   // public float amountOfLose = 10; //amount of decreasing health 
    [HideInInspector]
    public float currentHealth;

    public void Start()
    {
        currentHealth = healthBar.value;
    }

    public bool Damage(float value)
    {
        bool isDead = false;
        healthBar.value -= value;
        currentHealth = healthBar.value;
        if (healthBar.value <= 0)
        {
            isDead = true;
        }
        return isDead;
    }

    public void IncreaseHealth(float value)
    {
        healthBar.value += value;
        currentHealth = healthBar.value;
    }
}
