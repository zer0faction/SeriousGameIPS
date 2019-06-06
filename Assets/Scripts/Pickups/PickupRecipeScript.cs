using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRecipeScript : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with " + other.gameObject.name);
        if (other.gameObject.CompareTag("RecipePickup"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("meloen");

        }
    }
}
