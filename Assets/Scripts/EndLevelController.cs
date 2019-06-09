using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelController : MonoBehaviour
{
    private GameObject recipeListController;

    private void Start()
    {
        recipeListController = GameObject.FindGameObjectWithTag("RecipePickupList");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (recipeListController.GetComponent<RecipePickupListController>().LevelEnded())
            {
                //if true: gebeurd in recipepickuplistcontroller
            } else
            {

            }    
        }
    }
}
