using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipListController : MonoBehaviour
{
    [SerializeField] private Text tipText;
    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;
    [SerializeField] private Button backButton;

    [SerializeField] private GameObject UICanvasRecipeCollectibles;

    private GameObject dontDestroy;
    private List<string> tips;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        dontDestroy = GameObject.Find("DontDestroy");

        index = 0;
        tips = dontDestroy.GetComponent<DontDestroy>().GetTips();
        buttonLeft.onClick.AddListener(goToTheLeft);
        buttonRight.onClick.AddListener(goToTheRight);
        backButton.onClick.AddListener(BackToRecipeMenu);

        if(tips.Count == 0)
        {
            tipText.text = "Speel eerst de levels om tips te ontgrendelen!";
        } else
        {
            changeTipText(tips[index]);
        }
    }

    private void changeTipText(string text)
    {
        tipText.text = text;
    }

    private void goToTheLeft()
    {
        if (tips.Count == 0)
        {
            tipText.text = "Speel eerst de levels om tips te ontgrendelen!";
        }
        else
        {
            if (index == 0)
            {
                Debug.Log(index);
                index = tips.Count - 1;
                changeTipText(tips[index]);
            }
            else
            {
                Debug.Log(index);
                index = index - 1;
                changeTipText(tips[index]);
            }
        }
    }

    private void goToTheRight()
    {
        if (tips.Count == 0)
        {
            tipText.text = "Speel eerst de levels om tips te ontgrendelen!";
        }
        else
        {
            if (index == tips.Count - 1)
            {
                Debug.Log(index);
                index = 0;
                changeTipText(tips[index]);
            }
            else
            {
                Debug.Log(index);
                index = index + 1;
                changeTipText(tips[index]);
            }
        }
    }

    private void BackToRecipeMenu()
    {
        gameObject.SetActive(false);
        UICanvasRecipeCollectibles.SetActive(true);
    }
}
