﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Image healthbar;
    float maxHealth = 100f;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = health / maxHealth;
    }
}