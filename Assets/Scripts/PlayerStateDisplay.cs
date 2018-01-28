using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateDisplay : MonoBehaviour {
    public Text playerText;
    public Text resourceText;

    public void DisplayPlayerState(Player player)
    {
        playerText.text = (player.playerNum == 0 ? "Red" : "Blue") + " player's turn";
        //resourceText.text = "Resources: " + player.resources;
    }

    public void Hide()
    {
        playerText.enabled = false;
    }
}
