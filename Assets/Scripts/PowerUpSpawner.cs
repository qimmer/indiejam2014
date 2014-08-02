using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject[] powerUps;

	private float lastSpawnTimer;
	public float medianInterval = 15;

	// Use this for initialization
	void Start () 
	{
		lastSpawnTimer = Time.time - medianInterval;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ((lastSpawnTimer + medianInterval) < Time.time)
		{
			lastSpawnTimer = Time.time;
			medianInterval = medianInterval * Random.Range (9,15) / 10; 

				GameObject newpowerUps = powerUps[Random.Range (0, powerUps.Length)];
				GameObject newObject = (GameObject)Instantiate(newpowerUps, spawnPoints[Random.Range (0, spawnPoints.Length)].transform.position, newpowerUps.transform.rotation);
				
				//float scaleAdder = Random.Range(0.6f, 1.4f);
				//newObject.transform.localScale = newObject.transform.localScale * scaleAdder;
				//newObject.rigidbody2D.AddTorque(Random.Range(90.0f, 600.0f));
		}
	}
}
