using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Recipe
{
    public string recipeName;
    public string recipeDescription;
    public Sprite recipeImage;
}

public class DontDestroy : MonoBehaviour
{
    public List<int> UnLockedLevels;
    private List<Recipe> UnlockedRecipes;
    private List<string> tips;

    //UI activeren
    [SerializeField] private GameObject UICanvasLevelSelect;
    [SerializeField] private GameObject MainMenu;

    private void Awake()
    {
        UnLockedLevels = new List<int>();
        UnlockedRecipes = new List<Recipe>();
        tips = new List<string>();

        UnLockedLevels.Add(1);
		//UnLockedLevels.Add(2);
		//UnLockedLevels.Add(3);

		DontDestroyOnLoad(this.gameObject);
    }

    public List<int> GetUnlockedLevels()
    {
        return UnLockedLevels;
    }

    public List<Recipe>GetUnlockedRecipes()
    {
        return UnlockedRecipes;
    }

    public List<string> GetTips()
    {
        return tips;
    }

    public void UnLocklevel(int level)
    {
        UnLockedLevels.Add(level);
    }

    public void AddRecipe(string recipeName, string recipeDescription, Sprite image)
    {
        Recipe r = new Recipe();
        r.recipeName = recipeName;
        r.recipeDescription = recipeDescription;
        r.recipeImage = image;

        UnlockedRecipes.Add(r);
    }

    public void AddTip(string tip)
    {
        tips.Add(tip);
    }

    public void GoToLevels()
    {
        MainMenu.SetActive(false);
        UICanvasLevelSelect.SetActive(true);
    }
}
