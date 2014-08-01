using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    float DamageMultiplier = 0.1f;
    GameObject owner = null;

    public float Health;
    public float Armor;
    public float Weight;

	// Use this for initialization
	void Start () {
        Health = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void OnCollisionEnter(Collision col)
    {
        Health -= (col.relativeVelocity.magnitude * DamageMultiplier) / Armor;
    }

    public GameObject Owner
    {
        get
        {
            return this.owner;
        }
        set
        {
            this.owner = value;
        }
        
    }
}
