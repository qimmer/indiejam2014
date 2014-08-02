using UnityEngine;
using System.Collections;

public class BackroundAlienSpawner : MonoBehaviour {

    public float Speed;
    public float Range;

    public GameObject[] Aliens;
    public int NumberOfAliens;

    float[] alienOffsets;
    float[] alienSpeeds;
    GameObject[] alienObjects;

    float nextExplosion;

	// Use this for initialization
	void Start () {
        nextExplosion = Time.time + Random.Range(1.0f, 6.0f);

        alienObjects = new GameObject[NumberOfAliens];
        alienOffsets = new float[NumberOfAliens];
        alienSpeeds = new float[NumberOfAliens];

	    for( int i = 0; i < NumberOfAliens; ++i )
        {
            alienObjects[i] = (GameObject)Instantiate(Aliens[Random.Range(0, Aliens.Length-1)]);
            alienObjects[i].transform.parent = transform;
            alienObjects[i].transform.position = transform.position + new Vector3(0, Random.Range(0, 40), Random.Range(0, 140));
            alienOffsets[i] = Random.Range(0.0f, Mathf.PI * 2);
            alienSpeeds[i] = Random.Range(0.5f, 2.0f);

            float scale = Random.Range(50, 100);
            alienObjects[i].transform.localScale = new Vector3(scale, scale, scale);
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < NumberOfAliens; ++i)
        {
            alienObjects[i].transform.localPosition = new Vector3(Mathf.Sin(alienOffsets[i] + Time.time * Speed * alienSpeeds[i]) * Range, alienObjects[i].transform.localPosition.y + Mathf.Cos(alienOffsets[i] + Time.time * Speed * 2.0f) * 0.1f, alienObjects[i].transform.localPosition.z);
            
        }

        if( Time.time > nextExplosion )
        {
            nextExplosion = Time.time + Random.Range(0.1f, 0.5f);
            GameObject.Find("GameManager").GetComponent<GameManager>().CreateExplosion(transform.position + new Vector3(Random.Range(-Range, Range), Random.Range(0, 40), Random.Range(0, 140)), 1.0f);
        }
	}
}
