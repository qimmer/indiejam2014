﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpZone : MonoBehaviour 
{
	public int zoneBlocks;
	public GameObject[] blocks;
	public GameObject[] spawnpoints;
	//public ArrayList blocksInZone2 = new ArrayList();
	public LinkedList<GameObject> blocksInZone = new LinkedList<GameObject>();
	private float lastSpawnTimer;
	public float interval = 5;

	// Use this for initialization
	void Start () 
	{
		lastSpawnTimer = Time.time - interval;
		zoneBlocks = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		foreach (GameObject block in blocksInZone)
		{
			if(!block)
			{
				blocksInZone.Remove(block);
				zoneBlocks--;
				return;
			}
		}
		if (Input.GetKeyUp (KeyCode.L))
			print (zoneBlocks + " blocks in zone");
		if (Input.GetKeyUp (KeyCode.P))
			foreach (GameObject block in blocksInZone)
			         print (block.rigidbody2D.mass);
		if ((lastSpawnTimer + interval) < Time.time)
		{
			lastSpawnTimer = Time.time;

			if (zoneBlocks< 3)
			{
				GameObject newBlock = blocks[Random.Range (0, blocks.Length)];
				GameObject newObject = (GameObject)Instantiate(newBlock, spawnpoints[Random.Range (0, spawnpoints.Length)].transform.position, newBlock.transform.rotation);

                float scaleAdder = Random.Range(0.6f, 1.4f);
                newObject.transform.localScale = newObject.transform.localScale * scaleAdder;
                newObject.rigidbody2D.AddTorque(Random.Range(90.0f, 600.0f));
                
			}
		}

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (!blocksInZone.Contains(col.gameObject) && col.tag == "Block")
		{
		    blocksInZone.AddLast(col.gameObject);
			//print (blocksInZone.Last.Value.gameObject.name);
			zoneBlocks++;
		}

		//blocksInZone2.Add(col.gameObject);


	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (blocksInZone.Contains(col.gameObject))
		{
			blocksInZone.Remove(col.gameObject);
			//print("Removed: " + col.gameObject.name);
			zoneBlocks--;
		}
	}

}
