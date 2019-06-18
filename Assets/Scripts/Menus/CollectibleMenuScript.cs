using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleMenuScript : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button goToRecipes;
    [SerializeField] private Button goToTips;

    [SerializeField] private GameObject UICanvasMainMenu;
    [SerializeField] private GameObject UICanvasRecipes;
    [SerializeField] private GameObject UICanvasTips;

    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(BackToMainMenu);
        goToRecipes.onClick.AddListener(GoToRecipes);
        goToTips.onClick.AddListener(GoToLevelTips);
    }

    private void BackToMainMenu()
    {
        gameObject.SetActive(false);
        UICanvasMainMenu.SetActive(true);
    }

    private void GoToLevelTips()
    {
        gameObject.SetActive(false);
        UICanvasTips.SetActive(true);
    }

    private void GoToRecipes()
    {
        gameObject.SetActive(false);
        UICanvasRecipes.SetActive(true);
    }
}
