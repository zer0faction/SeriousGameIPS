using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    private float health;

    //Ui fields en afbeeldingen
    //Volle Hartjes
    [SerializeField] Image fullHealthHeart1;
    [SerializeField] Image fullHealthHeart2;
    [SerializeField] Image fullHealthHeart3;

    //Niet volle hartjes
    [SerializeField] Image nonFullHealthHeart1;
    [SerializeField] Image nonFullHealthHeart2;
    [SerializeField] Image nonFullHealthHeart3;

    private void Start()
    {
        health = 3;
        fullHealthHeart1.enabled = true;
        fullHealthHeart2.enabled = true;
        fullHealthHeart3.enabled = true;

        nonFullHealthHeart1.enabled = false;
        nonFullHealthHeart2.enabled = false;
        nonFullHealthHeart3.enabled = false;
    }

    public void RemoveHealth()
    {
        if(health == 3)
        {
            fullHealthHeart3.enabled = false;
            nonFullHealthHeart3.enabled = true;
            health = health - 1;
        }
        else if(health == 2)
        {
            fullHealthHeart2.enabled = false;
            nonFullHealthHeart2.enabled = true;
            health = health - 1;
        }
        else if(health == 1)
        {
            fullHealthHeart1.enabled = false;
            nonFullHealthHeart1.enabled = true;
            health = health - 1;
            //Je sterft
            gameObject.GetComponent<PlayerController>().Die();
        }
    }

    public void RemoveAllHealth()
    {
        health = 0;
        fullHealthHeart1.enabled = false;
        fullHealthHeart2.enabled = false;
        fullHealthHeart3.enabled = false;

        nonFullHealthHeart1.enabled = true;
        nonFullHealthHeart2.enabled = true;
        nonFullHealthHeart3.enabled = true;
    }

    public void AddHealth()
    {
        if (health == 3)
        {
            //Je bent al full health, doe niks     
        }
        else if (health == 2)
        {
            health = 3;
            fullHealthHeart3.enabled = true;
            nonFullHealthHeart3.enabled = false;
        }
        else if (health == 1)
        {
            health = 2;
            fullHealthHeart2.enabled = true;
            nonFullHealthHeart2.enabled = false;
        }
    }

    public void AddAllHealth()
    {
        health = 3;
        fullHealthHeart1.enabled = true;
        fullHealthHeart2.enabled = true;
        fullHealthHeart3.enabled = true;

        nonFullHealthHeart1.enabled = false;
        nonFullHealthHeart2.enabled = false;
        nonFullHealthHeart3.enabled = false;
    }
}
