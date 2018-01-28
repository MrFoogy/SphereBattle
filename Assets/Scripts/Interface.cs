using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    private GameTile currentHoveredTile;
    public TileInfoDisplay tileInfoDisplay;
    public UnitInfoDisplay unitInfoDisplay;
    public GameWorld world;
    public PlayerStateDisplay playerStateDisplay;
    public GameCamera gameCamera;
    public ConstructUnitPanel constructUnitPanel;
    public Game game;
    public Text winText; 
    private float zoomSpeed = 10f;

    void Update()
    {
        UpdateHoveredTile();

        if (Input.GetMouseButtonDown(0) && currentHoveredTile != null)
        {
            if (currentHoveredTile.terrainType == TerrainType.NEUTRAL && currentHoveredTile.position != 0 && currentHoveredTile.position != 41)
            {
                currentHoveredTile.terrainType = game.currentPlayer.playerNum == 0 ? TerrainType.RED : TerrainType.BLUE;
                world.ConstructUnit(currentHoveredTile, world.smallTowerPrefab);
                currentHoveredTile.InitializeVisuals();
                if (world.HavePath(currentHoveredTile.terrainType))
                {
                    ShowWinText(game.currentPlayer);
                    game.ui.playerStateDisplay.Hide();
                game.ui.playerStateDisplay.Hide();
                }
                game.ChangeTurn();
            }
        }
        if (Input.GetMouseButtonDown(0) && currentHoveredTile != null)
        {
            /*
            if (currentHoveredTile.currentUnit == null)
            {
                world.ConstructUnit(currentHoveredTile);
            }
            else
            {
                if (currentHoveredTile.currentUnit.selected)
                {
                    currentHoveredTile.currentUnit.selected = false;
                    foreach (GameTile neighbor in world.GetNeighbors(currentHoveredTile))
                    {
                        neighbor.OnStopHover();
                    }
                } else {
                   
                    currentHoveredTile.currentUnit.selected = true;
                    foreach (GameTile neighbor in world.GetNeighbors(currentHoveredTile))
                    {
                        neighbor.OnHover();
                        
                    }
                }
            }
            */
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            gameCamera.Zoom(Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomSpeed);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            world.SwitchPerspective();
        }
    }

    public void UpdatePlayer(Player player)
    {
        //constructUnitPanel.SetUnitButtons(player.playerClass.buildableUnits);
        playerStateDisplay.DisplayPlayerState(player);
    }

    public void ShowWinText(Player winner)
    {
        winText.text = (winner.playerNum == 0 ? "Red" : "Blue") + " player won! \n (Space to restart)";
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
            //tileInfoDisplay.DisplayInfo(nextHoveredTile);
            //unitInfoDisplay.DisplayInfo(nextHoveredTile == null ? null : nextHoveredTile.currentUnit);
        }
        currentHoveredTile = nextHoveredTile;
    }
}
