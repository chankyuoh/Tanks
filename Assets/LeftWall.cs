using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var cam = Camera.main;
		var topleft = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0f));
		var botleft = cam.ScreenToWorldPoint(new Vector3(0, 0, 0f));
		var col = gameObject.GetComponent<EdgeCollider2D>();
		Vector2[] newPoints = col.points;
		newPoints[0] = botleft;
		newPoints[1] = topleft;
		col.points = newPoints;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
