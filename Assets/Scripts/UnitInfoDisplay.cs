using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfoDisplay : MonoBehaviour {
    public Text infoText;

    void Start()
    {
        DisplayInfo(null);
    }

    public void DisplayInfo(GameUnit gameUnit)
    {
        if (gameUnit == null)
        {
            infoText.text = "";
        } else
        {
            infoText.text = gameUnit.unitName;
        }
    }

}
