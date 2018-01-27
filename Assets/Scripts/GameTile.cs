using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TerrainType
{
    PLAINS, FOREST, MOUNTAIN
}

public class GameTile : MonoBehaviour {
    public GameUnit currentUnit;
    public Text text;
    public int position;
    public TerrainType terrainType = TerrainType.PLAINS;

    private Dictionary<TerrainType, string> terrainNames = new Dictionary<TerrainType, string> {
        { TerrainType.PLAINS, "Plains" },
        { TerrainType.FOREST, "Forest" },
        { TerrainType.MOUNTAIN, "Mountain" }
    };

    private Dictionary<TerrainType, Color> terrainColors = new Dictionary<TerrainType, Color> {
        { TerrainType.PLAINS, Color.yellow },
        { TerrainType.FOREST, Color.green },
        { TerrainType.MOUNTAIN, Color.gray }
    };

    public void InitializeVisuals()
    {
        GetComponentInChildren<Renderer>().material.color = terrainColors[terrainType];
        text.text = "" + position;
    }

    public void OnHover()
    {
        GetComponentInChildren<Renderer>().material.color = Color.red;
    }

    public void OnStopHover()
    {
        GetComponentInChildren<Renderer>().material.color = terrainColors[terrainType]; 
    }

    public void PlaceUnit(GameUnit unit)
    {
        unit.transform.position = transform.position;
        unit.transform.rotation = transform.rotation;
        currentUnit = unit;
    }

    public void RemoveUnit()
    {
        Destroy(currentUnit.gameObject);
        currentUnit = null;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string GetInfoText()
    {
        return terrainNames[terrainType];
    }
}
