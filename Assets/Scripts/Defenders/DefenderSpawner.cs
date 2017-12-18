using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    private Camera myCamera;
    private GameObject defenderParent;
    private CurrencyDisplay currencyDisplay;

    void Start () {
        myCamera = Camera.main;
        currencyDisplay = GameObject.FindObjectOfType<CurrencyDisplay>();

        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }

    void OnMouseDown()
    {
        if (Button.selectedDefender)
        { 
            Vector2 rawPos = CalculateWorldPointOfMouseClick();
            Vector2 roundedPos = SnapToGrid(rawPos);
            int defenderCost = Button.selectedDefender.GetComponent<Defender>().buildCost;

            if (currencyDisplay.UseCurrency(defenderCost) == CurrencyDisplay.Status.SUCCESS)
            { 
                GameObject newDef = Instantiate(Button.selectedDefender, roundedPos,Quaternion.identity) as GameObject;
                newDef.transform.parent = defenderParent.transform;
            }
            else
            {
                Debug.Log("not enough stars");
            }
        }
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPos;
    }
}
