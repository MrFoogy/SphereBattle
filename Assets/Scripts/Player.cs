using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    public int resources = 0;
    public int playerNum;
    public PlayerClass playerClass;

    public Player(int playerNum, PlayerClass playerClass)
    {
        this.playerNum = playerNum;
        this.playerClass = playerClass;
    }
}
