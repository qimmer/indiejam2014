using UnityEngine;
using System.Collections;

public class GameMenuButton : MonoBehaviour {

	void OnMouseDown()
	{
		Application.LoadLevel(0);
	}
}
