using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileInfoDisplay : MonoBehaviour {
    public Text infoText;

    void Start()
    {
        DisplayInfo(null);
    }

    public void DisplayInfo(GameTile gameTile)
    {
        if (gameTile == null)
        {
            infoText.text = "";
        } else
        {
            infoText.text = gameTile.GetInfoText();
        }
    }
}
