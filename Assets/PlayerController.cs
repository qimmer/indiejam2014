﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public KeyCode upKey;
	public KeyCode downKey;
	public KeyCode leftKey;
	public KeyCode rightKey;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Input.GetAxis("Vertical") > 0 && rigidbody2D.velocity.x < 2)
		{
			gameObject.rigidbody2D.AddForce(new Vector2(0, (Input.GetAxis("Vertical"))) * 25);
			Mathf.Clamp(rigidbody2D.velocity.x, -5, 2);
			print(rigidbody2D.velocity.y);
		}
		if (Input.GetKey(leftKey))
			gameObject.rigidbody2D.AddForce(Vector2.right * -25);
		if (Input.GetKey(rightKey))
			gameObject.rigidbody2D.AddForce(Vector2.right * 25);
		if (Input.GetKey(downKey))
		{

		}
	}
}
