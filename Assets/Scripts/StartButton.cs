using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	public double winScore = 500;

	void Update()
	{
		//if (Input.GetKeyUp (KeyCode.Joystick1Button17))
	}

	void OnMouseDown()
	{
		print ("Click!");
		PlayerPrefs.SetFloat("WinScore", (float)winScore);
		Application.LoadLevel(1);
	}
}
