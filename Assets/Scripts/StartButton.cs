using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	void OnMouseDown()
	{
		print ("Click!");
		Application.LoadLevel(1);
	}
}
