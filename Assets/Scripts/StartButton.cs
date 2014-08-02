using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	public double winScore = 500;


	void OnMouseDown()
	{
		print ("Click!");
		PlayerPrefs.SetFloat("WinScore", (float)winScore);
		Application.LoadLevel(1);
	}
}
