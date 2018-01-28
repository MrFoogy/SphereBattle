using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorld : MonoBehaviour
{
    public GameBoard boardPrefab;
    public Game game;
    public GameBoard outerBoard;
    public GameBoard innerBoard;
    public GameUnit bigTowerPrefab;
    public GameUnit smallTowerPrefab;
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
        outerBoard.ui = ui;
        outerBoard.isOuter = true;
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

    public void ConstructUnit(GameTile tile)
    {
        GameUnit unit = GameObject.Instantiate<GameUnit>(smallTowerPrefab);
        tile.PlaceUnit(unit);
        unit.owner = game.currentPlayer;
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

    private GameTile GetTile(int position, bool isOuter)
    {
        return (isOuter ? outerBoard : innerBoard).tiles[position];
    }

    public void SwitchPerspective()
    {
        isOuterPerspective = !isOuterPerspective;
        outerBoard.gameObject.SetActive(isOuterPerspective);
        innerBoard.gameObject.SetActive(!isOuterPerspective);
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
        List<int> path = Path(from, to);
        int movement = unit.movement;
        for (int i = 0; i < path.Count; i++) {
            movement -= GetTile(path[i], true).terrainType == TerrainType.MOUNTAIN && unit.movementType != MovementType.FLYING ? 2 : 1;
        }
        return movement >= 0;
    }

    public bool CanReachTo(GameTile from, GameTile to, int movement) {
        List<int> path = Path(from, to);
        return movement-path.Count >= 0;
    }

    public List<int> Path(GameTile from, GameTile to) {
        Dictionary<int, bool> visited = new Dictionary<int, bool> { { from.position, true } };
        // do other stuff
        List<int> l = new List<int> { from.position };
        Pair<List<int>, int> p = new Pair<List<int>, int>(l, 0);
        List<Pair< List<int>, int> > paths = new List<Pair< List<int>, int >> {p};

        Pair<List<int>, int> best = new Pair<List<int>, int>();

        while(paths.Count > 0) {
            Pair<List<int>, int> path = paths[0];
            paths.RemoveAt(0);
            int current = path.first[path.first.Count - 1];
            visited.Add(current, true);
            if (current == to.position) {
                if (best != null && path.second < best.second) {
                    best = path;
                }
            } else {
                List<GameTile> neighs = GetNeighbors(GetTile(current, true));
                for (int i = 0; i < neighs.Count; i++) {
                    if (!visited.ContainsKey(neighs[i].position)) {
                        Pair<List<int>, int> newPath = new Pair<List<int>, int>(new List<int>(path.first) { neighs[i].position }, path.second++);
                        paths.Add(newPath);
                    }
                }

            }
        }
        return best.first;
    }

}
