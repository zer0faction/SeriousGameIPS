using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonControllerBossfight : MonoBehaviour
{
    [SerializeField] private Button toMenuButton;
    // Start is called before the first frame update
    void Start()
    {
        toMenuButton.onClick.AddListener(toMenu);
    }

    // Update is called once per frame
    private void toMenu()
    {
        SceneManager.LoadScene(0);
    }
}
