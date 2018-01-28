using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateDisplay : MonoBehaviour {
    public Text playerText;
    public Text resourceText;

    public void DisplayPlayerState(Player player)
    {
        playerText.text = (player.playerNum == 0 ? "Blue" : "Red") + " player's turn";
        //resourceText.text = "Resources: " + player.resources;
    }
}
