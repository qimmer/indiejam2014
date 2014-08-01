using UnityEngine;
using System.Collections;

public class PickUpZone : MonoBehaviour 
{
	public GameObject[] blocks;
	public GameObject[] spawnpoints;
	//public static LinkedList<GameObject> itmList1 = new LinkedList<GameObject>();
	// Use this for initialization
	void Start () 
	{
		//blocksInZone = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		//blocksInZone.add(col.gameObject);
	}

}
