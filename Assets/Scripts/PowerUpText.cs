using UnityEngine;
using System.Collections;

public class PowerUpText : MonoBehaviour {

	// Use this for initialization
	void Awake () 
	{
		rigidbody2D.AddForce(Vector3.up * 500);
		Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
