using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorld : MonoBehaviour
{
    public GameBoard boardPrefab;
    public Game game;
    public GameBoard outerBoard;
    public GameBoard innerBoard;
    public Interface ui;
    private int resourceRate = 100;
    private bool isOuterPerspective = false;


    void Start()
    {
        CreateWorld();
        SwitchPerspective();
    }

    public void CreateWorld()
    {
        outerBoard = GameObject.Instantiate<GameBoard>(boardPrefab);
        innerBoard = GameObject.Instantiate<GameBoard>(boardPrefab);
        outerBoard.ui = ui;
        innerBoard.ui = ui;
        outerBoard.isOuter = true;
        innerBoard.isOuter = false;
        innerBoard.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        innerBoard.hexRadius *= 0.9f;
        innerBoard.pentRadius *= 0.9f;
    }

    public void OnStartTurn()
    {
        game.currentPlayer.resources += resourceRate;
        ui.UpdatePlayer(game.currentPlayer);
    }

    public void ConstructUnit(GameUnit unit, GameTile tile)
    {
        tile.PlaceUnit(unit);
        ui.unitInfoDisplay.DisplayInfo(unit);
        game.currentPlayer.resources -= unit.cost;
        ui.playerStateDisplay.DisplayPlayerState(game.currentPlayer);
    }

    public List<GameTile> GetNeighbors(GameTile gameTile)
    {
        List<GameTile> res = new List<GameTile>();
        foreach (int n in PlanetStructure.neighbors[gameTile.position])
        {
            res.Add((gameTile.isOuter ? outerBoard : innerBoard).tiles[n]);
        }
        return res;
    }

    public void SwitchPerspective()
    {
        isOuterPerspective = !isOuterPerspective;
        outerBoard.gameObject.SetActive(isOuterPerspective);
        innerBoard.gameObject.SetActive(!isOuterPerspective);
    }
}
