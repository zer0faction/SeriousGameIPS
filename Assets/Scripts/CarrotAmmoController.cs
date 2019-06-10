using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarrotAmmoController : MonoBehaviour
{

    [SerializeField] private Text carrotAmountUi;
    public float carrotAmount;

    // Start is called before the first frame update
    private void Start()
    {
        carrotAmount = 0;
        carrotAmountUi.text = carrotAmount + " X";
    }

    public void AddCarrot()
    {
        if(carrotAmount <= 94)
        {
            carrotAmount = carrotAmount + 5;
            carrotAmountUi.text = carrotAmount + " X";
        } else if(carrotAmount <= 99)
        {
            carrotAmount = 99;
            carrotAmountUi.text = carrotAmount + " X";
        }
    }

    public void RemoveCarrot()
    {
        carrotAmount = carrotAmount - 1;
        carrotAmountUi.text = carrotAmount + " X";
    }
}
