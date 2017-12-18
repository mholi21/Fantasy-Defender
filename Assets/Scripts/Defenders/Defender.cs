using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    public int buildCost = 10;

    private CurrencyDisplay currencyDisplay;

    void Start()
    {
        currencyDisplay = GameObject.FindObjectOfType<CurrencyDisplay>();
    }

    public void AddCurrency(int amount)
    {
        currencyDisplay.AddCurrency(amount);
    }
}
