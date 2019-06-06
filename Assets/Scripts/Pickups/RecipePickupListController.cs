using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class RecipePickup
{
    public GameObject pickup;
}

public class RecipePickupListController : MonoBehaviour
{
    //Punten bijhouden
    [SerializeField] float amountOfRecipesInLevel;
    [SerializeField] float amountOfApplesInLevel;
    private float applesCollected;
    private ArrayList pickedUpRecipes;
    public RecipePickup[] recipes;

    //UI dingen
    [SerializeField] Text applesCollectedUiText;

    // Start is called before the first frame update
    void Start()
    {
        pickedUpRecipes = new ArrayList();
        applesCollectedUiText.text = "Je hebt tot nu toe " + applesCollected + " appels gevonden!";
    }

    public void recipeIsPickedUp(GameObject recipe)
    {
        Debug.Log(recipe.name);
        pickedUpRecipes.Add(recipe);
        recipe.SetActive(false);
    }

    public void AppleIsPickedUp(float amount)
    {
        applesCollected = applesCollected + amount;
        applesCollectedUiText.text = "Je hebt tot nu toe "+applesCollected+" appels gevonden!";
    }
}
