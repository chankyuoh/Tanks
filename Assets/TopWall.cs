using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopWall : MonoBehaviour {
	// Use this for initialization
	void Start ()
	{
		var cam = Camera.main;
		var topright = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
		var topleft = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0f));
		var col = gameObject.GetComponent<EdgeCollider2D>();
		Vector2[] newPoints = col.points;
		newPoints[0] = topleft;
		newPoints[1] = topright;
		col.points = newPoints;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
