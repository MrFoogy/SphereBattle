using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
    public Interface ui;
    public PlayerClass[] playerClasses;
    private Player[] players = new Player[2];
    private int activePlayerNum = 0;
    public Player currentPlayer; 
    public GameWorld world;

	// Use this for initialization
	void Start () {
        players[0] = new Player(0, playerClasses[0]);
        players[1] = new Player(1, playerClasses[1]);
        currentPlayer = players[activePlayerNum];
        ui.UpdatePlayer(currentPlayer);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}

    public void ChangeTurn()
    {
        activePlayerNum = (activePlayerNum + 1) % players.Length;
        currentPlayer = players[activePlayerNum];
        world.OnStartTurn();
    }

}
