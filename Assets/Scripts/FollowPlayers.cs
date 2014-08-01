using UnityEngine;
using System.Collections;

public class FollowPlayers : MonoBehaviour 
{
	public GameObject player1;
	public GameObject player2;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		float x = ((player1.transform.position.x - player2.transform.position.x) / 2.0f + player2.transform.position.x);
		transform.localPosition = (new Vector3(x, 8, -10));

		if(player1.transform.position.x > player2.transform.position.x)
			camera.orthographicSize = Mathf.Abs(Mathf.Clamp(player1.transform.position.x - player2.transform.position.x, 14, 20));
		else
			camera.orthographicSize = Mathf.Abs(Mathf.Clamp(player2.transform.position.x - player1.transform.position.x, 14, 20));
	}
}
