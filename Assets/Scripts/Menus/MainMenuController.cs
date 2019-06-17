using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    //Buttons
    [SerializeField] private Button GoToLevelSelectButton;
    [SerializeField] private Button GoToRecipesButton;
    [SerializeField] private Button ExitGameButton;

    //Canvassen
    [SerializeField] private GameObject UICanvasLevelSelect;
    [SerializeField] private GameObject UICanvasRecipes;

    // Start is called before the first frame update
    void Start()
    {
        GoToLevelSelectButton.onClick.AddListener(GoToLevelSelect);
        GoToRecipesButton.onClick.AddListener(GoToRecipes);
        ExitGameButton.onClick.AddListener(ExitGame);
    }

    public void GoToLevelSelect()
    {
        Debug.Log("LevelSelect");
        gameObject.SetActive(false);
        UICanvasLevelSelect.SetActive(true);
    }

    private void GoToRecipes()
    {
        Debug.Log("Recipes");
        gameObject.SetActive(false);
        UICanvasRecipes.SetActive(true);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
