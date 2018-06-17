using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardControl : MonoBehaviour {
    
    public GameObject Tile;

    public int columbLength;
    public int rowLength;
    public int numMin;
    public int numMax;
    public int difficulty;

    private float spaceingFactor = 1.6F;

    //Lists of tiles
    public List<GameObject> boardTiles;
    public List<GameObject> answerTiles;

    public int[,] boardNumsArray;

    //Store answers
    public int[] columbAnswerNums;
    public int[] rowAnswerNums;

    //Store puzzle pieces
    public int[,] puzzlePieces;

	// Use this for initialization
	void Start () {
        boardNumsArray = new int[rowLength, columbLength];
        columbAnswerNums = new int[rowLength];
        rowAnswerNums = new int[columbLength];
        puzzlePieces = new int[rowLength, columbLength];
        InitializeBoardTiles();
        InitializeRowAnswerTiles();
        InitializeColumbAnswerTiles();
        SelectPuzzleTiles();
	}

    // Update is called once per frame
    void Update () {
        
	}

    private void InitializeBoardTiles()
    {
        for (int x = 0; x <= (rowLength - 1); x++)
        {
            for (int y = 0; y <= (columbLength - 1); y++)
            {
                Vector3 pos = new Vector3(((x - 1) * spaceingFactor), ((y - 1) * spaceingFactor), -1F);
                GameObject currentBoardTile = Instantiate(Tile, pos, Quaternion.identity) as GameObject;

                //Makes each tile a child of the board
                currentBoardTile.transform.parent = gameObject.transform;

                //Name each tile with x and y coordinates
                currentBoardTile.name = "Tile x " + x + " y " + y;

                //Assignes a random number to each board tile and then adds them to a list
                currentBoardTile.transform./*FindChild("Number").*/GetComponentInChildren<tileNumber>().number = Random.Range(numMin, numMax);

                //Add each random number to a 2d array
                boardNumsArray[x, y] = currentBoardTile.transform./*FindChild("Number").*/GetComponentInChildren<tileNumber>().number;

                //print("Array " + boardNumsArray[x, y]);

                //Add each tile to a list
                boardTiles.Add(currentBoardTile);
            }
        }
    }

    private void InitializeColumbAnswerTiles()
    {
        for (int x = 0; x <= (rowLength - 1); x++)
        {
            Vector3 pos = new Vector3(((x - 1) * spaceingFactor), 3.5F, -1F);
            GameObject currentAnswerTile = Instantiate(Tile, pos, Quaternion.identity) as GameObject;
            currentAnswerTile.transform.parent = gameObject.transform;
            answerTiles.Add(currentAnswerTile);

            //Make each row answer number the sum of each columb
            currentAnswerTile.transform./*FindChild("Number").*/GetComponentInChildren<tileNumber>().number = boardNumsArray[x, 0] + boardNumsArray[x, 1] + boardNumsArray[x, 2];

            //Assign each answer to an array of columb answers
            columbAnswerNums[x] = currentAnswerTile.transform./*FindChild("Number").*/GetComponentInChildren<tileNumber>().number;
        }
    }

    private void InitializeRowAnswerTiles()
    {
         for (int y = 0; y <= (columbLength - 1); y++)
         {
            Vector3 pos = new Vector3(3.5F, ((y - 1) * spaceingFactor), -1F);
            GameObject currentAnswerTile = Instantiate(Tile, pos, Quaternion.identity) as GameObject;
            currentAnswerTile.transform.parent = gameObject.transform;
            answerTiles.Add(currentAnswerTile);

            //Make each row answer number the sum of each columb
            currentAnswerTile.transform./*FindChild("Number").*/GetComponentInChildren<tileNumber>().number = boardNumsArray[0, y] + boardNumsArray[1, y] + boardNumsArray[2, y];

            //Assign each answer to an array of columb answers
            rowAnswerNums[y] = currentAnswerTile.transform./*FindChild("Number").*/GetComponentInChildren<tileNumber>().number;
         }
    }

    private void SelectPuzzleTiles()
    {
        for (int i = 0; i <= difficulty; i++)
        {
            /*puzzlePieces[i,i] = boardNumsArray[Random.Range(0, rowLength), Random.Range(0, columbLength)];
            print("Puzzle Pieces " + puzzlePieces[i]);*/
        }
    }
}
