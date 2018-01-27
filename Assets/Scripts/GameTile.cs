using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTile : MonoBehaviour {
    public GameUnit currentUnit;
    public Text text;
    public int position;

    public void OnClicked()
    {
        GetComponentInChildren<Renderer>().material.color = Color.red;
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
}
