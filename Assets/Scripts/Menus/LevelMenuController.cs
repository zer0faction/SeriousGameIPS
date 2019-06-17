using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour
{
    //Buttons
    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;
    [SerializeField] private Button backButton;

    [SerializeField] private GameObject UICanvasMainMenu;

    private GameObject dontDestroy;
    private ArrayList unlockedlevels;
    private ArrayList availableLevels;

    // Start is called before the first frame update
    void Start()
    {
        availableLevels = new ArrayList();
        unlockedlevels = new ArrayList();

        level1Button.enabled = false;
        level2Button.enabled = false;
        level3Button.enabled = false;
        level1Button.gameObject.SetActive(false);
        level2Button.gameObject.SetActive(false);
        level3Button.gameObject.SetActive(false);

        availableLevels.Add(1);
        availableLevels.Add(2);
        availableLevels.Add(3);

        level1Button.onClick.AddListener(delegate { GoToLevel(1); });
        level2Button.onClick.AddListener(delegate { GoToLevel(2); });
        level3Button.onClick.AddListener(delegate { GoToLevel(3); });
        backButton.onClick.AddListener(BackToMainMenu);

        dontDestroy = GameObject.Find("DontDestroy");
        unlockedlevels = dontDestroy.GetComponent<DontDestroy>().GetUnlockedLevels();

        foreach(int unlocked in unlockedlevels)
        {
            if(unlocked == 1)
            {
                Debug.Log("Level 1 unlocked");
                level1Button.enabled = true;
                level1Button.gameObject.SetActive(true);
            }

            if (unlocked == 2)
            {
                Debug.Log("Level 2 unlocked");
                level2Button.enabled = true;
                level2Button.gameObject.SetActive(true);
            }

            if (unlocked == 3)
            {
                Debug.Log("Level 3 unlocked");
                level3Button.enabled = true;
                level3Button.gameObject.SetActive(true);
            }
        }
    }

    private void GoToLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    private void BackToMainMenu()
    {
        gameObject.SetActive(false);
        UICanvasMainMenu.SetActive(true);
    }
}
