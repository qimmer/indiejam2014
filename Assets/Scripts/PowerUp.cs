using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.transform.tag == "Player")
		{
			int power = Random.Range(1,4);
			if (power == 0)
			{
				print ("Gravity1");
				col.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
			}
			if (power == 1)
			{
				print ("maxVelocityBonus");
				col.gameObject.GetComponent<PlayerController>().maxVelocityBonus++;
			}
			if (power == 2)
			{
				print ("Speed");
				col.gameObject.GetComponent<PlayerController>().speed = col.gameObject.GetComponent<PlayerController>().speed + 50;
			}
			if (power == 3)
			{
				print ("Gravity2");
				col.gameObject.GetComponent<Rigidbody2D>().gravityScale = col.gameObject.GetComponent<Rigidbody2D>().gravityScale * Random.Range(8,13) / 10;
			}
			print ("POW!");
			Destroy(gameObject);
		}
	}
}
