using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {
    public float radius;
    public float angle = 30f;
    public GameObject hexagonPrefab;
    public GameObject pentagonPrefab;
    public GameCamera gameCamera;

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
                tile.OnClicked();
            }
        }
	}

    void GenerateSphere()
    {
        CreateTile(false, 36f, 0f, 90f);
        for (int i = 0; i < 5; i++)
        {
            CreateTile(false, 0f, 72f * i, 30f);
        }

        for (int i = 0; i < 5; i++)
        {
            CreateTile(true, 0f, 36f + 72f * i, 30f);
        }

        for (int i = 0; i < 5; i++)
        {
            CreateTile(true, 30f, 72f * i, 60f);
        }

        for (int i = 0; i < 10; i++)
        {
            CreateTile(true, 0f, 18f + 36f * i, 0f);
        }

        CreateTile(false, 180f + 36f, 0f, -90f);
        for (int i = 0; i < 5; i++)
        {
            CreateTile(false, 180f, 72f * i, -30f);
        }

        for (int i = 0; i < 5; i++)
        {
            CreateTile(true, 0f, 36f + 72f * i, -30f);
        }

        for (int i = 0; i < 5; i++)
        {
            CreateTile(true, 30f, 72f * i, -60f);
        }
    }

    private void CreateTile(bool isHexagon, float ownRot, float sideRot, float upRot)
    {
        GameObject tile = GameObject.Instantiate(isHexagon ? hexagonPrefab : pentagonPrefab, transform);
        tile.transform.Rotate(Vector3.right, upRot - 90f, Space.World);
        tile.transform.Rotate(Vector3.up, sideRot, Space.World);
        tile.transform.position += tile.transform.up * radius;
        tile.transform.Rotate(0f, ownRot, 0f, Space.Self);
    }
}
