﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var cam = Camera.main;
		var topright = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
		var botright = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0f));
		var col = gameObject.GetComponent<EdgeCollider2D>();
		Vector2[] newPoints = col.points;
		newPoints[0] = botright;
		newPoints[1] = topright;
		col.points = newPoints;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
