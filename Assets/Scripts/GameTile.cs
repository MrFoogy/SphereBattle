using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TerrainType
{
    NEUTRAL, BLUE, RED
}

public class GameTile : MonoBehaviour {
    public GameUnit currentUnit;
    public Text text;
    public int position;
    public TerrainType terrainType = TerrainType.NEUTRAL;
    public bool isOuter;

    private Dictionary<TerrainType, string> terrainNames = new Dictionary<TerrainType, string> {
        { TerrainType.NEUTRAL, "Neutral" },
        { TerrainType.BLUE, "Blue" },
        { TerrainType.RED, "Red" }
    };

    private Dictionary<TerrainType, Color> terrainColors = new Dictionary<TerrainType, Color> {
        { TerrainType.NEUTRAL, Color.yellow },
        { TerrainType.BLUE, Color.blue },
        { TerrainType.RED, Color.red }
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
        unit.transform.SetParent(transform);
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
