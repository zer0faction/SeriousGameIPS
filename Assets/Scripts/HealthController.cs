using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    [SerializeField] float health;
    private GameObject _script;
    public void RemoveHealth()
    {
        health -= 1;
        if (health <= 0)
        {
            print("You die");
            Destroy(gameObject);
        }
    }
}
