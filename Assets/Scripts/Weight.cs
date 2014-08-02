using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weight : MonoBehaviour {

    LinkedList<Block> blocks;
    GameManager gameManager;

    public int PlayerIndex;

    // Timer variables
    float lastTick, interval;

	// Use this for initialization
	void Start () {
        blocks = new LinkedList<Block>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        lastTick = Time.time;
        interval = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
	    //if( Time.time > lastTick + interval )
        {
            float weight = 0.0f;
            foreach(Block block in blocks)
            {
				if (!block)
				{
					//weight -= block.rigidbody2D.mass;
					blocks.Remove(block);
					return;
				}
                if (block.rigidbody2D.IsSleeping())
                {
                    weight += block.rigidbody2D.mass;
                }
            }
            gameManager.AddScore(PlayerIndex, weight);
            lastTick = Time.time;
        }

	}

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Block")
            blocks.AddLast(collisionInfo.gameObject.GetComponent<Block>());
    }

    void OnTriggerExit2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Block")
            blocks.Remove(collisionInfo.gameObject.GetComponent<Block>());
    }
}
