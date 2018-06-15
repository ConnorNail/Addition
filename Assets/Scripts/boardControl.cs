using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardControl : MonoBehaviour {
    
    public GameObject Tile;

    public int columbs;
    public int rows;

    private float spaceingFactor = 1.6F;

    public List<GameObject> boardTiles;
    public List<GameObject> answerTiles;

    public List<int> answerNums;

	// Use this for initialization
	void Start () {
        initializeBoardTiles();
        initializeRowAnswerTiles();
        initializeColumbAnswerTiles();
	}

    // Update is called once per frame
    void Update () {
        
	}

    private void initializeBoardTiles()
    {
        for (int x = -1; x <= (rows - 2); x++)
        {
            for (int y = -1; y <= (columbs - 2); y++)
            {
                Vector3 pos = new Vector3(((x) * spaceingFactor), ((y) * spaceingFactor), -1F);
                GameObject currentBoardTile = Instantiate(Tile, pos, Quaternion.identity) as GameObject;
                currentBoardTile.name = "Tile x";
                currentBoardTile.transform.parent = gameObject.transform;
                currentBoardTile.transform.FindChild("Number").GetComponent<tileNumber>();
                boardTiles.Add(currentBoardTile);
            }
        }
    }

    private void initializeRowAnswerTiles()
    {
        for (int x = -1; x <= (rows - 2); x++)
        {
            Vector3 pos = new Vector3(((x) * spaceingFactor), 3.5F, -1F);
            GameObject currentAnswerTile = Instantiate(Tile, pos, Quaternion.identity) as GameObject;
            currentAnswerTile.transform.parent = gameObject.transform;
            answerTiles.Add(currentAnswerTile);

        }
    }

    private void initializeColumbAnswerTiles()
    {
         for (int y = -1; y <= (columbs - 2); y++)
         {
             Vector3 pos = new Vector3(3.5F, ((y) * spaceingFactor), -1F);
             GameObject currentAnswerTile = Instantiate(Tile, pos, Quaternion.identity) as GameObject;
             currentAnswerTile.transform.parent = gameObject.transform;
             answerTiles.Add(currentAnswerTile);
         }
    }
}
