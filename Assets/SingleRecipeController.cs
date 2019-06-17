using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleRecipeController : MonoBehaviour
{
    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;
    [SerializeField] private Button backButton;

    [SerializeField] private GameObject UICanvasRecipeCollectibles;

    [SerializeField] private Sprite breakFastSprite;
    [SerializeField] private Sprite lunchSprite;
    [SerializeField] private Sprite dinnerSprite;

    [SerializeField] private Image recipeImage;
    [SerializeField] private Text recipeText;
    [SerializeField] private Text recipeTextName;

    private GameObject dontDestroy;
    private string recipeString;
    private int index;

    private List<Recipe> UnlockedRecipes;

    // Start is called before the first frame update
    void Start()
    {
        dontDestroy = GameObject.Find("DontDestroy");

        UnlockedRecipes = dontDestroy.GetComponent<DontDestroy>().GetUnlockedRecipes();

        index = 0;
        backButton.onClick.AddListener(BackToRecipeMenu);
        buttonLeft.onClick.AddListener(goToTheLeft);
        buttonRight.onClick.AddListener(goToTheRight);

        changeRecipe(UnlockedRecipes[index]);
    }

    private void goToTheLeft()
    {
        if (index == 0)
        {
            Debug.Log(index);
            index = UnlockedRecipes.Count - 1;
            changeRecipe(UnlockedRecipes[index]);
        }
        else
        {
            Debug.Log(index);
            index = index - 1;
            changeRecipe(UnlockedRecipes[index]);
        }
    }

    private void goToTheRight()
    {
        if (index == UnlockedRecipes.Count - 1)
        {
            Debug.Log(index);
            index = 0;
            changeRecipe(UnlockedRecipes[index]);
        }
        else
        {
            Debug.Log(index);
            index = index + 1;
            changeRecipe(UnlockedRecipes[index]);
        }
    }

    private void changeRecipe(Recipe recipe)
    {
        recipeTextName.text = recipe.recipeName;
        recipeText.text = recipe.recipeDescription;
        recipeImage.sprite = recipe.recipeImage;
    }

    private void BackToRecipeMenu()
    {
        gameObject.SetActive(false);
        UICanvasRecipeCollectibles.SetActive(true);
    }
}
