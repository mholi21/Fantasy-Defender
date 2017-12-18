using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

    private Button[] buttonArray;
    private Text costText;

    void Start()
    {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        costText = GetComponentInChildren<Text>();

        if (!costText)
        {
            Debug.LogWarning(name + " no cost set!");
        }

        costText.text = defenderPrefab.GetComponent<Defender>().buildCost.ToString();


        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.gray;
        }

    }

	void OnMouseDown()
    {
        foreach(Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }
}
