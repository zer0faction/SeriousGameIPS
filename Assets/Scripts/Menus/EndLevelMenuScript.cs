using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevelMenuScript : MonoBehaviour
{
    [SerializeField] private Button toLevelSelectButton;

    // Start is called before the first frame update
    void Start()
    {
        toLevelSelectButton.onClick.AddListener(GoToLevelSelect);
    }

    private void GoToLevelSelect()
    {
        Debug.Log("haha");
        SceneManager.LoadScene(0);
    }  
}
