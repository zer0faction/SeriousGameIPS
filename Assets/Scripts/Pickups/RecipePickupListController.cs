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
    private float recipesCollected;
    private ArrayList pickedUpRecipes;
    public RecipePickup[] recipes;

    //Etc
    [SerializeField] string recipeName;
    [SerializeField] string recipeDescription;
    [SerializeField] string tipOfTheDayString;

    //GameObject van gehele level. Wordt uitgezet als level is afgelopen
    private GameObject GameLevelObject;

    //UI dingen
    //In game
    [SerializeField] Text recipeCollectedUiText;

    //Aan eind van level
    [SerializeField] Text recipeNameUiText;
    [SerializeField] Text tipOfTheDay;
    [SerializeField] Text applesCollectedUiText;

    //De 2 gameobjecten die gebruikt worden om de UI aan en uit te zetten
    public GameObject UiRecipeList;
    private GameObject gameplayUi;
    private GameObject levelFinishUi;

    // Start is called before the first frame update
    void Start()
    {
        GameLevelObject = GameObject.FindGameObjectWithTag("GameLevelObject");
        applesCollected = 0;
        pickedUpRecipes = new ArrayList();
        recipeCollectedUiText.text = recipesCollected + "/" + amountOfRecipesInLevel + " recepten gevonden";
        gameplayUi = UiRecipeList.gameObject.transform.GetChild(0).gameObject;
        levelFinishUi = UiRecipeList.gameObject.transform.GetChild(1).gameObject;

        levelFinishUi.SetActive(false);
        gameplayUi.SetActive(true);
    }

    public void recipeIsPickedUp(GameObject recipe)
    {
        recipesCollected = recipesCollected + 1;
        recipeCollectedUiText.text = recipesCollected + "/" + amountOfRecipesInLevel + " recepten gevonden";
        pickedUpRecipes.Add(recipe);
        recipe.SetActive(false);
    }

    public void AppleIsPickedUp(GameObject apple)
    {
        Debug.Log("Ervoor: "+applesCollected);
        applesCollected = applesCollected + 1;
        Debug.Log("Erna: " + applesCollected);
        apple.SetActive(false);
    }

    public bool LevelEnded()
    {
        if (amountOfRecipesInLevel == recipesCollected)
        {
            recipeNameUiText.text = "Nieuw gerecht ontgrendeld: " + recipeName;
            tipOfTheDay.text = tipOfTheDayString;
            applesCollectedUiText.text = applesCollected + "/" + amountOfApplesInLevel + " appels gevonden";
            gameplayUi.SetActive(false);
            GameLevelObject.SetActive(false);
            levelFinishUi.SetActive(true);
            return true;
        }
        else
        {
            return false;
        }
    }
}
