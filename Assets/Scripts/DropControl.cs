using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropControl : MonoBehaviour
{

    public Vector2 cellPos;
    public bool cellDetect;

    private void OnMouseEnter()
    {
        
    }

    private void OnMouseOver()
    {
        //print(gameObject.name);

        cellPos = new Vector2(transform.position.x, transform.position.y);

        gameObject.name = "Dropping Cell";
    }

    void OnMouseExit()
    {
        gameObject.name = "Cell";
    }

    private void Update()
    {
        
    }
}