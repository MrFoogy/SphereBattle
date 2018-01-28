using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Pair<T, U>
{
    public Pair() {

    }

    public Pair(T first, U second) {
        this.first = first;
        this.second = second;
    }
    public T first;
    public U second;
}


public class GameBoard : MonoBehaviour {
    public float hexRadius;
    public float pentRadius;
    public float angle = 30f;
    public GameTile hexagonPrefab;
    public GameTile pentagonPrefab;
    public Interface ui;
    public Player owner;
    public bool isOuter;
    System.Random random = new System.Random();

    public List<GameTile> tiles = new List<GameTile>();
         
	// Use this for initialization
	void Start () {
        GenerateSphere();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void GenerateSphere()
    {
        int index = 0;
        tiles.Add(CreateTile(false, 36f, 0f, 90f, index));


        for (int i = 0; i < 5; i++)
        {
            index++;
            tiles.Add(CreateTile(true, 30f, 72f * i, 58f, index));
        }
        for (int i = 0; i < 5; i++)
        {
            index++;
            tiles.Add(CreateTile(false, 0f, 72f * i, 27f, index));
        }
        for (int i = 0; i < 5; i++)
        {
            index++;
            tiles.Add(CreateTile(true, 0f, 36f + 72f * i, 31.5f, index));
        }

        for (int i = 0; i < 10; i++)
        {
            index++;
            tiles.Add(CreateTile(true, 0f, 18f + 36f * i, 0f, index));
        }

        for (int i = 0; i < 5; i++)
        {
            index++;
            tiles.Add(CreateTile(false, 180f, 72f * i, -27f, index));
        }

        for (int i = 0; i < 5; i++)
        {
            index++;
            tiles.Add(CreateTile(true, 0f, 36f + 72f * i, -31.5f, index));
        }

        for (int i = 0; i < 5; i++)
        {
            index++;
            tiles.Add(CreateTile(true, 30f, 72f * i, -58f, index));
        }

        tiles.Add(CreateTile(false, 180f + 36f, 0f, -90f, ++index));

    }

    private GameTile CreateTile(bool isHexagon, float ownRot, float sideRot, float upRot, int position = 0)
    {
        GameTile tile = GameObject.Instantiate<GameTile>(isHexagon ? hexagonPrefab : pentagonPrefab, transform);
        tile.transform.Rotate(Vector3.right, upRot - 90f, Space.World);
        tile.transform.Rotate(Vector3.up, sideRot, Space.World);
        tile.transform.position += tile.transform.up * (isHexagon ? hexRadius : pentRadius);
        tile.position = position;
        tile.transform.Rotate(0f, ownRot, 0f, Space.Self);
        tile.isOuter = isOuter;
        // Randomize terrain type
        Array values = Enum.GetValues(typeof(TerrainType));
        //tile.terrainType = (TerrainType)values.GetValue(random.Next(values.Length));
        tile.terrainType = TerrainType.MOUNTAIN; 

        tile.InitializeVisuals();
        return tile;
    }
}
