﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {
    public float hexRadius;
    public float pentRadius;
    public float angle = 30f;
    public GameTile hexagonPrefab;
    public GameTile pentagonPrefab;
    public GameCamera gameCamera;
    public GameUnit produceUnit;

	// Use this for initialization
	void Start () {
        GenerateSphere();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                GameTile tile = hit.collider.GetComponentInParent<GameTile>();
                if (tile.currentUnit == null)
                {
                    GameUnit unit = GameObject.Instantiate<GameUnit>(produceUnit);
                    tile.PlaceUnit(unit);
                } else
                {
                    tile.RemoveUnit();
                }
            }
        }
	}

    void GenerateSphere()
    {
        int index = 0;
        CreateTile(false, 36f, 0f, 90f, index);

        for (int i = 0; i < 5; i++)
        {
            index++;
            CreateTile(true, 30f, 72f * i, 58f, index);
        }
        
        for (int i = 0; i < 5; i++)
        {
            CreateTile(false, 0f, 72f * i, 27f);
        }

        for (int i = 0; i < 5; i++)
        {
            CreateTile(true, 0f, 36f + 72f * i, 31.5f);
        }

        for (int i = 0; i < 10; i++)
        {
            CreateTile(true, 0f, 18f + 36f * i, 0f);
        }

        CreateTile(false, 180f + 36f, 0f, -90f);
        for (int i = 0; i < 5; i++)
        {
            CreateTile(false, 180f, 72f * i, -27f);
        }

        for (int i = 0; i < 5; i++)
        {
            CreateTile(true, 0f, 36f + 72f * i, -31.5f);
        }

        for (int i = 0; i < 5; i++)
        {
            CreateTile(true, 30f, 72f * i, -58f);
        }
    }

    private void CreateTile(bool isHexagon, float ownRot, float sideRot, float upRot, int position = 0)
    {
        GameTile tile = GameObject.Instantiate<GameTile>(isHexagon ? hexagonPrefab : pentagonPrefab, transform);
        tile.transform.Rotate(Vector3.right, upRot - 90f, Space.World);
        tile.transform.Rotate(Vector3.up, sideRot, Space.World);
        tile.transform.position += tile.transform.up * (isHexagon ? hexRadius : pentRadius);
        tile.position = position;
        tile.text.text = "" + position;
        tile.transform.Rotate(0f, ownRot, 0f, Space.Self);
    }
}
