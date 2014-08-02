using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver()
	{
		print ("MouseOver");
	}

	void OnMouseDown()
	{
		print ("Click!");
		Application.LoadLevel(1);
	}
}
