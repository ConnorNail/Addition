using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileNumber : MonoBehaviour {

    public int number;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<TextMesh>().text = "" + number;

        if (number > 9) {
            GetComponent<TextMesh>().fontSize = 15;
        } else {
            GetComponent<TextMesh>().fontSize = 20;
        }
	}
}
