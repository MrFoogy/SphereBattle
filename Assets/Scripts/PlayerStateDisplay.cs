using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateDisplay : MonoBehaviour {
    public Text playerText;
    public Text resourceText;

    public void DisplayPlayerState(Player player)
    {
        playerText.text = "Player " + (player.playerNum + 1) + ":s turn";
        resourceText.text = "Resources: " + player.resources;
    }
}
