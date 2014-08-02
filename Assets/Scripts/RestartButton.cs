using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp (KeyCode.JoystickButton7) || Input.GetKeyUp (KeyCode.JoystickButton9))
		{
			Application.LoadLevel(1);
		}
	}

	void OnMouseOver()
	{
		//print ("MouseOver");
	}

	void OnMouseDown()
	{
		print ("Click!");
		Application.LoadLevel(1);
	}
}
