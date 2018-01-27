using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    private GameTile currentHoveredTile;
    public GameUnit produceUnit;
    public TileInfoDisplay tileInfoDisplay;
    public UnitInfoDisplay unitInfoDisplay;
    public GameBoard board;

    void Update()
    {

        UpdateHoveredTile();

        if (Input.GetMouseButtonDown(0) && currentHoveredTile != null)
        {
            if (currentHoveredTile.currentUnit == null)
            {
                GameUnit unit = GameObject.Instantiate<GameUnit>(produceUnit);
                currentHoveredTile.PlaceUnit(unit);
                unitInfoDisplay.DisplayInfo(unit);
            }
            else
            {
                if (currentHoveredTile.currentUnit.selected)
                {
                    currentHoveredTile.currentUnit.selected = false;
                    foreach (int neighbor in board.neighboures[currentHoveredTile.position])
                    {
                        board.tiles[neighbor].OnStopHover();
                    }
                } else
                {
                    currentHoveredTile.currentUnit.selected = true;
                    foreach (int neighbor in board.neighboures[currentHoveredTile.position])
                    {
                        board.tiles[neighbor].OnHover();
                    }
                }
            }
        }
    }

    private void UpdateHoveredTile()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameTile nextHoveredTile;
        if (Physics.Raycast(ray, out hit))
        {
            GameTile tile = hit.collider.GetComponentInParent<GameTile>();
            nextHoveredTile = tile;
        }
        else
        {
            nextHoveredTile = null;
        }

        if (nextHoveredTile != null && nextHoveredTile != currentHoveredTile)
        {
            nextHoveredTile.OnHover();
        }
        if (currentHoveredTile != null && nextHoveredTile != currentHoveredTile)
        {
            currentHoveredTile.OnStopHover();
        }

        if (nextHoveredTile != currentHoveredTile)
        {
            tileInfoDisplay.DisplayInfo(nextHoveredTile);
            unitInfoDisplay.DisplayInfo(nextHoveredTile == null ? null : nextHoveredTile.currentUnit);
        }
        currentHoveredTile = nextHoveredTile;
    }
}
