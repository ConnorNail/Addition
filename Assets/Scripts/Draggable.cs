using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour {

    Vector2 startPos;

    public GameObject draggedTile;
    public GameObject cell;

    private bool cellDetect;

    private float xScale;
    private float yScale;
    private float scaleInc = 0.7F;

    void Start()
    {
        //Change sorting layer of tile and number
        this.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "PuzzlePieces";
        this.gameObject.GetComponentInChildren<MeshRenderer>().sortingLayerName = "PuzzlePieces";

        xScale = transform.localScale.x;
        yScale = transform.localScale.y;
    }

    void OnMouseDrag()
    {
        //Store the game object being dragged
        draggedTile = gameObject;

        //Set tile position to mouse position
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

        //Increase scale of tile while being dragged
        transform.localScale = new Vector3(xScale + scaleInc, yScale + scaleInc, 1F);

        //Find cell that the mouse is over
        cell = GameObject.Find("Dropping Cell");

        //Snap tile into place on drag over cell
        if (cell == null) {
            transform.position = objectPos;
            cellDetect = false;
        } else {
            transform.position = cell.GetComponent<DropControl>().cellPos;
            cellDetect = true;
            //print(cellDetect);
        }
    }

    private void OnMouseUp()
    {
        //Return scale of tile to original
        transform.localScale = new Vector3(xScale, yScale, 1F);

        //Determine if tile was dropped on a cell
        if (cell != null) {
            cellDetect = true;
        } else {
            cellDetect = false;
        }
    }
}
