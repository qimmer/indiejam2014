using UnityEngine;
using System.Collections;

public class FollowPlayers : MonoBehaviour 
{
	public GameObject player1;
	public GameObject player2;
    Vector3 initialPosition;

    public float Stress = 0.0f;
	// Use this for initialization
	void Start () 
	{
        initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
        float dist = (player1.transform.position - player2.transform.position).magnitude;
		Vector3 center = ((player1.transform.position - player2.transform.position) / 2.0f + player2.transform.position);
		//transform.localPosition = (new Vector3(x, 8, -10));

		/*if(player1.transform.position.x > player2.transform.position.x)
			camera.orthographicSize = Mathf.Abs(Mathf.Clamp(player1.transform.position.x - player2.transform.position.x, 14, 20));
		else
			camera.orthographicSize = Mathf.Abs(Mathf.Clamp(player2.transform.position.x - player1.transform.position.x, 14, 20));*/

        transform.LookAt(center);
        transform.Rotate(new Vector3(Mathf.Sin(Time.time * 0.9f) * 1.3f, Mathf.Cos(Time.time * 1.3f) * 0.8f, 0));

        camera.fieldOfView = 40.0f + dist* 0.8f;

        transform.position = initialPosition + new Vector3(Mathf.Sin(Time.time * 55.0f), Mathf.Cos(Time.time * 37.0f), 0.0f) * Stress * 0.1f;

        Stress *= 0.92f;
	}
}
