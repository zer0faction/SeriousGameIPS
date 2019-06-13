using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStaminaScript : MonoBehaviour
{
    [SerializeField]
    private Slider staminaSlider;

    [SerializeField]
    private Text textFieldStamina;

    // Start is called before the first frame update
    void Start()
    {
        staminaSlider.maxValue = 100;
        staminaSlider.value = staminaSlider.maxValue;
        textFieldStamina.text = staminaSlider.maxValue+"";
    }

    public void RemoveStamina()
    {
        staminaSlider.value = staminaSlider.value - 1;
        textFieldStamina.text = staminaSlider.value + "";
    }

    public void AddStamina()
    {
        staminaSlider.value = staminaSlider.value + 1;
        textFieldStamina.text = staminaSlider.value + "";
    }

    public void HigherMaxStamina()
    {
        staminaSlider.maxValue = staminaSlider.maxValue + 10;
    }

    public bool AllowedToSprint()
    {
        if(staminaSlider.value > 0)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
