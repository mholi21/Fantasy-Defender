using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(Text))]
public class CurrencyDisplay : MonoBehaviour {

    private Text textDisplay;
    private int currency = 75;

    public enum Status { SUCCESS, FAILURE};

    void Start()
    {
        textDisplay = GetComponent<Text>();
        string sceneName = SceneManager.GetActiveScene().name;
        string levelID = sceneName.Substring(sceneName.Length - 2);
        int levelMultiplier = Int32.Parse(levelID);
        currency = currency * levelMultiplier;
        textDisplay.text = currency.ToString();
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
        textDisplay.text = currency.ToString();
    }

    public Status UseCurrency(int amount)
    {
        if(currency >= amount)
        {
            currency -= amount;
            textDisplay.text = currency.ToString();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }
}
