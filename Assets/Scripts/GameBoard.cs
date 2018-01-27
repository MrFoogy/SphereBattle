using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {
    public float radius;
    public float angle = 30f;
    public GameObject hexagonPrefab;
    public GameObject pentagonPrefab;

	// Use this for initialization
	void Start () {
        GenSphere2();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GenerateSphere()
    {
        // Top side pentagons
        GameObject.Instantiate(pentagonPrefab, transform.position + Vector3.up * radius, transform.rotation * Quaternion.AngleAxis(36f, Vector3.up), transform);
        for (int i = 0; i < 5; i++)
        {
            Quaternion rot = Quaternion.AngleAxis(36f + 72f * i, Vector3.up) * Quaternion.AngleAxis(60f, Vector3.right);
            Quaternion ownRot = Quaternion.AngleAxis(216f + 72f * i, Vector3.up) * Quaternion.AngleAxis(-60f, Vector3.right);
            Vector3 pos = rot * Vector3.up * radius;
            GameObject.Instantiate(pentagonPrefab, transform.position + pos, transform.rotation * ownRot, transform);
        }

        // Middle layer hexagons
        for (int i = 0; i < 10; i++)
        {
            Quaternion rot = Quaternion.AngleAxis(36f * i, Vector3.up) * Quaternion.AngleAxis(-90f, Vector3.right);
            Quaternion ownRot = Quaternion.AngleAxis(90f + 36f * i, Vector3.up) * Quaternion.AngleAxis(-90f, Vector3.right);
            Vector3 pos = rot * Vector3.right * radius;
            GameObject.Instantiate(hexagonPrefab, transform.position + pos, transform.rotation * ownRot, transform);
        }

        // Bottom side hexagons
        for (int i = 0; i < 5; i++)
        {
            Quaternion rot = Quaternion.AngleAxis(72f * i, Vector3.up) * Quaternion.AngleAxis(150f, Vector3.right);
            Vector3 pos = rot * Vector3.up * radius;
            GameObject.Instantiate(hexagonPrefab, transform.position + pos, rot, transform);
        }

        // Bottom side pentagons
        for (int i = 0; i < 5; i++)
        {
            Quaternion rot = Quaternion.AngleAxis(72f * i, Vector3.up) * Quaternion.AngleAxis(120f, Vector3.right);
            Vector3 pos = rot * Vector3.up * radius;
            GameObject.Instantiate(pentagonPrefab, transform.position + pos, transform.rotation * rot, transform);
        }

        GameObject.Instantiate(pentagonPrefab, transform.position - Vector3.up * radius, transform.rotation * Quaternion.AngleAxis(216f, Vector3.up), transform);
    }

    void GenSphere2()
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
