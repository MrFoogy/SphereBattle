using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitConstructButton : MonoBehaviour {
    public GameUnit unit;
    public Text nameDisplay;
    public Text costDisplay;
    private ConstructUnitPanel parentPanel;

    public void SetContent(GameUnit unit, ConstructUnitPanel parentPanel)
    {
        this.unit = unit;
        this.parentPanel = parentPanel;
        nameDisplay.text = unit.unitName;
        costDisplay.text = "" + unit.cost;
    }

    public void OnClicked()
    {
        parentPanel.OnConstructUnitClick(unit);
    }
}
