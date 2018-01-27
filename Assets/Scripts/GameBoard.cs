using System.Collections;
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

    public List<GameTile> tiles = new List<GameTile>();
    public List<List<int>> neighboures = new List<List<int>>();
         
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 42; i++)
            neighboures.Add(new List<int>());
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
        tiles.Add(CreateTile(false, 36f, 0f, 90f, index));

        neighboures[0] = new List<int> {1, 2, 3, 4, 5};

        for (int i = 0; i < 5; i++)
        {
            index++;
            tiles.Add(CreateTile(true, 30f, 72f * i, 58f, index));
        }
        neighboures[1] = new List<int> {0, 2, 5, 11, 6, 15};
        neighboures[2] = new List<int> {0, 1, 3, 7, 11, 12};       
        neighboures[3] = new List<int> {0, 2, 4, 8, 12, 13};       
        neighboures[4] = new List<int> {0, 3, 5, 9, 13, 14};       
        neighboures[5] = new List<int> {0, 1, 4, 10, 14, 15};       
        for (int i = 0; i < 5; i++)
        {
            index++;
            tiles.Add(CreateTile(false, 0f, 72f * i, 27f, index));
        }
        neighboures[6] = new List<int> {1, 11, 15, 16, 25};       
        neighboures[7] = new List<int> {2, 11, 12, 17, 18};       
        neighboures[8] = new List<int> {3, 12, 13, 19, 20};       
        neighboures[9] = new List<int> {4, 13, 14, 21, 22};       
        neighboures[10] = new List<int> {5, 14, 15, 23, 24};       
        for (int i = 0; i < 5; i++)
        {
            index++;
            tiles.Add(CreateTile(true, 0f, 36f + 72f * i, 31.5f, index));
        }
        neighboures[11] = new List<int> {1, 2, 6, 7, 16, 17};       
        neighboures[12] = new List<int> {2, 3, 7, 8, 18, 19};       
        neighboures[13] = new List<int> {3, 4, 8, 9, 20, 21};       
        neighboures[14] = new List<int> {4, 5, 9, 10, 22, 23};       
        neighboures[15] = new List<int> {1, 5, 6, 10, 24, 25};       

        for (int i = 0; i < 10; i++)
        {
            index++;
            tiles.Add(CreateTile(true, 0f, 18f + 36f * i, 0f, index));
        }
        neighboures[16] = new List<int> {6, 11, 17, 25, 26, 31}; 
        neighboures[17] = new List<int> {7, 11, 16, 18, 27, 31}; 
        neighboures[18] = new List<int> {7, 12, 17, 19, 27, 32}; 
        neighboures[19] = new List<int> {8, 12, 18, 20, 28, 32}; 
        neighboures[20] = new List<int> {8, 13, 19, 21, 28, 33}; 
        neighboures[21] = new List<int> {9, 13, 20, 22, 29, 33}; 
        neighboures[22] = new List<int> {9, 14, 21, 23, 29, 34}; 
        neighboures[23] = new List<int> {10, 14, 22, 24, 30, 34}; 
        neighboures[24] = new List<int> {10, 15, 23, 25, 30, 35}; 
        neighboures[25] = new List<int> {6, 15, 16, 24, 26, 35}; 

        for (int i = 0; i < 5; i++)
        {
            index++;
            tiles.Add(CreateTile(false, 180f, 72f * i, -27f, index));
        }
        neighboures[26] = new List<int> {16, 25, 31, 25, 36}; 
        neighboures[27] = new List<int> {17, 18, 31, 32, 37}; 
        neighboures[28] = new List<int> {19, 20, 32, 33, 38}; 
        neighboures[29] = new List<int> {21, 22, 33, 34, 39}; 
        neighboures[30] = new List<int> {23, 24, 34, 35, 40}; 

        for (int i = 0; i < 5; i++)
        {
            index++;
            tiles.Add(CreateTile(true, 0f, 36f + 72f * i, -31.5f, index));
        }
        neighboures[31] = new List<int> {16, 17, 26, 27, 36, 37}; 
        neighboures[32] = new List<int> {18, 19, 27, 28, 37, 38}; 
        neighboures[33] = new List<int> {20, 21, 28, 29, 38, 39}; 
        neighboures[34] = new List<int> {22, 23, 29, 30, 39, 40}; 
        neighboures[35] = new List<int> {24, 25, 26, 31, 36, 40}; 

        for (int i = 0; i < 5; i++)
        {
            index++;
            tiles.Add(CreateTile(true, 30f, 72f * i, -58f, index));
        }
        neighboures[36] = new List<int> {26, 31, 35, 37, 40, 41}; 
        neighboures[37] = new List<int> {27, 31, 32, 36, 38, 41}; 
        neighboures[38] = new List<int> {28, 32, 33, 37, 39, 41}; 
        neighboures[39] = new List<int> {29, 33, 34, 38, 40, 41}; 
        neighboures[40] = new List<int> {30, 34, 35, 36, 39, 41}; 

        tiles.Add(CreateTile(false, 180f + 36f, 0f, -90f, ++index));
        neighboures[41] = new List<int> {36, 37, 38, 39, 40}; 

    }

    private GameTile CreateTile(bool isHexagon, float ownRot, float sideRot, float upRot, int position = 0)
    {
        GameTile tile = GameObject.Instantiate<GameTile>(isHexagon ? hexagonPrefab : pentagonPrefab, transform);
        tile.transform.Rotate(Vector3.right, upRot - 90f, Space.World);
        tile.transform.Rotate(Vector3.up, sideRot, Space.World);
        tile.transform.position += tile.transform.up * (isHexagon ? hexRadius : pentRadius);
        tile.position = position;
        tile.text.text = "" + position;
        tile.transform.Rotate(0f, ownRot, 0f, Space.Self);
        return tile;
    }
}
