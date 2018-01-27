using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructUnitPanel : MonoBehaviour {
    public ScrollRect scrollRect;
    public UnitConstructButton unitButtonPrefab;
    public Interface ui;

    public void SetUnitButtons(GameUnit[] units)
    {
        foreach (Transform child in scrollRect.content.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (GameUnit unit in units)
        {
            UnitConstructButton button = GameObject.Instantiate<UnitConstructButton>(unitButtonPrefab);
            button.transform.SetParent(scrollRect.content);
            button.SetContent(unit, this);
        }
    } 

    public void OnConstructUnitClick(GameUnit unit)
    {
        ui.produceUnit = unit;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
