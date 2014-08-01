using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    float DamageMultiplier = 0.1f;
    GameObject owner = null;

    public float Health;
    public float Armor;
    public float Weight;
	public bool isTNT = false;
	public float fuseTime = 0;
	public float fuseLength = 10;

	public float radius = 5.0F;
	public float power = 10.0F;

	// Use this for initialization
	void Start () 
	{
        //Health = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(fuseTime != 0)
			if (fuseTime + fuseLength < Time.time)
			{
				gameObject.tag = "Explosion";
				if(GetComponent<CircleCollider2D>().radius < 4)
				{
					GetComponent<CircleCollider2D>().radius = GetComponent<CircleCollider2D>().radius + 0.1f;
				}
				else
				{
					Destroy (gameObject);
					print("BOOM!");
				}

			}
	}

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
		if(col.gameObject.tag == "Explosion")
			Damage ();
        //Health -= (col.relativeVelocity.magnitude * DamageMultiplier) / Armor;
    }

	public void CountDown()
	{
		//print ("Countdown");
		if(isTNT)
			fuseTime = Time.time;
	}

	public void Damage()
	{
		print ("Smash!");
		Health--;
		if(Health <= 0)
		{
			if (owner)
				owner.transform.FindChild("Trigger").gameObject.GetComponent<RopeTrigger>().ReleaseBox();
			Destroy (gameObject);
			print ("Crash!");

		}
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
