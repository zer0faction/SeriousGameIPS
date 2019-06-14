using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpIconController : MonoBehaviour
{
    //UI
    [SerializeField]
    private Text textFieldHelpicon;
    [SerializeField]
    private GameObject help;

    //Tekst string
    [SerializeField]
    private string helpiconText;

    private void Start()
    {
        help.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textFieldHelpicon.text = helpiconText;
            help.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textFieldHelpicon.text = helpiconText;
            help.SetActive(false);
        }
    }
}
