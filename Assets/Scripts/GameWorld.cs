﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorld : MonoBehaviour
{
    public GameBoard boardPrefab;
    public Game game;
    public GameBoard outerBoard;
    public GameBoard innerBoard;
    public GameUnit smallTowerPrefab;
    public GameUnit penguinPrefab;
    public GameUnit bearPrefab;
    public Interface ui;
    public GameObject effectPrefab;
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
        outerBoard.ui = ui;
        outerBoard.isOuter = true;
        outerBoard.world = this;
        /*
        innerBoard = GameObject.Instantiate<GameBoard>(boardPrefab);
        innerBoard.isOuter = false;
        innerBoard.ui = ui;
        innerBoard.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        innerBoard.hexRadius *= 0.9f;
        innerBoard.pentRadius *= 0.9f;
        */
    }

    public void OnStartTurn()
    {
        game.currentPlayer.resources += resourceRate;
        ui.UpdatePlayer(game.currentPlayer);
    }

    public GameTile GetOppositeTile(GameTile tile)
    {
        return null;
    }

    public void ConstructUnit(GameTile tile, GameUnit unitPrefab)
    {
        GameUnit unit = GameObject.Instantiate<GameUnit>(unitPrefab);
        tile.PlaceUnit(unit);
        unit.owner = game.currentPlayer;
        List<GameTile> neighbors = GetNeighbors(tile);
        foreach (GameTile ntile in neighbors)
        {
            if (ntile.terrainType == tile.terrainType)
            {
                //GameObject.Instantiate(effectPrefab, unit.GetComponent<Tower>().top.transform.position + ntile)
            }
        }
        //ui.unitInfoDisplay.DisplayInfo(unit);
        //game.currentPlayer.resources -= unit.cost;
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

    public GameTile GetTile(int position, bool isOuter)
    {
        return (isOuter ? outerBoard : innerBoard).tiles[position];
    }

    public void SwitchPerspective()
    {
        isOuterPerspective = !isOuterPerspective;
        //outerBoard.gameObject.SetActive(isOuterPerspective);
        //innerBoard.gameObject.SetActive(!isOuterPerspective);
    }

    public List<GameTile> moveLocations(GameTile from, GameUnit unit) {
        List<GameTile> res = new List<GameTile>();


        return res;
    }

    public void Move(GameTile from, GameTile to, GameUnit unit) {
        if (CanReachTo(from, to, unit)) {
            from.currentUnit = null;
            to.currentUnit = unit;
        }
    }

    public bool CanReachTo(GameTile from, GameTile to, GameUnit unit) {
        List<GameTile> path = Path(from, to);
        int movement = unit.movement;
        for (int i = 0; i < path.Count; i++) {
            movement -= path[i].terrainType == TerrainType.RED && unit.movementType != MovementType.FLYING ? 2 : 1;
        }
        return movement >= 0;
    }

    public bool CanReachTo(GameTile from, GameTile to, int movement) {
        List<GameTile> path = Path(from, to);
        return movement-path.Count >= 0;
    }

    public bool HavePath(TerrainType team) {
        GameTile top = GetTile(0, true);
        GameTile bot = GetTile(41, true);

        List<List<GameTile>> paths = new List<List<GameTile>> { new List<GameTile> { top } };
        HashSet<GameTile> visited = new HashSet<GameTile>();

        while (paths.Count > 0) {
            List<GameTile> path = paths[0];
            paths.RemoveAt(0);
            GameTile current = path[path.Count - 1];

            List<GameTile> neighs = GetNeighbors(current);
            foreach (GameTile tile in neighs) {
                if (tile == bot) {
                    return true;
                } else if (tile.terrainType == team && !visited.Contains(tile)) {
                    List<GameTile> newPath = new List<GameTile>(path) { tile };
                    paths.Add(newPath);
                    visited.Add(tile);
                }

            }
        }
        return false;
    }


    public List<GameTile> Path(GameTile from, GameTile to) {
        Dictionary<GameTile, bool> visited = new Dictionary<GameTile, bool>();// { { from, true } };
        // do other stuff
        List<GameTile> l = new List<GameTile> { from };
        Pair<List<GameTile>, int> p = new Pair<List<GameTile>, int>(l, 0);
        List<Pair< List<GameTile>, int> > paths = new List<Pair< List<GameTile>, int >> {p};

        Pair<List<GameTile>, int> best = new Pair<List<GameTile>, int> {
            first = new List<GameTile>()
        };
        best.second = 1000000000;

        while (paths.Count > 0) {
            //Debug.Log("inside pathfind loop with size of queue: "+ paths.Count);
            Pair<List<GameTile>, int> path = paths[0];
            paths.RemoveAt(0);
            GameTile current = path.first[path.first.Count - 1];
            if (visited.ContainsKey(current))
                continue;
            visited.Add(current, true);
            if (current.position == to.position) {
                if (best != null && path.second < best.second) {
                    best = path;
                } else if (best == null) {
                    best = path;
                }
            } else {
                List<GameTile> neighs = GetNeighbors(GetTile(current.position, true));
                for (int i = 0; i < neighs.Count; i++) {
                    if (!visited.ContainsKey(neighs[i])) {
                        Pair<List<GameTile>, int> newPath = new Pair<List<GameTile>, int>(new List<GameTile>(path.first), 0);
                        newPath.first.Add(neighs[i]);
                        newPath.second = path.second++;
                        paths.Add(newPath);
                    }
                }

            }
        }
        return best.first;
    }

}
