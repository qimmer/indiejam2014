using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	public double winScore = 500;


	void OnMouseDown()
	{
		print ("Click!");
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().winScore = winScore;
		Application.LoadLevel(1);
	}
}
