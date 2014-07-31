using UnityEngine;
using System.Collections;

public class ExplosiveBlock : Block {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnCollisionEnter(Collision col)
    {
        base.OnCollisionEnter(col);

        if( col.relativeVelocity.magnitude > 2 )
        {

        }
    }
}
